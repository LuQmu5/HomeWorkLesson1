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
    }

    public void Dispose()
    {
        _selectGameModeMenu.GameModeSelected -= OnGameModeSelected;
        _selectGameModeMenu.StartGameButtonPressed -= OnStartGameButtonPressed;
    }

    private void OnGameModeSelected(GameMode selectedGameMode)
    {
        _gameManagement.SetGameMode(selectedGameMode);
    }

    private void OnStartGameButtonPressed()
    {
        _sceneLoader.Load(1, container =>
        {
            container.BindInstance(_gameManagement).AsSingle();
        });
    }
}