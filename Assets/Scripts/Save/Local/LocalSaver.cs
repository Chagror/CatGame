using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LocalSaver : Saver
{
    public Save CreateSave() 
    {
        List<string> playersID = new List<string>();
        List<int[]> playersIndex = new List<int[]>();
        List<int[]> tileIndex = new List<int[]>();
        List<Player> players =  PlayerManager.instance.GetPlayerList();
        foreach (Player p in players) 
        {
            playersID.Add(p.GetName());
            int[] index = new int[2];
            index[0] = p.GetMapIndexX();
            index[1] = p.GetMapIndexY();
            playersIndex.Add(index);
        }
        List<Tile> tiles = LevelManager.instance.GetTileMap().GetTiles();
        foreach (Tile tile in tiles)
        {
            int[] index = new int[2];
            index[0] = tile.getX();
            index[1] = tile.getY();
            tileIndex.Add(index);
        }
        Save save = new Save(playersID, playersIndex, tileIndex);
        Debug.Log("Saved");
        return save;
    }
    public override void SaveGame() 
    {
        Save save = CreateSave();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }
}
