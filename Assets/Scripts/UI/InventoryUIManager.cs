using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject itemSlotPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable() {
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject); // Destroy each child GameObject
        }
        LoadInventory();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadInventory() {
        List<Item> playerInvi = InventoryManager.instance.GetAll();
        foreach (Item item in playerInvi)
        {
            GameObject newSlot = Instantiate(itemSlotPrefab);
            newSlot.transform.SetParent(this.transform);
            newSlot.GetComponent<ItemSlotObject>().itemRef = item;
        }
    }
}
