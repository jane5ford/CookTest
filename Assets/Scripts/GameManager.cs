using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject panel;
    public Text recipe;
    public Text time;
    public List<string> recipes = new List<string>();
    private List<string> isRecipeDone = new List<string>();

    float second;
    float minute;

    private string currentRecipe;

    public void GamePlay()
    {
        Debug.Log("Play pressed!");
        menu.SetActive(false);
        panel.SetActive(true);
        RecipeGeneration();
        second = 0;
        minute = 0;
        InvokeRepeating("RunTimer", 1, 1);
    }

    public void RecipeGeneration()
    {
        currentRecipe = recipes[Random.Range(0, recipes.Count)];
        recipe.text = currentRecipe;
        isRecipeDone.Add(currentRecipe);
        //сделать проверку
    }

    void RunTimer()
    {
        second++;
        if (second == 60)
        {
            second = 0;
            minute++;
        }
        time.text = $"{minute:00} : {second:00}";
    }

    public void ExitPressed()
    {
        Debug.Log("Exit pressed!");
        Application.Quit();
    }
}
