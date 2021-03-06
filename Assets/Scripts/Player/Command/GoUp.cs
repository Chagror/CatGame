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
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        Vector3 tempPos = player.transform.position;
        player.StartCoroutine(player.SmoothMove(new Vector3(tempPos.x, tempPos.y, tempPos.z + player.GetJumpSize()),
            new Vector3(tempPos.x, tempPos.y + 10, tempPos.z + player.GetJumpSize() / 2)));
        player.SetPosY(player.GetMapIndexY() - 1);
    }
}
