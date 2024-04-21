﻿using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private const float RandomForcePower = 3f;

    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Rigidbody _rigidbody;

    public BallTypes Type { get; private set; }

    public void Init(BallData data, Vector3 position)
    {
        Type = data.BallType;
        _meshRenderer.material = data.Material;

        transform.position = position;
        _rigidbody.AddForce(GetRandomForceDirection(), ForceMode.Impulse);
    }

    private Vector3 GetRandomForceDirection()
    {
        return new Vector3
        {
            x = Random.Range(-RandomForcePower, RandomForcePower),
            y = Random.Range(-RandomForcePower, 0),
            z = Random.Range(-RandomForcePower, RandomForcePower)
        };
    }
}