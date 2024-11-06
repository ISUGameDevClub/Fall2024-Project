using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TabGroup tabGroup;
    public Image background;//background image for each tab

    public void OnPointerClick(PointerEventData eventData)
    {
       tabGroup.OnTabSelected(this);
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

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
