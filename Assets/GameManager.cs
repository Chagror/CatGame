using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Game SO;
    public Game.State state;

    [Header("Lobby variables")] public float timerToJoin;

    private void Awake()
    {
        if(instance)
            Destroy(instance);
        else
            instance = this;
    }

    private void Update()
    {
        switch (state)
        {
            case Game.State.Lobby:
                Lobby();
                break;
            case Game.State.WaitForInput:
                break;
            case Game.State.Move:
                break;
            case Game.State.EndGame:
                break;
            default: break;
        }
    }

    private void Lobby()
    {
        timerToJoin -= Time.deltaTime;

        if (timerToJoin < 0)
        {
            state = Game.State.WaitForInput;
        }
    }
}
