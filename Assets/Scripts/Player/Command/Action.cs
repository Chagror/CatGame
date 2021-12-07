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
        foreach (string commandName in commandNames)
        {
            if (commandName.Contains(command))
            {
                return true;
            }
        }

        return false;
    }
}
