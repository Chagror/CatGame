using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Save 
{

    public List<string> _playersID;
    public List<int[]> _playersIndex;
    public List<int[]> _tileIndex;
    public Save(List<string> playersID, List<int[]> playersIndex, List<int[]> tileIndex) 
    {
        _playersID = playersID;
        _playersIndex = playersIndex;
        _tileIndex = tileIndex;
    }
}
