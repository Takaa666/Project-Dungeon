using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Drag : MonoBehaviour
{
    public Bahan foodItem; // Objek FoodItem yang akan dipasang ke GameObject
    private Vector3 originalPosition;
    private bool isDragging;

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

        // Tambahkan logika di sini jika ingin memeriksa posisi drop, 
        // misalnya apakah objek ditempatkan di area tertentu atau wadah.
        // Jika tidak ditempatkan di tempat yang valid, kembalikan ke posisi awal.
        if (!IsValidDropPosition())
        {
            transform.position = originalPosition;
        }
    }

    private bool IsValidDropPosition()
    {
        // Logika untuk memeriksa apakah posisi drop valid.
        // Misalnya: deteksi apakah objek berada di area tertentu atau dekat dengan wadah.
        // Untuk sementara, kembalikan true untuk mengizinkan drop di mana saja.
        return true;
    }
}
