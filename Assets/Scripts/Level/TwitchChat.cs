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
    private Dictionary<string, string> _commandDictionary;

    public string username, password, channelName; //https://twitchapps.com/tmi

    // Start is called before the first frame update
    void Start()
    {
        Connect();
        _gameManager = GameManager.instance;
        _playerManager = PlayerManager.instance;
        _commandDictionary = new Dictionary<string, string>();
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
        _writer.Flush();
    }

    private void ReadChat()
    {
        //Debug.Log("read");

        if (_twitchClient.Available > 0)
        {
            var message = _reader.ReadLine();
            
            //Get infos of the message
            if (message == "")
                return;
            
            if (message.Contains("PRIVMSG"))
            {
                
                Debug.Log(message);
                
                //Get username
                var splitpoint = message.IndexOf("!", 1);
                var chatName = message.Substring(0, splitpoint);
                chatName = chatName.Substring(1);

                //Get user message
                splitpoint = message.IndexOf(":", 1);
                message = message.Substring(splitpoint + 1);
                print(String.Format("{0}: {1}", chatName, message));

                if (message[0] == '!')
                {
                    /*if (CommandDictionary.ContainsKey(chatName))
                    {
                        message = message.Substring(1);
                        CommandDictionary[chatName] = message;
                    }*/
                    
                    if ((message.Contains("join") || message.Contains("j")) && _gameManager.state == Game.State.Lobby)
                    {
                        //Call method to create prefab
                        _playerManager.InstantiatePlayer(chatName);
                    }
                }
            }
        }
    }

    public Dictionary<string, string> GetDictionary()
    {
        return _commandDictionary;
    }

    public void PassDictionary()
    {
        _commandReaded.CommandPerPlayer = _commandDictionary;
        _twitchInputManager.Notify();
    }
}
