using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyAllGameMode : GameMode
{
    public DestroyAllGameMode(IReadOnlyCollection<Ball> balls) : base(balls)
    {
        BallsLeft = balls.Count;
        Target = "Уничтожить все шары";
    }

    protected override void OnBallDestroyed(BallTypes destroyedBallType)
    {
        BallsLeft--;

        if (BallsLeft == 0)
            OnTargetReached();
    }
}
