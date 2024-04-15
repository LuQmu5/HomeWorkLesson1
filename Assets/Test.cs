using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    public void CollectPoints(List<Transform> points)
    {
        _points = points;
    }
}
