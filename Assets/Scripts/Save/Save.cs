using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Save
{

    private List<string> _playersID;
    private List<int[]> _playersIndex;
    private List<int[]> _tileIndex;
    public Save(List<string> playersID, List<int[]> playersIndex, List<int[]> tileIndex)
    {
        _playersID = playersID;
        _playersIndex = playersIndex;
        _tileIndex = tileIndex;
    }
    public List<string> getPlayersID() { return _playersID; }
    public List<int[]> getPlayerIndex() { return _playersIndex; }
    public List<int[]> getTileIndex() { return _tileIndex; }
}
