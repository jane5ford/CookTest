using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject panel;
    public Text recipe;
    public Text time;
    private List<string> recipes = new List<string>();
    private List<string> isRecipeDone = new List<string>();

    float second;
    float minute;

    private string currentRecipe;

    private void Start()
    {
        panel.SetActive(false);
        recipes.Add("Карбонара: \r\n Ветчина \r\n Чеснок \r\n Сыр Пармезан \r\n Яйца \r\n Сливки \r\n Спагетти \r\n Специи");
        recipes.Add("Болоньезе: \r\n Фарш \r\n Чеснок \r\n Лук \r\n Помидоры \r\n Морковь \r\n Спагетти \r\n Специи \r\n Сыр Пармезан");
    }

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

    public void StopGame()
    {
        Debug.Log("Menu pressed!");
        menu.SetActive(true);
        panel.SetActive(false);
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
