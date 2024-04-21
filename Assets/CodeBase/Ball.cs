using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private const float RandomForcePower = 3f;

    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Rigidbody _rigidbody;

    private BallTypes _type;

    public static event UnityAction<BallTypes> Destroyed;

    public void Init(BallData data, Vector3 position)
    {
        _type = data.BallType;
        _meshRenderer.material = data.Material;

        transform.position = position;
        _rigidbody.AddForce(GetRandomForceDirection(), ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
        Destroyed?.Invoke(_type);
        gameObject.SetActive(false);
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
