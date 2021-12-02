using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;

public class TwitchChat : MonoBehaviour
{
    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;

    public string username, password, channelName; //https://twitchapps.com/tmi

    // Start is called before the first frame update
    void Start()
    {
        Connect();
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
        if(twitchClient.Available > 0)
        {
            var message = reader.ReadLine();
            
            if(message.Contains("PRIVMSG"))
            {
                //Get username
                var splitpoint = message.IndexOf("!", 1);
                var chatName = message.Substring(0, splitpoint);
                chatName = chatName.Substring(1);

                //Get user message
                splitpoint = message.IndexOf(":", 1);
                message = message.Substring(splitpoint + 1);
                //print(String.Format("{0}: {1}", chatName, message));
            }
        }
    }
}
