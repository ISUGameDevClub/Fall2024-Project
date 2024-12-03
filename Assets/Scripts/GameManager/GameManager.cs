using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int daysPast {get; private set;}

    [field: SerializeField]
    //public DayNightCycle dayNightSystem {get; private set;}
    public EndDayStats dayStats = new EndDayStats();
    public class EndDayStats {
        public int moneyAccumulated = 0;
        public int yipAccumulate = 0;
        public int customersServed = 0;

        public void clearStats() {
            moneyAccumulated = 0;
            yipAccumulate = 0;
            customersServed = 0;
        }
    }

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

    void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe when this object is disabled or destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
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

    public int CalcuateMoneyCustomersServed(){
        int totalScore = 0;
        List<RecipeUIObj> allRecipes = GetRecipesSelected();
        foreach (RecipeUIObj rb in allRecipes)
        {
            totalScore += rb.recipeObject.selectedNum;
        }
        return totalScore;
    }

    public void ResetRecipeCount(){ 
        List<RecipeUIObj> allRecipes = GetRecipesSelected();
        foreach (RecipeUIObj rb in allRecipes)
        {
            rb.recipeObject.selectedNum = 0;
        }
    }

    public void StartEndDayScene() {
        dayStats.clearStats();
        dayStats.moneyAccumulated = CalcuateMoneyFromRecipes();
        dayStats.yipAccumulate = CalcuateYipFromRecipes();
        dayStats.customersServed = CalcuateMoneyCustomersServed();
        YIP.instance.AddFame(dayStats.yipAccumulate);
        Currency.instance.AddCurrency(dayStats.moneyAccumulated);
        ResetRecipeCount();
        sceneTransition.instance.LoadLevelIndex(3);
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded: " + scene.name);
    }
}
