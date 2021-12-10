using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GoUp", menuName = "ScriptableObjects/Action/GoUp")]
public class GoUp : Action
{
    public override void Execute(Player player)
    {
        if(player == null)
            Debug.LogError("player doesn't exist");
        Vector3 tempPos = player.transform.position;
        player.StartCoroutine(player.SmoothMove(new Vector3(tempPos.x, tempPos.y, tempPos.z + player.GetJumpSize())));
        player.SetPosY(player.GetMapIndexY() - 1);
    }
}
