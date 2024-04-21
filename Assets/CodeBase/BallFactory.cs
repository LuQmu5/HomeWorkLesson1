using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFactory
{
    private const float TimeBetweenSpawn = 0.1f;

    private readonly ICoroutineRunner _coroutineRunner;

    private BallData[] _ballsData;
    private Ball[] _balls;
    private WaitForSeconds _spawnDelay;
    private int _ballsCountOnLevel;

    public IReadOnlyCollection<Ball> Balls => _balls;

    public BallFactory(ICoroutineRunner coroutineRunner, BallData[] ballsData, Ball ballPrefab, int ballsCountOnLevel = 50)
    {
        _ballsCountOnLevel = ballsCountOnLevel;
        _coroutineRunner = coroutineRunner;
        _ballsData = ballsData;
        _balls = new Ball[_ballsCountOnLevel];
        _spawnDelay = new WaitForSeconds(TimeBetweenSpawn);

        for (int i = 0; i < _ballsCountOnLevel; i++)
        {
            Ball newBall = Object.Instantiate(ballPrefab);
            newBall.gameObject.SetActive(false);
            _balls[i] = newBall;
        }
    }

    public void StartSpawn(Vector3 at)
    {
        _coroutineRunner.StartCoroutine(Spawning(at));
    }

    private IEnumerator Spawning(Vector3 at)
    {
        foreach (Ball ball in _balls)
        {
            ball.gameObject.SetActive(true);
            ball.Init(GetRandomBallData(), at);

            yield return _spawnDelay;
        }
    }

    private BallData GetRandomBallData() => _ballsData[Random.Range(0, _ballsData.Length)];   
}
