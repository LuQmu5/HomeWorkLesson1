using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private const float StartRandomForcePower = 3f;

    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Rigidbody _rigidbody;

    public BallData Data { get; private set; }

    public static event UnityAction<BallData> Destroyed;

    public void Init(BallData data)
    {
        Data = data;
        _meshRenderer.material = data.Material;
    }

    private void OnEnable()
    {
        ApplyRandomFroce(StartRandomForcePower, false);
    }

    private void OnMouseDown()
    {
        print(Data.Color);
        print(Data.Number);
        print(Data.NumberType);

        Destroyed?.Invoke(Data);
        gameObject.SetActive(false);
    }

    public void ApplyRandomFroce(float power, bool isUp)
    {
        Vector3 randomVector = new Vector3
        {
            x = Random.Range(-power, power),
            y = Random.Range(-power * System.Convert.ToInt32(!isUp), power * System.Convert.ToInt32(isUp)),
            z = Random.Range(-power, power)
        };

        _rigidbody.AddForce(randomVector, ForceMode.Impulse);
    }
}
