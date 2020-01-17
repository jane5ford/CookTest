using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameMan : MonoBehaviour
{
    public GameObject menu;
    public GameObject pauseMenu;
    public GameObject gameOver_Menu;
    public GameObject panel;
    public Text recipe;
    public Text time;
    public GameObject room;

    public GameObject player;

    public Text resultPers;
    public Text resultTime;

    float second;
    float minute;
    float pauseSecond;
    float pauseMinute;
    int _result;

    [SerializeField]
    GameObject PanTrig;

    [SerializeField]
    private Image ind;

    [SerializeField]
    PanCooking pc;

    public int numRecipe;
    string file;

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

    private void Update()
    {
        if (ind.fillAmount == 1f)
        {
            PauseGame();
            GameOver();
        }
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
        pc.SetRecipe(numRecipe);
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
        if (minute == 4f)
        {
            PauseGame();
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        room.SetActive(false);
        menu.SetActive(true);
        pauseMenu.SetActive(false);
        gameOver_Menu.SetActive(true);
        resultTime.text = "Время готовки: " + $"{pauseMinute:00} : {pauseSecond:00}";
        _result = Mathf.RoundToInt(PanTrig.GetComponent<PanCooking>().result);
        resultPers.text = "Качество блюда: " + _result.ToString() + " %";
    }


    public void EndGamePressed()
    {
        Debug.Log("End game pressed!");
        Destroy(player);
        SceneManager.LoadScene("Menu");
    }

    public int GetRecipe()
    {
        return numRecipe;
    }
}
