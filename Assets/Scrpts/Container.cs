using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public List<Bahan> currentIngredients = new List<Bahan>(); // Daftar bahan yang ada di dalam container
    public Food[] allCombinedFoodItems; // Daftar semua hidangan yang bisa dibuat

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah objek yang masuk memiliki komponen DraggableFood (atau script yang mewakili FoodItem)
        Drag draggableFood = other.GetComponent<Drag>();

        if (draggableFood != null && draggableFood.foodItem != null)
        {
            // Tambahkan FoodItem dari objek yang masuk ke daftar bahan
            AddIngredient(draggableFood.foodItem);

            // Hapus objek makanan dari dunia (opsional)
            Destroy(other.gameObject);
        }
    }

    // Tambahkan bahan ke dalam wadah dan periksa apakah kombinasi sudah sesuai
    private void AddIngredient(Bahan ingredient)
    {
        currentIngredients.Add(ingredient);
        CheckCombination();
    }

    // Memeriksa apakah bahan-bahan dalam wadah sudah membentuk CombinedFoodItem yang ada
    private void CheckCombination()
    {
        foreach (Food combinedItem in allCombinedFoodItems)
        {
            // Cek apakah bahan dalam wadah cocok dengan bahan dalam hidangan jadi
            if (IsCombinationMatch(combinedItem.ingredients))
            {
                CreateCombinedFood(combinedItem);
                ClearContainer();
                break;
            }
        }
    }

    // Periksa apakah bahan dalam wadah cocok dengan bahan yang dibutuhkan
    private bool IsCombinationMatch(Bahan[] requiredIngredients)
    {
        if (currentIngredients.Count != requiredIngredients.Length) return false;

        // Cek apakah setiap bahan yang dibutuhkan ada dalam currentIngredients
        foreach (Bahan ingredient in requiredIngredients)
        {
            if (!currentIngredients.Contains(ingredient))
            {
                return false;
            }
        }

        return true;
    }

    // Buat hidangan jadi dan lakukan tindakan yang diinginkan (misal: tampilkan di UI atau tambahkan ke inventory)
    private void CreateCombinedFood(Food combinedItem)
    {
        Debug.Log("Combined food created: " + combinedItem.itemName);
        // Tambahkan logika di sini untuk memunculkan hidangan jadi di UI atau inventory
    }

    // Hapus semua bahan dalam container setelah membuat hidangan jadi
    private void ClearContainer()
    {
        currentIngredients.Clear();
    }
}
