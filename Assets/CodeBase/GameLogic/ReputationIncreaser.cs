using UnityEngine;

public class ReputationIncreaser : MonoBehaviour, IInteractableObject
{
    [SerializeField] private int _reputationIncreaseValue;

    public string InteractMessage { get => $"Press 'E' to increase reputation by {_reputationIncreaseValue}"; }

    public void Interact()
    {
        
    }
}