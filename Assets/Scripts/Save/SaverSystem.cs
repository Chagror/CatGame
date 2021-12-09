using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaverSystem : MonoBehaviour
{
    [SerializeField] private Saver _save = new LocalSaver();
    [SerializeField] private Loader _load = new LocalLoader();
    public void SaveGame() 
    {
        _save.SaveGame();
    }
}
