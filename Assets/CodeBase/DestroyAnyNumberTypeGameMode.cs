using System;
using System.Collections.Generic;
using System.Linq;

public class DestroyAnyNumberTypeGameMode : GameMode
{
    private BallNumbersType _targetNumberType;

    public DestroyAnyNumberTypeGameMode(IReadOnlyCollection<Ball> balls) : base(balls)
    {
        Target = $"Уничтожить все шары определенного типа числа";
        var allNumbersTypes = Enum.GetValues(typeof(BallNumbersType));
        _targetNumberType = (BallNumbersType)allNumbersTypes.GetValue(UnityEngine.Random.Range(0, allNumbersTypes.Length));
        BallsLeft = balls.Where(i => i.Data.NumberType == _targetNumberType).Count();
    }

    public override void Init()
    {
        Target = $"Уничтожить все шары с {_targetNumberType} типом числа";
    }

    protected override void OnBallDestroyed(BallData destroyedBallData)
    {
        if (destroyedBallData.NumberType != _targetNumberType)
        {
            OnTargetFailed();
            return;
        }

        BallsLeft--;

        if (BallsLeft == 0)
            OnTargetReached();
    }
}
