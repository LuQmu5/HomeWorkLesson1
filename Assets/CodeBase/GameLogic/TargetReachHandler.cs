using System;
using UnityEngine;
using Zenject;

public class TargetReachHandler : IDisposable
{
    private GameManagement _gameManagement;

    [Inject]
    public TargetReachHandler(GameManagement gameManagement, BallSpawner ballSpawner)
    {
        _gameManagement = gameManagement;

        _gameManagement.SelectedGameMode.Init(ballSpawner.SpawnedBalls);
        _gameManagement.SelectedGameMode.Subscribe();

        _gameManagement.SelectedGameMode.TargetReached += OnTargetReached;
        _gameManagement.SelectedGameMode.TargetFailed += OnTargetFailed;
    }

    public void Dispose()
    {
        _gameManagement.SelectedGameMode.TargetReached -= OnTargetReached;
        _gameManagement.SelectedGameMode.TargetFailed -= OnTargetFailed;
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