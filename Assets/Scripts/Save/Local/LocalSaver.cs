using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LocalSaver : Saver
{
    public async Task<Save> CreateSave() 
    {
        List<string> playersID = new List<string>();
        List<string> colors = new List<string>();
        List<Vector2> playersIndex = new List<Vector2>();
        List<Vector2> tileIndex = new List<Vector2>();
        List<Player> players =  PlayerManager.instance.GetPlayerList();
        await Task.Run(() =>
        {
            foreach (Player p in players)
            {
                playersID.Add(p.GetName());
                Vector2 index = new Vector2();
                index[0] = p.GetMapIndexX();
                index[1] = p.GetMapIndexY();
                playersIndex.Add(index);
                colors.Add(p.GetColor());
            }
        });
        List<Tile> tiles = LevelManager.instance.GetTileMap().GetTiles();
        await Task.Run(() =>
        {
            foreach (Tile tile in tiles)
            {
                Vector2 index = new Vector2();
                index[0] = tile.getX();
                index[1] = tile.getY();
                tileIndex.Add(index);
            }
        });
            Save save = new Save();
        save.playersIndex = playersIndex;
        save.playersID = playersID;
        save.tileIndex = tileIndex;
        save.colors = colors;
        Debug.Log("Saved");
        return save;
    }
    public override async Task SaveGame() 
    {
        Save save = await CreateSave();
        
        byte[] bytes = await Task.Run(() =>
        {
            string jsonString = JsonUtility.ToJson(save);
            return Encoding.UTF8.GetBytes(jsonString);
        });
        using FileStream file = new FileStream(Application.persistentDataPath + "/gamesave.save", FileMode.Create, FileAccess.Write, FileShare.Write);
        if (file == null)
            return;
        await file.WriteAsync(bytes, 0, bytes.Length);
        file.Close();
        
        
        await Task.Delay(1000);
    }
}
