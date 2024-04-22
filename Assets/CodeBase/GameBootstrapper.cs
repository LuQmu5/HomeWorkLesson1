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

    private BallFactory _ballFactory;
    private TargetReachHandler _targetReachHandler;
    private BallData[] _ballsData;

    private void Awake()
    {
        _ballsData = Resources.LoadAll<BallData>(BallsDataPath);
        _ballFactory = new BallFactory(this, _ballsData, Resources.Load<Ball>(BallPrefabPath));
    }

    private void Start()
    {
        _selectGameModeMenu.Init(new List<GameMode>()
        {
            new DestroyAllGameMode("”ничтожить все шары"),
            new DestroyAnyColorGameMode("”ничтожить шары определенного цвета"),
            new DestroyAnyNumberTypeGameMode("”ничтожить все шары определенного типа числа"),
            new DestroyAnyNumberGameMode("”ничтожить все шары с определенным числом", _ballsData.Length),
        }, _ballsData.Length);

        _selectGameModeMenu.StartGameButtonPressed += OnStartGameButtonPressed;
    }

    private void OnDestroy()
    {
        _selectGameModeMenu.StartGameButtonPressed -= OnStartGameButtonPressed;
    }

    private void OnStartGameButtonPressed(GameMode chosenMode)
    {
        _selectGameModeMenu.gameObject.SetActive(false);

        _ballFactory.Init(_selectGameModeMenu.BallsCountOnLevel);
        chosenMode.Init(_ballFactory.Balls);

        _targetReachHandler = new TargetReachHandler(chosenMode, _ballFactory.Balls);
        _targetTextDisplay.Init(chosenMode.Target);

        _ballFactory.StartSpawn(_ballSpawnPosition.position);
    }
}
