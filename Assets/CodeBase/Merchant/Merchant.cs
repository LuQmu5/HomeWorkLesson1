using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Merchant : MonoBehaviour, IInteractableObject
{
    public string InteractMessage { get => "Press 'E' to trade"; }

    public void Interact()
    {
        StartTrade();
    }

    protected abstract void StartTrade();
}
