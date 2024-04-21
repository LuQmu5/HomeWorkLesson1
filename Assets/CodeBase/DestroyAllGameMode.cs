using System.Collections.Generic;
using System.Linq;

public class DestroyAllGameMode : GameMode
{
    public DestroyAllGameMode(IReadOnlyCollection<Ball> balls) : base(balls)
    {
        Target = "Уничтожить все шары";
    }

    protected override void OnBallDestroyed(BallTypes destroyedBallType)
    {
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
