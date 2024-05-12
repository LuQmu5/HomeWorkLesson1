using System;
using System.Collections.Generic;
using System.Linq;

public class DestroyAnyColorGameMode : GameMode
{
    private BallColors _targetColor;

    public DestroyAnyColorGameMode(string target) : base(target)
    {
    }

    public override void Init(IReadOnlyCollection<Ball> balls)
    {
        var allColors = Enum.GetValues(typeof(BallColors));
        _targetColor = (BallColors)allColors.GetValue(UnityEngine.Random.Range(0, allColors.Length));
        BallsLeft = balls.Where(i => i.Data.Color == _targetColor).Count();
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
