using UnityEngine;

public class MoveToCursor : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private LayerMask layerMask;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        MoveTowardsCursor();
    }

    private void MoveTowardsCursor()
    {
        if (targetTransform == null || mainCamera == null)
            return;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, float.MaxValue, layerMask))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = targetTransform.position.y; // Maintain the same height

            targetTransform.position = Vector3.Lerp(targetTransform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
