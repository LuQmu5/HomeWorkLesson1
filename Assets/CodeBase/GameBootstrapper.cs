using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    private const string BallsDataPath = "StaticData/Balls";
    private const string BallPrefabPath = "Ball";

    [SerializeField] private SelectGameModeMenu _selectGameModeMenu;

    private BallFactory _ballFactory;
    private TargetReachHandler _targetReachHandler;

    private void Awake()
    {
        _ballFactory = new BallFactory(Resources.LoadAll<BallData>(BallsDataPath), Resources.Load<Ball>(BallPrefabPath));

        _selectGameModeMenu.Init(new List<GameMode>()
        {
            new DestroyAllGameMode(_ballFactory.Balls),
            new DestroyAnyColorGameMode(_ballFactory.Balls, BallTypes.Red),
            new DestroyAnyColorGameMode(_ballFactory.Balls, BallTypes.Green),
            new DestroyAnyColorGameMode(_ballFactory.Balls, BallTypes.White),
        });

        _selectGameModeMenu.StartGameButtonPressed += OnStartGameButtonPressed;
    }

    private void OnStartGameButtonPressed(GameMode chosenMode)
    {
        _targetReachHandler = new TargetReachHandler(chosenMode);
        _selectGameModeMenu.gameObject.SetActive(false);
        _ballFactory.StartSpawn();
    }
}
