using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject pauseMenu;
    public GameObject gameOver_Menu;
    public GameObject panel;
    public Text recipe;
    public Text time;
    public GameObject room;

    public Text resultPers;
    public Text resultTime;

    float second;
    float minute;
    float pauseSecond;
    float pauseMinute;

    int numRecipe;
    string file;

    private string currentRecipe;

    private void Start()
    {
        room.SetActive(true);
        menu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOver_Menu.SetActive(false);
        panel.SetActive(true);
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
        numRecipe = Random.Range(1, 3);
        file = Application.dataPath + "/" + numRecipe.ToString() + ".txt";
        string textRec = File.ReadAllText(file);
        recipe.text = textRec;
        //isRecipeDone.Add(currentRecipe);
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
        if (!pauseMenu.activeInHierarchy)
        {
            second++;
            if (second == 60)
            {
                second = 0;
                minute++;
            }
        }

        time.text = $"{minute:00} : {second:00}";
        if (minute == 5f)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        menu.SetActive(true);
        pauseMenu.SetActive(false);
        gameOver_Menu.SetActive(true);
        pauseSecond = second;
        pauseMinute = minute;
        resultTime.text = $"{pauseMinute:00} : {pauseSecond:00}";
    }


    public void EndGamePressed()
    {
        Debug.Log("End game pressed!");
        
        SceneManager.LoadScene("Menu");
    }
}
