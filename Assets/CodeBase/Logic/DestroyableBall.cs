using System;
using UnityEngine;

public class DestroyableBall : DestroyableObstacle
{
    public static event Action<DestroyableBall> Destroyed;

    private void OnDisable()
    {
        Destroyed?.Invoke(this);
    }
}