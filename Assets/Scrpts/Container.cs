using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public List<Bahan> currentIngredients = new List<Bahan>(); // List of ingredients in the container
    public Food[] allCombinedFoodItems; // List of all possible combined food items
    public ManaPotion[] manaPotions;
    public SpriteRenderer cauldronSpriteRenderer; // Reference to the SpriteRenderer to change the color

    private void OnTriggerEnter2D(Collider2D other)
    {
        Drag draggableFood = other.GetComponent<Drag>();

        if (draggableFood != null && draggableFood.foodItem != null)
        {
            AddIngredient(draggableFood.foodItem);
            Destroy(other.gameObject);
        }
    }

    // Add ingredient to the container and check the combination
    private void AddIngredient(Bahan ingredient)
    {
        currentIngredients.Add(ingredient);
        CheckCombination();
    }

    // Check if the ingredients match any combined food item
    private void CheckCombination()
    {
        bool matchFound = false;

        foreach (Food combinedItem in allCombinedFoodItems)
        {
            if (IsCombinationMatch(combinedItem.ingredients))
            {
                CreateCombinedFood(combinedItem);
                ClearContainer();
                matchFound = true;
                break;
            }
        }

        if (!matchFound)
        {
            // Change the cauldron color to black to indicate failure
            cauldronSpriteRenderer.color = Color.black;
            Debug.Log("Combination failed! The cauldron turned black.");
        }
        else
        {
            // Reset the cauldron color (if needed)
            cauldronSpriteRenderer.color = Color.white;
        }
    }

    // private void CheckCombinationManaPotion()
    // {
    //     bool matchFound = false;

    //     foreach (ManaPotion manaPotion in manaPotions)
    //     {
    //         if (IsCombinationMatch(manaPotion.ingredients))
    //         {
    //             CreateCombinedManaPotion(manaPotion);
    //             ClearContainer();
    //             matchFound = true;
    //             break;
    //         }
    //     }

    //     if (!matchFound)
    //     {
    //         // Change the cauldron color to black to indicate failure
    //         cauldronSpriteRenderer.color = Color.black;
    //         Debug.Log("Combination failed! The cauldron turned black.");
    //     }
    //     else
    //     {
    //         // Reset the cauldron color (if needed)
    //         cauldronSpriteRenderer.color = Color.white;
    //     }
    // }

    // Check if the ingredients match the required ingredients
    private bool IsCombinationMatch(Bahan[] requiredIngredients)
    {
        if (currentIngredients.Count != requiredIngredients.Length) return false;

        foreach (Bahan ingredient in requiredIngredients)
        {
            if (!currentIngredients.Contains(ingredient))
            {
                return false;
            }
        }

        return true;
    }

    // Create the combined food item
    private void CreateCombinedFood(Food combinedItem)
    {
        Debug.Log("Combined food created: " + combinedItem.itemName);
        // Additional logic for showing the combined food in UI or inventory
    }
    

    // Clear the container after creating a combined food item
    private void ClearContainer()
    {
        currentIngredients.Clear();
    }
}
