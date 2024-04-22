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

    public override void Init()
    {
        Debug.Log("Init");
    }

    protected override void OnBallDestroyed(BallData destroyedBallData)
    {
        BallsLeft--;

        if (BallsLeft == 0)
            OnTargetReached();
    }
}
