using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerNotificationManager : MonoBehaviour
{
    [SerializeField] GameObject itemNotifiGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPickupNotifi(Sprite itemIcon, int itemCount) {
        GameObject newNoti = Instantiate(itemNotifiGameObject, GetComponent<RectTransform>());
        newNoti.GetComponent<ItemPickupNotifi>().pickupIcon = itemIcon;
        newNoti.GetComponent<ItemPickupNotifi>().pickupCount = itemCount;
    }
}
