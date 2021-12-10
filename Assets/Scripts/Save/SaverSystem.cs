using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaverSystem : MonoBehaviour
{
    protected Saver _save = new LocalSaver();
    protected Loader _load = new LocalLoader();
    [SerializeField] private GameEvent _loaded;
    public void SaveGame() 
    {
        _save.SaveGame();
    }
    public void LoadGame() 
    {
        Save save =_load.LoadGame();
        if (save is null) 
        {
            return;
        }
        LevelManager.instance.LoadMap(save.getPlayersID(),save.getPlayerIndex(),save.getTileIndex());
        _loaded.Raise();
    }
}
