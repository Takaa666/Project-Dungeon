using UnityEngine;

public class Customer : MonoBehaviour
{
    public OrderList orderList; // Drag dan drop OrderList di sini
    public Food currentOrder;

    void GenerateRandomOrder()
    {
        if (orderList.availableOrders.Length > 0)
        {
            // Ambil pesanan secara acak dari daftar CombinedFoodItem
            int randomIndex = Random.Range(0, orderList.availableOrders.Length);
            currentOrder = orderList.availableOrders[randomIndex];

            // Tampilkan pesanan ini ke UI atau teks
            DisplayOrder(currentOrder);
        }
    }

    public bool CheckOrder(Food servedItem)
    {
        if (servedItem == currentOrder)
        {
            Debug.Log("Correct Order! Customer is happy.");
            Destroy(gameObject);
            return true;
        }
        else
        {
            Debug.Log("Wrong Order! Customer is unhappy.");
            return false;
        }
    }

    void DisplayOrder(Food order)
    {
        // Misalnya, tampilkan nama dan gambar hidangan di UI
        Debug.Log("Customer ordered: " + order.itemName);
    }

    // Anda bisa memanggil fungsi ini setiap kali customer baru muncul
    void Start()
    {
        GenerateRandomOrder();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DragMakanan dragMakanan = collision.GetComponent<DragMakanan>();
        if (dragMakanan != null && dragMakanan.food == currentOrder)
        {
            CheckOrder(dragMakanan.food);
        }
    }
}
