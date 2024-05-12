using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyAllGameMode : GameMode
{
    public DestroyAllGameMode(string target) : base(target)
    {
    }

    public override void Init(IReadOnlyCollection<Ball> balls)
    {
        BallsLeft = balls.Count;
    }

    protected override void OnBallDestroyed(BallData destroyedBallData)
    {
        BallsLeft--;

        if (BallsLeft == 0)
            OnTargetReached();
    }
}
