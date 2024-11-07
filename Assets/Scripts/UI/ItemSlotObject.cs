using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlotObject : MonoBehaviour
{
    public Item itemRef;

    private TMP_Text itemText;
    private TMP_Text itemCount;
    private Image imageRef;
    public GameObject itemNameObj;
    public GameObject itemCountObj;
    public GameObject itemImageObj;
    // Start is called before the first frame update
    void Start()
    {
        itemText = itemNameObj.GetComponent<TMP_Text>();
        itemCount = itemCountObj.GetComponent<TMP_Text>();
        imageRef = itemImageObj.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {   
        imageRef.sprite = itemRef.icon;
        itemCount.text = itemRef.quantity.ToString();
        itemText.text = itemRef.itemName.ToString();
    }
}
