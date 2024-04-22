using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyAnyColorGameMode : GameMode
{
    private BallColors _targetColor;

    public DestroyAnyColorGameMode(IReadOnlyCollection<Ball> balls) : base(balls)
    {
        Target = $"Уничтожить все шары определенного цвета";
        var allColors = Enum.GetValues(typeof(BallColors));
        _targetColor = (BallColors)allColors.GetValue(UnityEngine.Random.Range(0, allColors.Length));
        BallsLeft = balls.Where(i => i.Data.Color == _targetColor).Count();
    }

    public override void Init()
    {
        Target = $"Уничтожить все шары {_targetColor} цвета";
    }

    protected override void OnBallDestroyed(BallData destroyedBallData)
    {
        if (destroyedBallData.Color != _targetColor)
        {
            OnTargetFailed();
            return;
        }

        BallsLeft--;

        if (BallsLeft == 0)
            OnTargetReached();
    }
}
