using UnityEngine;

public class GameLoopState : IState
{
    public void Enter()
    {
        Debug.Log("GameLoop");
    }

    public void Exit()
    {
        
    }
}