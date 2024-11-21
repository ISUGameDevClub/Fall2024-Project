using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecipeUIObj : MonoBehaviour
{
    public Recipe recipeObject;
    [SerializeField] TMP_Text recipeNameObj;
    [SerializeField] Image recipeIconObj;
    [SerializeField] TMP_Text craftCount;
    [SerializeField] Button addButton;
    [SerializeField] Button subButton;
    // Start is called before the first frame update
    void Start()
    {
        if (recipeObject == null) {
            //Destroy(gameObject);
        }
        recipeNameObj.text = recipeObject.recipeName;
        recipeIconObj.sprite = recipeObject.icon;
        subButton.onClick.AddListener(Subtract);
        addButton.onClick.AddListener(Add);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Add() {
        int recipeIndex = 0;
        foreach (Item item in recipeObject.ingredients) {
            if (!InventoryManager.instance.CheckCanCraft(item, recipeObject.ingredientNum[recipeIndex])) {
                // Player Does not have enough to craft.
                Debug.Log("Not Enoguh");
                return;
            }
            recipeIndex++;
        }
        recipeIndex = 0;
        foreach (Item item in recipeObject.ingredients) {
            InventoryManager.instance.RemoveItem(item, recipeObject.ingredientNum[recipeIndex]);
            recipeIndex++;
        }
        recipeObject.selectedNum++;
        subButton.interactable = true;
        craftCount.text = recipeObject.selectedNum.ToString();
    }

    void Subtract() {
        int recipeIndex = 0;
        foreach (Item item in recipeObject.ingredients) {
            InventoryManager.instance.AddItem(item, recipeObject.ingredientNum[recipeIndex]);
            recipeIndex++;
        }
        recipeObject.selectedNum--;
        if (recipeObject.selectedNum <= 0) {subButton.interactable = false;}
        craftCount.text = recipeObject.selectedNum.ToString();
    }
}
