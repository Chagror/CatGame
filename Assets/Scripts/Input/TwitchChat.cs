using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;
using System.Linq;
using UnityEngine.Serialization;

public class TwitchChat : MonoBehaviour
{
    private TcpClient _twitchClient;
    private StreamReader _reader;
    private StreamWriter _writer;
    [SerializeField]
    private TwitchInputManager _twitchInputManager;
    private GameManager _gameManager;
    private PlayerManager _playerManager;
    [SerializeField] private CommandReadedFromTwitch _commandReaded;

    public string username, password, channelName; //https://twitchapps.com/tmi

    // Start is called before the first frame update
    void Start()
    {
        Connect();
        _gameManager = GameManager.instance;
        _playerManager = PlayerManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_twitchClient.Connected)
            Connect();

        ReadChat();
    }

    private void Connect()
    {
        _twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        _reader = new StreamReader(_twitchClient.GetStream());
        _writer = new StreamWriter(_twitchClient.GetStream());

        _writer.WriteLine("PASS " + password);
        _writer.WriteLine("NICK " + username);
        _writer.WriteLine("USER " + username + " 8 * :" + username);
        _writer.WriteLine("JOIN #" + channelName);
        _writer.WriteLine("CAP REQ :twitch.tv/tags"); 
        _writer.Flush();
    }

    private void ReadChat()
    {
        //Debug.Log("read");

        if (_twitchClient.Available > 0)
        {
            var line = _reader.ReadLine();
            
            //Get infos of the message
            if (line == "")
                return;

            if (line.Contains("PRIVMSG"))
            {
                string[] splits = line.Split(';');
                
                //Get the name of the user
                var chatName = splits[4];
                var splitPoint = chatName.IndexOf("=", 1);
                chatName = chatName.Substring(splitPoint + 1);
                
                //Get the color of the user
                var chatColor = splits[3];
                splitPoint = chatColor.IndexOf("=", 1);
                chatColor = chatColor.Substring(splitPoint + 1);

                //Get the message of the user
                var message = splits[splits.Length - 1];
                splitPoint = message.IndexOf("#", 1);
                message = message.Substring(splitPoint);

                splitPoint = message.IndexOf("!", 1);
                message = message.Substring(splitPoint);
                
                if (message[0] == '!')
                {
                    if(_gameManager.state == Game.State.Lobby && line.Contains("join"))
                    {
                        //Call method to create prefab
                        _playerManager.InstantiatePlayer(chatName, chatColor);
                    }
                    else if (_gameManager.state == Game.State.WaitForInput)
                    {
                        if (!_commandReaded.CommandPerPlayer.ContainsKey(chatName))
                            _commandReaded.CommandPerPlayer.Add(chatName, line);
                        else
                        {
                            _commandReaded.CommandPerPlayer[chatName] = line;
                        }
                        PassDictionary();
                    }
                }
            }
        }
    }

    private void PassDictionary()
    {
        _twitchInputManager.Notify();
    }
}
