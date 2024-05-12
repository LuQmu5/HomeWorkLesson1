using UnityEngine;
using Zenject;

public class GameManagement
{
    public GameMode SelectedGameMode { get; private set; }

    [Inject]
    public GameManagement()
    {
        Debug.Log("GameManagement");
    }

    public void SetGameMode(GameMode gameMode)
    {
        SelectedGameMode = gameMode;
    }
}
