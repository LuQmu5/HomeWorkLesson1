using UnityEngine;

public class GameFactory : IGameFactory
{
    private readonly IGameStateMachine _stateMachine;

    public GameFactory(IGameStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void CreateHero(Vector3 at)
    {
        Resources.Load("Player");
    }

    public void CreateHud()
    {
        Resources.Load("Hud");
    }
}
