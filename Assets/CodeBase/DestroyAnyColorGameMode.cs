using System.Collections.Generic;
using UnityEngine;

public class DestroyAnyColorGameMode : GameMode
{
    private BallTypes _targetType;

    public DestroyAnyColorGameMode(IReadOnlyCollection<Ball> balls, BallTypes targetType) : base(balls)
    {
        _targetType = targetType;
        Target = $"Уничтожить все {targetType} шары";
    }

    protected override void OnBallDestroyed(BallTypes destroyedBallType)
    {
        if (destroyedBallType != _targetType)
        {
            OnTargetFailed();
            return;
        }

        bool isAnyBallActive = false;

        foreach (Ball ball in Balls)
        {
            if (ball.gameObject.activeSelf)
            {
                isAnyBallActive = true;
                break;
            }
        }

        if (isAnyBallActive == false)
            OnTargetReached();
    }
}
