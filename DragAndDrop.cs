using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private bool isDragging = false;

    private void Update()
    {
        if (isDragging) transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        isDragging = !isDragging;
    }
}
