using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalSaverSystem : SaverSystem
{
    // Start is called before the first frame update
    void Start()
    {
        _save = new LocalSaver();
        _load = new LocalLoader();
    }
}
