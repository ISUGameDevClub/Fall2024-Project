// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.UI;


// public class RecipeBook : MonoBehaviour
// {
//     private AltItem[] inventory;
//     private AltItem[] tempInventory;
//     private int[] listPos;
//     //High Quality Meat, Medium Quality Meat, Low Quality Meat, Shrimp, Rice, Wheat, Eggs, Milk, Oil
//     public Recipe[] book;
//     public Button[] buttons;
//     public Button[] nextBack;
//     private int pageNum = 1;
//     private bool flip = false;
//     private bool flipBack = false;
//     public GameObject[] pages;
//     // Start is called before the first frame update
//     void Start()
//     {
//         buttons[0].GetComponent<Button>().onClick.AddListener(Plus1);
//         buttons[1].GetComponent<Button>().onClick.AddListener(Minus1);
//         buttons[2].GetComponent<Button>().onClick.AddListener(Plus2);
//         buttons[3].GetComponent<Button>().onClick.AddListener(Minus2);
//         buttons[4].GetComponent<Button>().onClick.AddListener(Plus3);
//         buttons[5].GetComponent<Button>().onClick.AddListener(Minus3);
//         buttons[6].GetComponent<Button>().onClick.AddListener(Plus4);
//         buttons[7].GetComponent<Button>().onClick.AddListener(Minus4);
//         buttons[8].GetComponent<Button>().onClick.AddListener(Plus5);
//         buttons[9].GetComponent<Button>().onClick.AddListener(Minus5);
//         buttons[10].GetComponent<Button>().onClick.AddListener(Plus6);
//         buttons[11].GetComponent<Button>().onClick.AddListener(Minus6);
//         buttons[12].GetComponent<Button>().onClick.AddListener(Plus7);
//         buttons[13].GetComponent<Button>().onClick.AddListener(Minus7);
//         buttons[14].GetComponent<Button>().onClick.AddListener(Plus8);
//         buttons[15].GetComponent<Button>().onClick.AddListener(Minus8);
//         buttons[16].GetComponent<Button>().onClick.AddListener(Plus9);
//         buttons[17].GetComponent<Button>().onClick.AddListener(Minus9);
//         buttons[18].GetComponent<Button>().onClick.AddListener(Plus10);
//         buttons[19].GetComponent<Button>().onClick.AddListener(Minus10);
//         buttons[20].GetComponent<Button>().onClick.AddListener(Plus11);
//         buttons[21].GetComponent<Button>().onClick.AddListener(Minus11);
//         book[0].selectedNum = 0;
//         book[1].selectedNum = 0;
//         nextBack[0].GetComponent<Button>().onClick.AddListener(Next);
//         nextBack[1].GetComponent<Button>().onClick.AddListener(Back);
//     }
    
//     // Update is called once per frame
//     void Update()
//     {
//         if(pageNum == 1 && flip == true)
//         {
//             pages[0].transform.Rotate(0, 1, 0);
//             pages[2].SetActive(true);
//             if (pages[0].GetComponent<RectTransform>().transform.eulerAngles.y > 90)
//             {
//                 pages[1].SetActive(true);
//                 pages[1].GetComponent<Image>().enabled = true;
//             }
//             if (pages[0].GetComponent<RectTransform>().transform.eulerAngles.y > 178)
//             {
//                 flip = false;
//                 pageNum = 2;
//                 GameObject.Find("RecipeBack").GetComponent<Button>().enabled = true;
//                 GameObject.Find("RecipeNext").GetComponent<Button>().enabled = false;
//             }
//         }
//         if (pageNum == 2 && flipBack == true)
//         {
//             pages[0].transform.Rotate(0, -1, 0);
//             if (pages[0].GetComponent<RectTransform>().transform.eulerAngles.y < 90)
//             {
//                 pages[1].SetActive(false);
//                 pages[1].GetComponent<Image>().enabled = false;
//             }
//             if (pages[0].GetComponent<RectTransform>().transform.eulerAngles.y < 2)
//             {
//                 flipBack = false;
//                 pageNum = 1;
//                 GameObject.Find("RecipeBack").GetComponent<Button>().enabled = false;
//                 GameObject.Find("RecipeNext").GetComponent<Button>().enabled = true;
//             }
//         }
//     }

//     void OnEnable()
//     {
//         if (pageNum == 1) { GameObject.Find("RecipeBack").GetComponent<Button>().enabled = false; }
//         inventory = AltInvManager.instance.GetAll();
//         tempInventory = inventory;
//         for (int i = 0; i < book.Length; i++)
//         {
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity < book[i].ingredientNum[j])
//                 {
//                     buttons[i * 2].GetComponent<Button>().interactable = false;
//                 }
//             }
//         }
//     }
//     void Plus1()
//     {
//         tempInventory[0].quantity -= 1;
//         tempInventory[6].quantity -= 1;
//         book[0].selectedNum++;
//         GameObject.Find("Num1").GetComponent<TMP_Text>().text = book[0].selectedNum.ToString();
//         buttons[1].GetComponent<Button>().interactable = true;

//         for (int i = 0; i < book.Length; i++)
//         {
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity < book[i].ingredientNum[j])
//                 {
//                     buttons[i * 2].GetComponent<Button>().interactable = false;
//                 }
//             }
//         }
//     }
//     void Plus2()
//     {
//         tempInventory[0].quantity -= 1;
//         tempInventory[3].quantity -= 1;
//         tempInventory[6].quantity -= 1;
//         book[1].selectedNum++;
//         GameObject.Find("Num2").GetComponent<TMP_Text>().text = book[1].selectedNum.ToString();
//         buttons[3].GetComponent<Button>().interactable = true;

//         for (int i = 0; i < book.Length; i++)
//         {
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity < book[i].ingredientNum[j])
//                 {
//                     buttons[i * 2].GetComponent<Button>().interactable = false;
//                 }
//             }
//         }
//     }
//     void Plus3()
//     {
//         tempInventory[5].quantity -= 1;
//         tempInventory[6].quantity -= 1;
//         book[2].selectedNum++;
//         GameObject.Find("Num3").GetComponent<TMP_Text>().text = book[2].selectedNum.ToString();
//         buttons[5].GetComponent<Button>().interactable = true;

//         for (int i = 0; i < book.Length; i++)
//         {
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity < book[i].ingredientNum[j])
//                 {
//                     buttons[i * 2].GetComponent<Button>().interactable = false;
//                 }
//             }
//         }
//     }
//     void Plus4()
//     {
//         tempInventory[3].quantity -= 1;
//         tempInventory[4].quantity -= 1;
//         book[3].selectedNum++;
//         GameObject.Find("Num4").GetComponent<TMP_Text>().text = book[3].selectedNum.ToString();
//         buttons[7].GetComponent<Button>().interactable = true;

//         for (int i = 0; i < book.Length; i++)
//         {
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity < book[i].ingredientNum[j])
//                 {
//                     buttons[i * 2].GetComponent<Button>().interactable = false;
//                 }
//             }
//         }
//     }
//     void Plus5()
//     {
//         tempInventory[3].quantity -= 1;
//         tempInventory[4].quantity -= 1;
//         tempInventory[8].quantity -= 1;
//         book[4].selectedNum++;
//         GameObject.Find("Num5").GetComponent<TMP_Text>().text = book[4].selectedNum.ToString();
//         buttons[9].GetComponent<Button>().interactable = true;

//         for (int i = 0; i < book.Length; i++)
//         {
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity < book[i].ingredientNum[j])
//                 {
//                     buttons[i * 2].GetComponent<Button>().interactable = false;
//                 }
//             }
//         }
//     }
//     void Plus6()
//     {
//         tempInventory[6].quantity -= 1;
//         book[5].selectedNum++;
//         GameObject.Find("Num6").GetComponent<TMP_Text>().text = book[5].selectedNum.ToString();
//         buttons[11].GetComponent<Button>().interactable = true;

//         for (int i = 0; i < book.Length; i++)
//         {
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity < book[i].ingredientNum[j])
//                 {
//                     buttons[i * 2].GetComponent<Button>().interactable = false;
//                 }
//             }
//         }
//     }
//     void Plus7()
//     {
//         tempInventory[0].quantity -= 1;
//         book[6].selectedNum++;
//         GameObject.Find("Num7").GetComponent<TMP_Text>().text = book[6].selectedNum.ToString();
//         buttons[13].GetComponent<Button>().interactable = true;

//         for (int i = 0; i < book.Length; i++)
//         {
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity < book[i].ingredientNum[j])
//                 {
//                     buttons[i * 2].GetComponent<Button>().interactable = false;
//                 }
//             }
//         }
//     }
//     void Plus8()
//     {
//         tempInventory[1].quantity -= 1;
//         tempInventory[5].quantity -= 1;
//         book[7].selectedNum++;
//         GameObject.Find("Num8").GetComponent<TMP_Text>().text = book[7].selectedNum.ToString();
//         buttons[5].GetComponent<Button>().interactable = true;

//         for (int i = 0; i < book.Length; i++)
//         {
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity < book[i].ingredientNum[j])
//                 {
//                     buttons[i * 2].GetComponent<Button>().interactable = false;
//                 }
//             }
//         }
//     }
//     void Plus9()
//     {
//         tempInventory[3].quantity -= 1;
//         tempInventory[4].quantity -= 1;
//         tempInventory[6].quantity -= 1;
//         book[8].selectedNum++;
//         GameObject.Find("Num9").GetComponent<TMP_Text>().text = book[8].selectedNum.ToString();
//         buttons[7].GetComponent<Button>().interactable = true;

//         for (int i = 0; i < book.Length; i++)
//         {
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity < book[i].ingredientNum[j])
//                 {
//                     buttons[i * 2].GetComponent<Button>().interactable = false;
//                 }
//             }
//         }
//     }
//     void Plus10()
//     {
//         tempInventory[1].quantity -= 1;
//         tempInventory[4].quantity -= 1;
//         tempInventory[5].quantity -= 1;
//         book[9].selectedNum++;
//         GameObject.Find("Num10").GetComponent<TMP_Text>().text = book[9].selectedNum.ToString();
//         buttons[9].GetComponent<Button>().interactable = true;

//         for (int i = 0; i < book.Length; i++)
//         {
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity < book[i].ingredientNum[j])
//                 {
//                     buttons[i * 2].GetComponent<Button>().interactable = false;
//                 }
//             }
//         }
//     }
//     void Plus11()
//     {
//         tempInventory[2].quantity -= 1;
//         tempInventory[6].quantity -= 1;
//         book[10].selectedNum++;
//         GameObject.Find("Num11").GetComponent<TMP_Text>().text = book[10].selectedNum.ToString();
//         buttons[10].GetComponent<Button>().interactable = true;

//         for (int i = 0; i < book.Length; i++)
//         {
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity < book[i].ingredientNum[j])
//                 {
//                     buttons[i * 2].GetComponent<Button>().interactable = false;
//                 }
//             }
//         }
//     }
//     void Minus1()
//     {
//         tempInventory[0].quantity += 1;
//         tempInventory[6].quantity += 1;
//         book[0].selectedNum--;
//         GameObject.Find("Num1").GetComponent<TMP_Text>().text = book[0].selectedNum.ToString();
//         if (book[0].selectedNum == 0) { buttons[1].GetComponent<Button>().interactable = false; }

//         for (int i = 0; i < book.Length; i++)
//         {
//             int tmpSpot = 0;
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity >= book[i].ingredientNum[j])
//                 {
//                     tmpSpot++;
//                 }
//             }
//             if (tmpSpot == book[i].ingredientIndices.Length) { buttons[i * 2].GetComponent<Button>().interactable = true; }
//         }
//     }
//     void Minus2()
//     {
//         tempInventory[0].quantity += 1;
//         tempInventory[3].quantity += 1;
//         tempInventory[6].quantity += 1;
//         book[1].selectedNum--;
//         GameObject.Find("Num2").GetComponent<TMP_Text>().text = book[1].selectedNum.ToString();
//         if (book[1].selectedNum == 0) { buttons[3].GetComponent<Button>().interactable = false; }

//         for (int i = 0; i < book.Length; i++)
//         {
//             int tmpSpot = 0;
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity >= book[i].ingredientNum[j])
//                 {
//                     tmpSpot++;
//                 }
//             }
//             if (tmpSpot == book[i].ingredientIndices.Length) { buttons[i * 2].GetComponent<Button>().interactable = true; }
//         }
//     }
//     void Minus3()
//     {
//         tempInventory[5].quantity += 1;
//         tempInventory[6].quantity += 1;
//         book[2].selectedNum--;
//         GameObject.Find("Num3").GetComponent<TMP_Text>().text = book[2].selectedNum.ToString();
//         if (book[2].selectedNum == 0) { buttons[5].GetComponent<Button>().interactable = false; }

//         for (int i = 0; i < book.Length; i++)
//         {
//             int tmpSpot = 0;
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity >= book[i].ingredientNum[j])
//                 {
//                     tmpSpot++;
//                 }
//             }
//             if (tmpSpot == book[i].ingredientIndices.Length) { buttons[i * 2].GetComponent<Button>().interactable = true; }
//         }
//     }
//     void Minus4()
//     {
//         tempInventory[3].quantity += 1;
//         tempInventory[4].quantity += 1;
//         book[3].selectedNum--;
//         GameObject.Find("Num4").GetComponent<TMP_Text>().text = book[3].selectedNum.ToString();
//         if (book[3].selectedNum == 0) { buttons[7].GetComponent<Button>().interactable = false; }

//         for (int i = 0; i < book.Length; i++)
//         {
//             int tmpSpot = 0;
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity >= book[i].ingredientNum[j])
//                 {
//                     tmpSpot++;
//                 }
//             }
//             if (tmpSpot == book[i].ingredientIndices.Length) { buttons[i * 2].GetComponent<Button>().interactable = true; }
//         }
//     }
//     void Minus5()
//     {
//         tempInventory[3].quantity += 1;
//         tempInventory[4].quantity += 1;
//         tempInventory[8].quantity += 1;
//         book[4].selectedNum--;
//         GameObject.Find("Num5").GetComponent<TMP_Text>().text = book[4].selectedNum.ToString();
//         if (book[4].selectedNum == 0) { buttons[9].GetComponent<Button>().interactable = false; }

//         for (int i = 0; i < book.Length; i++)
//         {
//             int tmpSpot = 0;
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity >= book[i].ingredientNum[j])
//                 {
//                     tmpSpot++;
//                 }
//             }
//             if (tmpSpot == book[i].ingredientIndices.Length) { buttons[i * 2].GetComponent<Button>().interactable = true; }
//         }
//     }
//     void Minus6()
//     {
//         tempInventory[6].quantity += 1;
//         book[5].selectedNum--;
//         GameObject.Find("Num6").GetComponent<TMP_Text>().text = book[5].selectedNum.ToString();
//         if (book[5].selectedNum == 0) { buttons[11].GetComponent<Button>().interactable = false; }

//         for (int i = 0; i < book.Length; i++)
//         {
//             int tmpSpot = 0;
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity >= book[i].ingredientNum[j])
//                 {
//                     tmpSpot++;
//                 }
//             }
//             if (tmpSpot == book[i].ingredientIndices.Length) { buttons[i * 2].GetComponent<Button>().interactable = true; }
//         }
//     }
//     void Minus7()
//     {
//         tempInventory[0].quantity += 1;
//         book[6].selectedNum--;
//         GameObject.Find("Num7").GetComponent<TMP_Text>().text = book[6].selectedNum.ToString();
//         if (book[6].selectedNum == 0) { buttons[13].GetComponent<Button>().interactable = false; }

//         for (int i = 0; i < book.Length; i++)
//         {
//             int tmpSpot = 0;
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity >= book[i].ingredientNum[j])
//                 {
//                     tmpSpot++;
//                 }
//             }
//             if (tmpSpot == book[i].ingredientIndices.Length) { buttons[i * 2].GetComponent<Button>().interactable = true; }
//         }
//     }
//     void Minus8()
//     {
//         tempInventory[1].quantity += 1;
//         tempInventory[5].quantity += 1;
//         book[7].selectedNum--;
//         GameObject.Find("Num8").GetComponent<TMP_Text>().text = book[7].selectedNum.ToString();
//         if (book[7].selectedNum == 0) { buttons[15].GetComponent<Button>().interactable = false; }

//         for (int i = 0; i < book.Length; i++)
//         {
//             int tmpSpot = 0;
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity >= book[i].ingredientNum[j])
//                 {
//                     tmpSpot++;
//                 }
//             }
//             if (tmpSpot == book[i].ingredientIndices.Length) { buttons[i * 2].GetComponent<Button>().interactable = true; }
//         }
//     }
//     void Minus9()
//     {
//         tempInventory[3].quantity += 1;
//         tempInventory[4].quantity += 1;
//         tempInventory[6].quantity += 1;
//         book[8].selectedNum--;
//         GameObject.Find("Num9").GetComponent<TMP_Text>().text = book[8].selectedNum.ToString();
//         if (book[8].selectedNum == 0) { buttons[17].GetComponent<Button>().interactable = false; }

//         for (int i = 0; i < book.Length; i++)
//         {
//             int tmpSpot = 0;
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity >= book[i].ingredientNum[j])
//                 {
//                     tmpSpot++;
//                 }
//             }
//             if (tmpSpot == book[i].ingredientIndices.Length) { buttons[i * 2].GetComponent<Button>().interactable = true; }
//         }
//     }
//     void Minus10()
//     {
//         tempInventory[1].quantity += 1;
//         tempInventory[4].quantity += 1;
//         tempInventory[5].quantity += 1;
//         book[9].selectedNum--;
//         GameObject.Find("Num10").GetComponent<TMP_Text>().text = book[9].selectedNum.ToString();
//         if (book[9].selectedNum == 0) { buttons[19].GetComponent<Button>().interactable = false; }

//         for (int i = 0; i < book.Length; i++)
//         {
//             int tmpSpot = 0;
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity >= book[i].ingredientNum[j])
//                 {
//                     tmpSpot++;
//                 }
//             }
//             if (tmpSpot == book[i].ingredientIndices.Length) { buttons[i * 2].GetComponent<Button>().interactable = true; }
//         }
//     }
//     void Minus11()
//     {
//         tempInventory[2].quantity += 1;
//         tempInventory[6].quantity += 1;
//         book[10].selectedNum--;
//         GameObject.Find("Num11").GetComponent<TMP_Text>().text = book[10].selectedNum.ToString();
//         if (book[10].selectedNum == 0) { buttons[21].GetComponent<Button>().interactable = false; }

//         for (int i = 0; i < book.Length; i++)
//         {
//             int tmpSpot = 0;
//             for (int j = 0; j < book[i].ingredientIndices.Length; j++)
//             {
//                 if (tempInventory[book[i].ingredientIndices[j]].quantity >= book[i].ingredientNum[j])
//                 {
//                     tmpSpot++;
//                 }
//             }
//             if (tmpSpot == book[i].ingredientIndices.Length) { buttons[i * 2].GetComponent<Button>().interactable = true; }
//         }
//     }
//     void Next()
//     {
//         flip = true;
//     }
//     void Back()
//     {
//         flipBack = true;
//     }
// }
