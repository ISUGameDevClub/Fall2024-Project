using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TabGroup tabGroup;
    public Image background;//background image for each tab
    public GameObject[] uiDisable;
    public GameObject[] uiEnable;


    public void OnPointerClick(PointerEventData eventData)
    {
       tabGroup.OnTabSelected(this);
        TurnOffUi();
        TurnOnUi();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }


    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.subscribe(this);
    }

    public void TurnOffUi()
    {
        foreach (GameObject uiObject in uiDisable) 
        { 
            if (uiObject != null)
            {
                uiObject.SetActive(false);
            }
        }
    }

    public void TurnOnUi()
    {
        foreach (GameObject uiObject in uiEnable)
        {
            if (uiObject != null)
            {
                uiObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
