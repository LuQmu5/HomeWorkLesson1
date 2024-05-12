using System.Collections.Generic;
using System.Linq;

public class DestroyAnyNumberGameMode : GameMode
{
    private int _targetNumber;

    public DestroyAnyNumberGameMode(string target) : base(target)
    {
        
    }

    public override void Init(IReadOnlyCollection<Ball> balls)
    {
        _targetNumber = UnityEngine.Random.Range(0, Constants.BallsCount);
        BallsLeft = balls.Where(i => i.Data.Number == _targetNumber).Count();

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
