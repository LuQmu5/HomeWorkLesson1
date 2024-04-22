﻿using System;
using System.Collections.Generic;

public abstract class GameMode
{
    protected int BallsLeft;

    public string Target { get; protected set; }

    public event Action TargetReached;
    public event Action TargetFailed;

    public GameMode(IReadOnlyCollection<Ball> balls)
    {
    }

    public void Subscribe()
    {
        Ball.Destroyed += OnBallDestroyed;
    }

    protected void OnTargetReached()
    {
        TargetReached?.Invoke();
    }

    protected void OnTargetFailed()
    {
        TargetFailed?.Invoke();
    }

    protected abstract void OnBallDestroyed(BallTypes destroyedBallType);
}
