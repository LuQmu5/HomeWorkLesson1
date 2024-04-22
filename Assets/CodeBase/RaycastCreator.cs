using UnityEngine;

public class RaycastCreator : MonoBehaviour
{
    [SerializeField] private float _forcePower = 5;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider != null)
                {
                    if (hitInfo.collider.TryGetComponent(out Ball ball))
                    {
                        ball.ApplyRandomFroce(_forcePower, true);
                    }
                }
            }
        }
    }
}