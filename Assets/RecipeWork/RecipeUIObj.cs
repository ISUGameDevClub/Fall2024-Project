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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Add() {

    }

    void Subtract() {

    }
}
