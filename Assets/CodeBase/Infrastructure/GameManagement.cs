using UnityEngine;
using Zenject;

public class GameManagement
{
    public GameMode SelectedGameMode { get; private set; }
    public int BallsCountOnLevel { get; private set; } = Constants.MinBallsCount;

    [Inject]
    public GameManagement()
    {
        Debug.Log("GameManagement");
    }

    public void SetGameMode(GameMode gameMode)
    {
        SelectedGameMode = gameMode;
    }

    public void SetBallsCountOnLevel(int value)
    {
        BallsCountOnLevel = value;
    }
}
