using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int daysPast {get; private set;}

    [field: SerializeField]
    public DayNightCycle dayNightSystem {get; private set;}

    // Player Stats
    public int customersServed;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
        daysPast = 1;
    }

    // private void OnEnable()
    // {
    //     // Subscribe to the event
    //     dayNightSystem.OnDayFinish += DayFinished;
    // }

    // private void OnDisable()
    // {
    //     // Unsubscribe from the event
    //     dayNightSystem.OnDayFinish -= DayFinished;
    // }

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // private void DayFinished() {
    //     Debug.Log("Day Has Finished");
    // }

    public List<RecipeUIObj> GetRecipesSelected() {
        List<RecipeUIObj> allRecipes = new List<RecipeUIObj>();
        RecipeUIObj[] recipes = FindObjectsOfType<RecipeUIObj>(true);
        foreach (RecipeUIObj rb in recipes)
        {
            if (rb.recipeObject.selectedNum != 0) {
                allRecipes.Add(rb);
            }
        }
        return allRecipes;
    }

    public int CalcuateYipFromRecipes(){
        int totalScore = 0;
        List<RecipeUIObj> allRecipes = GetRecipesSelected();
        foreach (RecipeUIObj rb in allRecipes)
        {
            totalScore += rb.recipeObject.fame * rb.recipeObject.selectedNum;
        }
        return totalScore;
    }

    public int CalcuateMoneyFromRecipes(){
        int totalScore = 0;
        List<RecipeUIObj> allRecipes = GetRecipesSelected();
        foreach (RecipeUIObj rb in allRecipes)
        {
            totalScore += rb.recipeObject.moneyPayout * rb.recipeObject.selectedNum;
        }
        return totalScore;
    }
}
