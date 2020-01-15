using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;

    private void Start()
    {
        menu.SetActive(true);
    }

    public void PlayPressed()
    {
        Debug.Log("Play pressed!");
        SceneManager.LoadScene("Elliana");
    }

    public void ExitPressed()
    {
        Debug.Log("Exit pressed!");
        Application.Quit();

    }
}
