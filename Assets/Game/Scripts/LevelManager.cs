using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject lastLevel;

    public int currentLevel;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        // PlayerPrefs.SetInt("DiamondScore", 5000);
         SetLevelPlayerPrefs();
         CallLevel();
    }

    public void SetLevelPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            currentLevel = 1;
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        }
    }


    public void CallLevel()
    {
        if (PlayerPrefs.GetInt("CurrentLevel") == 1)
        {
            currentLevel = 1;
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
            lastLevel.SetActive(false);
            Instantiate(level1);
        }

        if (PlayerPrefs.GetInt("CurrentLevel") == 2)
        {
            currentLevel = 2;
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
            lastLevel.SetActive(false);
            Instantiate(level2);
            Destroy(level1);
        }

        if (PlayerPrefs.GetInt("CurrentLevel") == 3)
        {
            currentLevel = 3;
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
            lastLevel.SetActive(false);
            Instantiate(level3);
            Destroy(level2);
        }

        if (PlayerPrefs.GetInt("CurrentLevel") == 4)
        {
            currentLevel = 4;
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
            lastLevel.SetActive(true);
            Destroy(level3);
        }
    }


    // Reloads the same scene. Using with button
    public void Retry()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    // Loads the next scene. Using with button
    public void NextLevel()
    {
        currentLevel++;
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void Level1Button()
    {
        currentLevel = 1;
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    public void Level2Button()
    {
        currentLevel = 2;
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    public void Level3Button()
    {
        currentLevel = 3;
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}