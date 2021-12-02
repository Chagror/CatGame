using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GoLeft", menuName = "ScriptableObjects/Action/GoLeft")]
public class GoLeft : Action
{
    public override void Execute(Player player)
    {
        if(player == null)
            Debug.LogError("player doesn't exist");
        Vector3 tempPos = player.transform.position;
        player.transform.position = new Vector3(tempPos.x - player.GetJumpSize(), tempPos.y, tempPos.z);
        
    }
}
