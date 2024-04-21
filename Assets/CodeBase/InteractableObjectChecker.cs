using System;
using UnityEngine;

public class InteractableObjectChecker : MonoBehaviour
{
    [SerializeField] private float _interactDistance = 10;
    [SerializeField] private InteractMessageDisplay _messageDisplay;

    private void Update()
    {
        if (CheckClosestInteractableObject(out IInteractableObject closestObject) && Input.GetKeyDown(KeyCode.E))
        {
            closestObject.Interact();
        }
    }

    private bool CheckClosestInteractableObject(out IInteractableObject closestObject)
    {
        closestObject = null;
        Vector3 direction = transform.forward;
        Ray ray = new Ray(transform.position, direction);

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

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _interactDistance))
        {
            DrawRay(ray, hitInfo.point, hitInfo.distance, Color.red);
        }
        else
        {
            Vector3 hitPosition = ray.origin + ray.direction * _interactDistance;
            DrawRay(ray, hitPosition, _interactDistance, Color.green);
        }
    }

    private static void DrawRay(Ray ray, Vector3 hitPosition, float distance, Color color)
    {
        const float hitPointRadius = 0.15f;

        Debug.DrawRay(ray.origin, ray.direction * distance, color);

        Gizmos.color = color;
        Gizmos.DrawSphere(hitPosition, hitPointRadius);
    }
#endif
}
