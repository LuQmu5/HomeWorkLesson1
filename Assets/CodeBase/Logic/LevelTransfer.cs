using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransfer : MonoBehaviour
{
    [SerializeField] private SceneNames _transferTo;

    private bool _triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMove player) && !_triggered)
        {
            AllServices.Container.Single<IGameStateMachine>().Enter<LoadLevelState, string>(_transferTo.ToString());

            _triggered = true;
        }
    }
}
