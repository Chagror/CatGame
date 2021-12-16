using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EndGame", menuName = "ScriptableObjects/State/EndGame")]
public class EndGame : State
{
    public float waitBarSizeStart = 1;
    public override void BeginState()
    {
        time = gameData.timerEndGame;
        gameData.endMenu.SetActive(true);
        gameData.endText.text = PlayerManager.instance.GetPlayerList()[0].GetName() + " just won!!";
        waitBarSizeStart = gameData.waitBar.GetComponent<RectTransform>().rect.width; 
    }

    public async override void GoNextState()
    {
        gameData.stateGame = nextState;
        gameManager.RaiseEndEvent();
        gameData.stateGame.BeginState();
    }

    public override void Looping()
    {

        time -= Time.deltaTime;
        float delta = time/ gameData.timerEndGame;

        var tempBar = gameData.waitBar.GetComponent<RectTransform>();

        tempBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, waitBarSizeStart * delta);

        gameData.timerObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Timer to join : " + (int)time;
        if (time <= 0)
        {
            GoNextState();
        }
    }
}
