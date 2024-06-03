using UnityEngine;

public class DragAndPlace : MonoBehaviour
{
    private Camera mainCamera;
    private bool isDragging = false;
    private Transform draggedObject;
    private Vector3 offset;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        HandleTouchInput();
        HandleInput();
    }

    void HandleInput()
    {
        // Check for mouse input
        if (Input.GetMouseButtonDown(0)) // Assuming left mouse button for dragging
        {
            TryStartDrag(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            UpdateDrag(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            EndDrag();
        }
    }

    void HandleTouchInput()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Only handle the first touch for simplicity

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Check if the touch started over an object
                    TryStartDrag(touch.position);
                    break;

                case TouchPhase.Moved:
                    // If dragging, update the object's position
                    if (isDragging)
                    {
                        UpdateDrag(touch.position);
                    }
                    break;

                case TouchPhase.Ended:
                    // If dragging, end the drag
                    if (isDragging)
                    {
                        EndDrag();
                    }
                    break;
            }
        }
    }

    void TryStartDrag(Vector2 touchPosition)
    {
        Ray ray = mainCamera.ScreenPointToRay(touchPosition);
        RaycastHit hit;

        // Perform a raycast to check if the touch is over an object
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.CompareTag("Chair"))
            {
                draggedObject = hit.transform;
                offset = hit.point - draggedObject.position;
                isDragging = true;
            }
            else
            {
                draggedObject = null;
            }
        }
    }

    void UpdateDrag(Vector2 touchPosition)
    {
        // Ensure we have a dragged object
        if (draggedObject != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(touchPosition);
            float distance = (draggedObject.position - mainCamera.transform.position).magnitude;

            // Move the object to the new position along the ray
            Vector3 newPosition = ray.GetPoint(distance) - offset;

            draggedObject.position = new Vector3(newPosition.x, newPosition.y, draggedObject.position.z);
        }
    }

    void EndDrag()
    {
        isDragging = false;
    }
}
