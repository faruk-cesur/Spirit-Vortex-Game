using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance;
    public static Camera Cam;
    private void Awake()
    {
        Instance = this;
        Cam = Camera.main;
    }
    
    // All Variables in GameManager

    public PlayerController player;
    private GameState _currentGameState;
    [SerializeField] private GameObject tapToPlayUI;
    [SerializeField] private GameObject deathScreenUI;
    [SerializeField] private Animator animator;

    
    
   
    
    // Using Game State For Functionality
    public enum GameState
    {
        Prepare,
        MainGame,
        FinishGame,
        GameOver
    }
    
    // Using extra switch for game state to run one time codes.
    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        set
        {
            switch (value)
            {
                case GameState.Prepare:
                    break;
                case GameState.MainGame:
                    break;
                case GameState.FinishGame:
                    break;
                case GameState.GameOver:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }

            _currentGameState = value;
        }
    }
    
    
    // Doing things in update when game state changes
    private void Update()
    
    {
        switch (CurrentGameState)
        {
            case GameState.Prepare:
                tapToPlayUI.SetActive(true);
                deathScreenUI.SetActive(false);
                if (Input.GetMouseButtonDown(0))
                {
                    CurrentGameState = GameState.MainGame;
                }
                break;
            case GameState.MainGame:
                animator.SetBool("MainGame",true);
                tapToPlayUI.SetActive(false);
                player.PlayerMovement();
                
                break;
            case GameState.FinishGame:
                player.PlayerMovement();
                animator.SetBool("MainGame",false);
                animator.SetBool("FinishGame",true);
                player.playerModelRoot.Rotate(Vector3.left*5);
                break;
            case GameState.GameOver:
                deathScreenUI.SetActive(true);
                animator.SetBool("MainGame",false);
                animator.SetBool("GameOver",true);
                break;
            default:
                throw new ArgumentOutOfRangeException();
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
        Scene currentScene = SceneManager.GetActiveScene();
        
        if (SceneManager.sceneCountInBuildSettings > currentScene.buildIndex+1)
        {
            SceneManager.LoadScene(currentScene.buildIndex+1);
        }
        else if (SceneManager.sceneCountInBuildSettings <= currentScene.buildIndex+1)
        {
            return;
        }
    }
}