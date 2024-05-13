using System.Collections.Generic;
using UnityEngine;

public class BallFactory
{
    private const string BallsDataPath = "StaticData/Balls";
    private const string BallPrefabPath = "BallPrefab";

    private BallData[] _ballsData;
    private Ball _ballPrefab;

    private List<BallData> _ballsDataListTemp = new List<BallData>();

    public BallFactory()
    {
        _ballsData = Resources.LoadAll<BallData>(BallsDataPath);
        _ballPrefab = Resources.Load<Ball>(BallPrefabPath);
    }

    public Ball GetBallWithRandomData()
    {
        if (_ballsDataListTemp.Count == 0)
            _ballsDataListTemp.AddRange(_ballsData);

        int randomIndex = Random.Range(0, _ballsDataListTemp.Count);
        BallData randomBallData = _ballsDataListTemp[randomIndex];
        _ballsDataListTemp.RemoveAt(randomIndex);

        Ball newBall = Object.Instantiate(_ballPrefab);
        newBall.Init(randomBallData);

        return newBall;
    }
}
