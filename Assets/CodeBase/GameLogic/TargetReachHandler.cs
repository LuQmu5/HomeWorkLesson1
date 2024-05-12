using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetReachHandler
{
    public TargetReachHandler(GameMode gameMode, IReadOnlyCollection<Ball> balls)
    {
        gameMode.Init(balls);
        gameMode.Subscribe();

        gameMode.TargetReached += OnTargetReached;
        gameMode.TargetFailed += OnTargetFailed;
    }

    private void OnTargetReached()
    {
        Debug.Log("Victory!");
        SceneManager.LoadScene(0);
    }

    private void OnTargetFailed()
    {
        Debug.Log("Defeat...");
        SceneManager.LoadScene(0);
    }
}