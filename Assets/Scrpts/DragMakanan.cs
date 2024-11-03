using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DragMakanan : MonoBehaviour
{
    public Food food;
    public HoverInfoPopup hoverInfoPopup;  // Reference to the HoverInfoPopup script

    private Vector3 originalPosition;
    private bool isDragging;
    private bool isMouseOver;

    private void Start()
    {
        if (food != null)
        {
            // Set sprite of GameObject based on the Food's icon
            GetComponent<SpriteRenderer>().sprite = food.icon;
        }
    }

    private void OnMouseEnter()
    {
        isMouseOver = true;
        // Show popup only if not dragging
        if (hoverInfoPopup != null && food != null && !isDragging)
        {
            Vector3 worldPosition = transform.position;
            hoverInfoPopup.ShowPopup(food, worldPosition);
        }
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
        // Hide popup when mouse exits the object
        if (hoverInfoPopup != null)
        {
            hoverInfoPopup.HidePopup();
        }
    }

    private void OnMouseDown()
    {
        // Hide popup when starting to drag
        if (hoverInfoPopup != null)
        {
            hoverInfoPopup.HidePopup();
        }

        originalPosition = transform.position;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, originalPosition.z);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        // Show popup again if mouse is still over the object after releasing
        if (isMouseOver && hoverInfoPopup != null)
        {
            Vector3 worldPosition = transform.position;
            hoverInfoPopup.ShowPopup(food, worldPosition);
        }

        // Return to original position if dropped in invalid area
        if (!IsValidDropPosition())
        {
            transform.position = originalPosition;
        }
    }

    private bool IsValidDropPosition()
    {
        return true;
    }
}
