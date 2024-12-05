using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemPickupNotifi : MonoBehaviour
{
    public Sprite pickupIcon;
    public int pickupCount;
    [SerializeField] GameObject itemspriteObj;
    [SerializeField] GameObject countTextObj;
    private Image itemSprite;
    private TMP_Text countText;
    private float timeAlive = 0f;
    // Start is called before the first frame update
    void Start()
    {
        itemSprite = itemspriteObj.GetComponent<Image>();
        countText = countTextObj.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        itemSprite.sprite = pickupIcon;
        countText.text = "+" + pickupCount.ToString();
        if (timeAlive >= 5) {
            Destroy(gameObject);
        }
    }
}
