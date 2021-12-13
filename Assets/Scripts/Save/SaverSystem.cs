using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaverSystem : MonoBehaviour
{
    protected Saver _save = new LocalSaver();
    protected Loader _load = new LocalLoader();
    [SerializeField] private GameEvent _loaded;
    public async  void SaveGame() 
    {
        await _save.SaveGame();
        _loaded.Raise();
    }
    public async void LoadGame() 
    {
       var saveLoaded= await _load.LoadGame() ;
        if (saveLoaded.tileIndex.Count == 0) 
        {
            return;
        }
        LevelManager.instance.LoadMap(saveLoaded.playersID, saveLoaded.playersIndex, saveLoaded.tileIndex);
        _loaded.Raise();
    }
}
