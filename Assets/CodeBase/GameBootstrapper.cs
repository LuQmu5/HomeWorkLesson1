using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    private const string BallsDataPath = "StaticData/Balls";
    private const string BallPrefabPath = "Ball";

    [Header("UI Settings")]
    [SerializeField] private SelectGameModeMenu _selectGameModeMenu;
    [SerializeField] private TargetTextDisplay _targetTextDisplay;

    [Header("Balls Settings")]
    [SerializeField] private Transform _ballSpawnPosition;
    [SerializeField] private int _ballsCountOnLevel = 5;

    private BallFactory _ballFactory;
    private TargetReachHandler _targetReachHandler;
    private BallData[] _ballsData;

    private void Awake()
    {
        _ballsData = Resources.LoadAll<BallData>(BallsDataPath);
        _ballFactory = new BallFactory(this, _ballsData, Resources.Load<Ball>(BallPrefabPath), _ballsCountOnLevel);
    }

    private void Start()
    {
        _selectGameModeMenu.Init(new List<GameMode>()
        {
            new DestroyAllGameMode(_ballFactory.Balls),
            new DestroyAnyColorGameMode(_ballFactory.Balls),
            new DestroyAnyNumberTypeGameMode(_ballFactory.Balls),
            new DestroyAnyNumberGameMode(_ballFactory.Balls, _ballsData.Length),
        });

        _selectGameModeMenu.StartGameButtonPressed += OnStartGameButtonPressed;
    }

    private void OnDestroy()
    {
        _selectGameModeMenu.StartGameButtonPressed -= OnStartGameButtonPressed;
    }

    private void OnStartGameButtonPressed(GameMode chosenMode)
    {
        _targetReachHandler = new TargetReachHandler(chosenMode);

        chosenMode.Init();
        _targetTextDisplay.Init(chosenMode.Target);
        _selectGameModeMenu.gameObject.SetActive(false);

        _ballFactory.StartSpawn(_ballSpawnPosition.position);
    }
}
