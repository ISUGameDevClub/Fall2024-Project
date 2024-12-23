using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Recipe : ScriptableObject
{
    public string recipeName;
    public Item[] ingredients;
    public int[] ingredientNum;
    public int selectedNum;
    public Sprite icon;
    public int fame = 0;
    public int moneyPayout = 0;
}
