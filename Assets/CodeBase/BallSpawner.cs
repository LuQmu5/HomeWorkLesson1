using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private int _ballsCountOnLevel = 50;
    [SerializeField] private float _timeBetweenSpawn = 0.1f;

    private BallData[] _ballsData;
    private Ball[] _balls;
    private WaitForSeconds _spawnDelay;

    public void Init(BallData[] ballsData)
    {
        _ballsData = ballsData;
        _balls = new Ball[_ballsCountOnLevel];
        _spawnDelay = new WaitForSeconds(_timeBetweenSpawn);

        for (int i = 0; i < _ballsCountOnLevel; i++)
        {
            Ball newBall = Instantiate(_ballPrefab, transform);
            newBall.gameObject.SetActive(false);
            _balls[i] = newBall;
        }
    }

    public void StartSpawn()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        foreach (Ball ball in _balls)
        {
            ball.gameObject.SetActive(true);
            ball.Init(GetRandomBallData(), transform.position);

            yield return _spawnDelay;
        }
    }

    private BallData GetRandomBallData() => _ballsData[Random.Range(0, _ballsData.Length)];   
}
