using UnityEngine;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private Transform[] _shootPoints;

    public Transform[] ShootPoints => _shootPoints;

    public void PerformShot()
    {
        Debug.Log("Pah!");
    }

    public void Reload()
    {
        Debug.Log("Reloading");
    }
}