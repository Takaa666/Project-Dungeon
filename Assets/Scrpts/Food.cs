using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Combined Food Item", menuName = "Food Prep/Combined Food Item")]
public class Food : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public Bahan[] ingredients;
}
