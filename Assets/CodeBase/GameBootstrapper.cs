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

    private void Awake()
    {
        _ballsData = Resources.LoadAll<BallData>(BallsDataPath);

        _selectGameModeMenu.Init();
        _ballSpawner.Init(_ballsData);
    }
}
