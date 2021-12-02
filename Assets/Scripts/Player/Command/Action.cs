using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Action : ScriptableObject
{
    [SerializeField] public  List<string> commandNames;
    public abstract void Execute(Player p);

    public bool Contains(string command)
    {
        string tmpCommand = command.ToUpper().Replace(" ", string.Empty);
        foreach (string commandName in commandNames)
        {
            if ( String.Equals(commandName.ToUpper().Replace(" ", string.Empty),tmpCommand) )
            {
                return true;
            }
        }

        return false;
    }
}
