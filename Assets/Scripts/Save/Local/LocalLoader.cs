using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

public class LocalLoader : Loader
{
    public override async Task<Save> LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        using FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
        byte[] bytes = new byte [file.Length];
        await file.ReadAsync(bytes, 0, (int)file.Length);
        //Save save = (Save)bf.Deserialize(file);
        Save save= await Task.Run(() =>
        {
            string jsonData =System.Text.Encoding.UTF8.GetString(bytes);
            return JsonUtility.FromJson<Save>(jsonData);
        });
        file.Close();
        await Task.Delay(2000);
        return save;
    }
}
