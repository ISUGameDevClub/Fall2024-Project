using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageSystem : MonoBehaviour
{
    [SerializeField] Button nextPage;
    [SerializeField] Button lastPage;
    [SerializeField] GameObject[] pages;
    private int pageIndex = 0;
    private int pageCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        nextPage.onClick.AddListener(Next);
        lastPage.onClick.AddListener(Last);
        pageCount = pages.Length - 1;
        foreach(GameObject page in pages) {
            page.active = false;
        }
        pages[0].active = true;
        lastPage.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Next(){
        pages[pageIndex].active = false;
        pages[pageIndex + 1].active = true;
        pageIndex++;
        if (pageCount >= pageIndex) {
            nextPage.interactable = false;
        }
        lastPage.interactable = true;
    }

    void Last() {
        pages[pageIndex].active = false;
        pages[pageIndex - 1].active = true;
        pageIndex--;
        if (pageIndex <= 0) {
            lastPage.interactable = false;
        }
        nextPage.interactable = true;
    }
}
