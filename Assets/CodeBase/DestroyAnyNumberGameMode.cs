using System.Collections.Generic;
using System.Linq;

public class DestroyAnyNumberGameMode : GameMode
{
    private int _targetNumber;

    public DestroyAnyNumberGameMode(IReadOnlyCollection<Ball> balls, int numbersCount) : base(balls)
    {
        Target = $"Уничтожить все шары с определенным числом";
        _targetNumber = UnityEngine.Random.Range(0, numbersCount);
        BallsLeft = balls.Where(i => i.Data.Number == _targetNumber).Count();
    }

    public override void Init()
    {
        Target = $"Уничтожить все шары с числом {_targetNumber}";
    }

    protected override void OnBallDestroyed(BallData destroyedBallData)
    {
        if (destroyedBallData.Number != _targetNumber)
        {
            OnTargetFailed();
            return;
        }

        BallsLeft--;

        if (BallsLeft == 0)
            OnTargetReached();
    }
}
