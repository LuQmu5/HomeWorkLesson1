using System;
using UnityEngine;
using Zenject;

public class GameManagementMediator : IDisposable
{
    private readonly GameManagement _gameManagement;
    private readonly SelectGameModeMenu _selectGameModeMenu;
    private readonly SceneLoader _sceneLoader;

    [Inject]
    public GameManagementMediator(GameManagement gameManagement, SelectGameModeMenu selectGameModeMenu, SceneLoader sceneLoader)
    {
        Debug.Log("GameManagementMediator");

        _gameManagement = gameManagement;
        _selectGameModeMenu = selectGameModeMenu;
        _sceneLoader = sceneLoader;

        _selectGameModeMenu.GameModeSelected += OnGameModeSelected;
        _selectGameModeMenu.StartGameButtonPressed += OnStartGameButtonPressed;
        _selectGameModeMenu.BallsCountOnLevelChanged += OnBallsCountOnLevelChanged;
    }

    public void Dispose()
    {
        _selectGameModeMenu.GameModeSelected -= OnGameModeSelected;
        _selectGameModeMenu.StartGameButtonPressed -= OnStartGameButtonPressed;
        _selectGameModeMenu.BallsCountOnLevelChanged -= OnBallsCountOnLevelChanged;
    }

    private void OnGameModeSelected(GameMode selectedGameMode)
    {
        _gameManagement.SetGameMode(selectedGameMode);
    }

    private void OnBallsCountOnLevelChanged(int value)
    {
        _gameManagement.SetBallsCountOnLevel(value);
    }

    private void OnStartGameButtonPressed()
    {
        _sceneLoader.Load("Game", container =>
        {
            container.BindInstance(_gameManagement).AsSingle();
        });
    }
}