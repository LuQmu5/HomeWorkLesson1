using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    private const string BallsDataPath = "StaticData/Balls";

    [SerializeField] private SelectGameModeMenu _selectGameModeMenu;
    [SerializeField] private BallSpawner _ballSpawner;

    private BallData[] _ballsData;
    private List<GameMode> _gameModes = new List<GameMode>();

    private void Awake()
    {
        _ballsData = Resources.LoadAll<BallData>(BallsDataPath);
        _ballSpawner.Init(_ballsData);

        _gameModes.Add(new GameMode("”ничтожить все шары"));
        _gameModes.Add(new GameMode("”ничтожить красные шары"));
        _gameModes.Add(new GameMode("”ничтожить зелЄные шары"));
        _gameModes.Add(new GameMode("”ничтожить белые шары"));

        _selectGameModeMenu.Init(_gameModes);
    }
}

public class GameMode
{
    public string Target;

    public event Action TargetReached;

    public GameMode(string target)
    {
        Target = target;
    }
}