using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LocalLoader : Loader
{
    public override Save LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
        if (file is null)
            return null;
        Save save = (Save)bf.Deserialize(file);
        file.Close();
        return save;
    }
}
