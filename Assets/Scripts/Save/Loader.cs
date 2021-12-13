using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public  abstract class Loader
{
    // Start is called before the first frame update
    public abstract Task<Save> LoadGame();
}
