using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyAnyColorGameMode : GameMode
{
    private BallTypes _targetType;

    public DestroyAnyColorGameMode(IReadOnlyCollection<Ball> balls, BallTypes targetType) : base(balls)
    {
        _targetType = targetType;
        Target = $"Уничтожить все {targetType} шары";
        BallsLeft = balls.Where(i => i.Type == targetType).Count();
        Debug.Log(BallsLeft);
    }

    protected override void OnBallDestroyed(BallTypes destroyedBallType)
    {
        if (destroyedBallType != _targetType)
        {
            OnTargetFailed();
            return;
        }

        BallsLeft--;

        if (BallsLeft == 0)
            OnTargetReached();
    }
}
