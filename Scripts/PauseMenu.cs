using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool IsF12 = true;
    public int n;

    public GameObject optionsMenuUI;
    public GameObject pauseMenuUI;
    public GameObject[] SliderUI;
    public GameObject scaleText;
    public GameObject posText;
    public GameObject fpsText;

    InputManager inputManager;

    void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
    }

    void Update()
    {
        if (inputManager.GetButtonDown("Pause Game"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (inputManager.GetButtonDown("Immersion Mode"))
        {
            if (IsF12)
            {
                Immersion();
            }
            else 
            {
                Normal();    
            }
        }

    }

    public void Immersion()
    {
        for (int i = 0; i < n; i++)
        {
            SliderUI[i].SetActive(false);
        }

        scaleText.SetActive(false);
        posText.SetActive(false);
        fpsText.SetActive(false);

        IsF12 = false;
    }

    public void Normal()
    {
        for (int i = 0; i < n; i++)
        {
            SliderUI[i].SetActive(true);
        }

        scaleText.SetActive(true);
        posText.SetActive(true);
        fpsText.SetActive(true);

        IsF12 = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        for (int i = 0; i < n; i++)
        {
            SliderUI[i].SetActive(true);
        }
        scaleText.SetActive(true);
        posText.SetActive(true);
        fpsText.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        for (int i = 0; i < n; i++)
        {
            SliderUI[i].SetActive(false);
        }
        scaleText.SetActive(false);
        posText.SetActive(false);
        fpsText.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

}
