using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class RecipeUIObj : MonoBehaviour
{
    public Recipe recipeObject;
    [SerializeField] TMP_Text recipeNameObj;
    [SerializeField] Image recipeIconObj;
    [SerializeField] TMP_Text craftCount;
    [SerializeField] Button addButton;
    [SerializeField] Button subButton;
    [SerializeField] Image[] ingredentIcons;
    [SerializeField] TMP_Text[] ingredentCountText;
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
        LoadIngredentUI();
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

    void LoadIngredentUI(){
        foreach (Image ico in ingredentIcons) {
            ico.enabled = false;
        }
        foreach (TMP_Text num in ingredentCountText) {
            num.text = "";
        }
        int recipeIndex = 0;
        foreach (Item item in recipeObject.ingredients) {
            ingredentIcons[recipeIndex].enabled = true;
            ingredentIcons[recipeIndex].sprite = item.icon;
            ingredentCountText[recipeIndex].text = recipeObject.ingredientNum[recipeIndex].ToString();
            recipeIndex++;
        }
    }
}
