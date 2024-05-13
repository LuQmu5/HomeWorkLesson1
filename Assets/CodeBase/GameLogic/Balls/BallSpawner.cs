using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BallSpawner
{
    private const float TimeBetweenSpawn = 0.1f;

    private readonly CoroutinePerformer _coroutinePerformer;
    private GameManagement _gameManagement;
    private WaitForSeconds _spawnDelay;
    private List<Ball> _balls = new List<Ball>();
    private BallFactory _factory;

    public IReadOnlyCollection<Ball> SpawnedBalls => _balls;

    [Inject]
    public BallSpawner(BallFactory factory, GameManagement gameManagement, CoroutinePerformer coroutinePerformer)
    {
        _spawnDelay = new WaitForSeconds(TimeBetweenSpawn);

        _factory = factory;
        _coroutinePerformer = coroutinePerformer;
        _gameManagement = gameManagement;

        for (int i = 0; i < _gameManagement.BallsCountOnLevel; i++)
        {
            Ball ball = _factory.GetBallWithRandomData();
            ball.gameObject.SetActive(false);
            _balls.Add(ball);
        }

        _coroutinePerformer.StartPerform(Spawning());
    }

    private IEnumerator Spawning()
    {
        foreach (var ball in _balls)
        {
            yield return _spawnDelay;

            ball.gameObject.SetActive(true);
            ball.ApplyRandomFroce(5, false);
        }
    }
}