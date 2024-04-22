using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallFactory
{
    private const float TimeBetweenSpawn = 0.1f;

    private readonly ICoroutineRunner _coroutineRunner;
    private WaitForSeconds _spawnDelay;

    private Ball[] _balls;
    private BallData[] _ballsData;
    private List<BallData> _ballsDataListTemp;

    public IReadOnlyCollection<Ball> Balls => _balls;

    public BallFactory(ICoroutineRunner coroutineRunner, BallData[] ballsData, Ball ballPrefab, int ballsCountOnLevel)
    {
        int minLength = ballsData.Length;

        if (ballsCountOnLevel < minLength)
            ballsCountOnLevel = minLength;

        _coroutineRunner = coroutineRunner;
        _spawnDelay = new WaitForSeconds(TimeBetweenSpawn);

        _ballsData = ballsData;
        _balls = new Ball[ballsCountOnLevel];
        _ballsDataListTemp = new List<BallData>();

        for (int i = 0; i < ballsCountOnLevel; i++)
        {
            Ball newBall = Object.Instantiate(ballPrefab);

            _balls[i] = newBall;
            _balls[i].Init(GetRandomBallData());
            _balls[i].gameObject.SetActive(false);
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
            ball.transform.position = at;

            yield return _spawnDelay;
        }
    }

    private BallData GetRandomBallData()
    {
        if (_ballsDataListTemp.Count == 0)
            _ballsDataListTemp.AddRange(_ballsData);

        int randomIndex = Random.Range(0, _ballsDataListTemp.Count);
        BallData randomBallData = _ballsDataListTemp[randomIndex];
        _ballsDataListTemp.RemoveAt(randomIndex);

        return randomBallData;
    }
}
