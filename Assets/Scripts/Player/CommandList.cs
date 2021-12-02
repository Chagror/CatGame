using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CommandList", menuName = "ScriptableObjects/Action/CommandList")]
public class CommandList : ScriptableObject
{
    public List<Action> actions;

    public Action Find(string command)
    {
        foreach (Action action in actions)
        {
            if (action.Contains(command))
            {
                return action;
            }
        }

        return null;
    }
    public bool Contains(string command)
    {
        foreach (Action action in actions)
        {
            if (action.Contains(command))
            {
                return true;
            }
        }

        return false;
    }
}
