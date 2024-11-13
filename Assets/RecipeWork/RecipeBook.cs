using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class RecipeBook : MonoBehaviour
{
    private AltItem[] inventory;
    private AltItem[] tempInventory;
    private int[] listPos;
    //High Quality Meat, Medium Quality Meat, Low Quality Meat, Shrimp, Rice, Wheat, Eggs, Milk, Oil
    public Recipe[] book;
    public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons[0].GetComponent<Button>().onClick.AddListener(Plus1);
        buttons[1].GetComponent<Button>().onClick.AddListener(Minus1);
        buttons[2].GetComponent<Button>().onClick.AddListener(Plus2);
        buttons[3].GetComponent<Button>().onClick.AddListener(Minus2);
        book[0].selectedNum = 0;
        book[1].selectedNum = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        inventory = AltInvManager.instance.GetAll();
        tempInventory = inventory;
        tempInventory[0].quantity = 2;
        tempInventory[3].quantity = 1;
        tempInventory[6].quantity = 2;
        for (int i = 0; i < book.Length; i++)
        {
            for (int j = 0; j < book[i].ingredientIndices.Length; j++)
            {
                if (tempInventory[book[i].ingredientIndices[j]].quantity < book[i].ingredientNum[j])
                {
                    buttons[i * 2].GetComponent<Button>().interactable = false;
                }
            }
        }
    }
    void Plus1()
    {
        tempInventory[0].quantity -= 1;
        tempInventory[6].quantity -= 1;
        book[0].selectedNum++;
        GameObject.Find("Num1").GetComponent<TMP_Text>().text = book[0].selectedNum.ToString();
        buttons[1].GetComponent<Button>().interactable = true;

        for (int i = 0; i < book.Length; i++)
        {
            for (int j = 0; j < book[i].ingredientIndices.Length; j++)
            {
                if (tempInventory[book[i].ingredientIndices[j]].quantity < book[i].ingredientNum[j])
                {
                    buttons[i * 2].GetComponent<Button>().interactable = false;
                }
            }
        }
    }
    void Plus2()
    {
        tempInventory[0].quantity -= 1;
        tempInventory[3].quantity -= 1;
        tempInventory[6].quantity -= 1;
        book[1].selectedNum++;
        GameObject.Find("Num2").GetComponent<TMP_Text>().text = book[1].selectedNum.ToString();
        buttons[3].GetComponent<Button>().interactable = true;

        for (int i = 0; i < book.Length; i++)
        {
            for (int j = 0; j < book[i].ingredientIndices.Length; j++)
            {
                if (tempInventory[book[i].ingredientIndices[j]].quantity < book[i].ingredientNum[j])
                {
                    buttons[i * 2].GetComponent<Button>().interactable = false;
                }
            }
        }
    }
    void Minus1()
    {
        tempInventory[0].quantity += 1;
        tempInventory[6].quantity += 1;
        book[0].selectedNum--;
        GameObject.Find("Num1").GetComponent<TMP_Text>().text = book[0].selectedNum.ToString();
        if (book[0].selectedNum == 0) { buttons[1].GetComponent<Button>().interactable = false; }

        for (int i = 0; i < book.Length; i++)
        {
            int tmpSpot = 0;
            for (int j = 0; j < book[i].ingredientIndices.Length; j++)
            {
                if (tempInventory[book[i].ingredientIndices[j]].quantity >= book[i].ingredientNum[j])
                {
                    tmpSpot++;
                }
            }
            if (tmpSpot == book[i].ingredientIndices.Length) { buttons[i * 2].GetComponent<Button>().interactable = true; }
        }
    }
    void Minus2()
    {
        tempInventory[0].quantity += 1;
        tempInventory[3].quantity += 1;
        tempInventory[6].quantity += 1;
        book[1].selectedNum--;
        GameObject.Find("Num2").GetComponent<TMP_Text>().text = book[1].selectedNum.ToString();
        if (book[1].selectedNum == 0) { buttons[3].GetComponent<Button>().interactable = false; }

        for (int i = 0; i < book.Length; i++)
        {
            int tmpSpot = 0;
            for (int j = 0; j < book[i].ingredientIndices.Length; j++)
            {
                if (tempInventory[book[i].ingredientIndices[j]].quantity >= book[i].ingredientNum[j])
                {
                    tmpSpot++;
                }
            }
            if (tmpSpot == book[i].ingredientIndices.Length) { buttons[i * 2].GetComponent<Button>().interactable = true; }
        }
    }
}
