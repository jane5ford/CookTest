using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject pauseMenu;
    public GameObject gameOver_Menu;
    public GameObject panel;
    public Text recipe;
    public Text time;
    private List<string> recipes = new List<string>();
    private List<string> isRecipeDone = new List<string>();
    public GameObject room;

    public Text resultPers;
    public Text resultTime;

    float second;
    float minute;
    float pauseSecond;
    float pauseMinute;

    private string currentRecipe;

    private void Start()
    {
        panel.SetActive(true);
        recipes.Add("Карбонара: \r\n Ветчина \r\n Чеснок \r\n Сыр Пармезан \r\n Яйца \r\n Сливки \r\n Спагетти \r\n Специи");
        recipes.Add("Болоньезе: \r\n Фарш \r\n Чеснок \r\n Лук \r\n Помидоры \r\n Морковь \r\n Спагетти \r\n Специи \r\n Сыр Пармезан");
        room.SetActive(true);
        menu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOver_Menu.SetActive(false);
        RecipeGeneration();
        Timer();
    }

    public void PlayGame()
    {
        Debug.Log("Продолжить!");
        menu.SetActive(false);
        pauseMenu.SetActive(false);
        panel.SetActive(true);
        room.SetActive(true);
        second = pauseSecond;
        minute = pauseMinute;
    }

    public void Timer()
    {
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

    public void PauseGame()
    {
        Debug.Log("Pause pressed!");
        menu.SetActive(true);
        pauseMenu.SetActive(true);
        panel.SetActive(false);
        room.SetActive(false);
        pauseSecond = second;
        pauseMinute = minute;
    }

    void RunTimer()
    {
        if (gameOver_Menu.activeSelf == false)
        {
            second++;
            if (second == 60)
            {
                second = 0;
                minute++;
            }
        }

        time.text = $"{minute:00} : {second:00}";
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        menu.SetActive(false);
        gameOver_Menu.SetActive(true);
        pauseSecond = second;
        pauseMinute = minute;
        resultTime.text = $"{pauseMinute:00} : {pauseSecond:00}";
    }


    public void EndGamePressed()
    {
        Debug.Log("End game pressed!");
        
        SceneManager.LoadScene("Alina");
    }
}
