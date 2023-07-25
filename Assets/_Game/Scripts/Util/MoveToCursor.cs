using UnityEngine;
/// <summary>
/// This script moves whatever object we have assigned it to, towards the cursor smoothly using a lerp (in world space)
/// </summary>
public class MoveToCursor : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform targetTransform; // Assign the game object to move here
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

        //Don't forget to set the layer mask to "Ground" for objects that the raycast will collide with
        if (Physics.Raycast(ray, out hit, float.MaxValue, layerMask))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = targetTransform.position.y; // Maintain the same height

            targetTransform.position = Vector3.Lerp(targetTransform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
