using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;
using System.Linq;

public class TwitchChat : MonoBehaviour
{
    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;
    [SerializeField]
    private TwitchInputManager IM;
    private GameManager GM;
    [SerializeField] private CommandReadedFromTwitch _commandReaded;
    private Dictionary<string, string> CommandDictionary;

    public string username, password, channelName; //https://twitchapps.com/tmi

    // Start is called before the first frame update
    void Start()
    {
        Connect();
        GM = GameManager.instance;
        CommandDictionary = new Dictionary<string, string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!twitchClient.Connected)
            Connect();

        ReadChat();
    }

    private void Connect()
    {
        twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        reader = new StreamReader(twitchClient.GetStream());
        writer = new StreamWriter(twitchClient.GetStream());

        writer.WriteLine("PASS " + password);
        writer.WriteLine("NICK " + username);
        writer.WriteLine("USER " + username + " 8 * :" + username);
        writer.WriteLine("JOIN #" + channelName);
        writer.Flush();
    }

    private void ReadChat()
    {
        //Debug.Log("read");

        if (twitchClient.Available > 0)
        {
            var message = reader.ReadLine();
            
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
                    
                    //If will be replaced by So.list.contains
                    if ((message.Contains("join") || message.Contains("j")) && GM.state == Game.State.Lobby)
                    {
                        Debug.Log("yeeeeeeees");
                        CommandDictionary.Add(chatName, "");

                        //Call method to create prefab

                    }
                }
            }
        }
    }

    public Dictionary<string, string> GetDictionary()
    {
        return CommandDictionary;
    }

    public void PassDictionary()
    {
        _commandReaded.CommandPerPlayer = CommandDictionary;
        IM.Notify();
    }
}
