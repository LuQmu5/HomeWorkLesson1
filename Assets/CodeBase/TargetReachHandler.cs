using UnityEngine;

public class TargetReachHandler
{
    public TargetReachHandler(GameMode gameMode)
    {
        gameMode.TargetReached += OnTargetReached;
        gameMode.TargetFailed += OnTargetFailed;
    }

    private void OnTargetReached()
    {
        Debug.Log("Victory!");
        Time.timeScale = 0;
    }

    private void OnTargetFailed()
    {
        Debug.Log("Defeat...");
        Time.timeScale = 0;
    }
}