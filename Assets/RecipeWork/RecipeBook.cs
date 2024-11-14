using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    public Button[] nextBack;
    private int pageNum = 1;
    private bool flip = false;
    private bool flipBack = false;
    public GameObject[] pages;
    // Start is called before the first frame update
    void Start()
    {
        buttons[0].GetComponent<Button>().onClick.AddListener(Plus1);
        buttons[1].GetComponent<Button>().onClick.AddListener(Minus1);
        buttons[2].GetComponent<Button>().onClick.AddListener(Plus2);
        buttons[3].GetComponent<Button>().onClick.AddListener(Minus2);
        book[0].selectedNum = 0;
        book[1].selectedNum = 0;
        nextBack[0].GetComponent<Button>().onClick.AddListener(Next);
        nextBack[1].GetComponent<Button>().onClick.AddListener(Back);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(pageNum == 1 && flip == true)
        {
            pages[0].transform.Rotate(0, 1, 0);
            if (pages[0].GetComponent<RectTransform>().transform.eulerAngles.y > 90)
            {
                pages[1].SetActive(true);
                pages[1].GetComponent<Image>().enabled = true;
            }
            if (pages[0].GetComponent<RectTransform>().transform.eulerAngles.y > 178)
            {
                flip = false;
                pageNum = 2;
                GameObject.Find("RecipeBack").GetComponent<Button>().enabled = true;
            }
        }
        if (pageNum == 2 && flipBack == true)
        {
            pages[0].transform.Rotate(0, -1, 0);
            if (pages[0].GetComponent<RectTransform>().transform.eulerAngles.y < 90)
            {
                pages[1].SetActive(false);
                pages[1].GetComponent<Image>().enabled = false;
            }
            if (pages[0].GetComponent<RectTransform>().transform.eulerAngles.y < 2)
            {
                flipBack = false;
                pageNum = 1;
                GameObject.Find("RecipeBack").GetComponent<Button>().enabled = false;
            }
        }
    }

    void OnEnable()
    {
        if (pageNum == 1) { GameObject.Find("RecipeBack").GetComponent<Button>().enabled = false; }
        inventory = AltInvManager.instance.GetAll();
        tempInventory = inventory;
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

    void Next()
    {
        flip = true;
    }
    void Back()
    {
        flipBack = true;
    }
}
