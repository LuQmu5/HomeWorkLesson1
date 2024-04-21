using System;
using UnityEngine;

public class InteractableObjectChecker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InteractMessageDisplay _messageDisplay;
    [SerializeField] private float _interactDistance = 10;

    private void Update()
    {
        if (CheckClosestInteractableObject(out IInteractableObject closestObject) && Input.GetKeyDown(KeyCode.E))
        {
            closestObject.Interact(_player);
        }
    }

    private bool CheckClosestInteractableObject(out IInteractableObject closestObject)
    {
        closestObject = null;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _interactDistance))
        {
            Collider hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IInteractableObject interactableObject))
            {
                closestObject = interactableObject;
                _messageDisplay.Show(closestObject.InteractMessage);
            }
        }

        return closestObject != null;
    }
}
