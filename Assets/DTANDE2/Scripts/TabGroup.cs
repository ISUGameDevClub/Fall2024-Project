using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;//sprite for when tab is idle
    public Sprite tabActive;//sprite for when tab has been selected
    public Sprite tabHover;//sprite for when tab is being hovered over
    public TabButton selectedTab;//reference for tab selection
    // Start is called before the first frame update
    public void subscribe(TabButton button)
    {
        if (tabButtons == null) { 
        tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.sprite = tabHover;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
        
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.background.sprite = tabActive;

    }

    public void ResetTabs()//resets all tabs to idle
    {
        foreach (TabButton button in tabButtons)
        {
            if(selectedTab != button && button == selectedTab) { continue; }
            button.background.sprite = tabIdle;
        }
    }

   
}
