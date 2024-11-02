using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Drag : MonoBehaviour
{
    public Bahan foodItem; // Objek FoodItem yang akan dipasang ke GameObject
    private Vector3 originalPosition;
    private bool isDragging;
    private bool isOverContainer;

    private void Start()
    {
        if (foodItem != null)
        {
            // Set sprite GameObject sesuai icon FoodItem
            GetComponent<SpriteRenderer>().sprite = foodItem.icon;
        }
    }

    private void OnMouseDown()
    {
        // Simpan posisi awal saat pertama di-klik
        originalPosition = transform.position;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Pindahkan objek mengikuti posisi mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, originalPosition.z);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        // Jika posisi drop tidak valid, kembalikan ke posisi awal.
        if (!isOverContainer)
        {
            transform.position = originalPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Jika objek memasuki area dengan tag "Container", set isOverContainer menjadi true
        if (collision.CompareTag("Container"))
        {
            isOverContainer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Jika objek keluar dari area dengan tag "Container", set isOverContainer menjadi false
        if (collision.CompareTag("Container"))
        {
            isOverContainer = false;
        }
    }
}
