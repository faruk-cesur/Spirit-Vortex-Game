using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using TMPro;
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
    [SerializeField] private GameObject prepareUI;
    [SerializeField] private GameObject mainGameUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject finishGameUI;
    public GameObject shopUI;
    public Animator animator;
    public Transform hand;

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
                    AudioSource.PlayClipAtPoint(player.startSound,Cam.transform.position);
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
                animator.applyRootMotion = true;
                prepareUI.SetActive(true);
                mainGameUI.SetActive(false);
                gameOverUI.SetActive(false);
                finishGameUI.SetActive(false);
                if (Input.GetMouseButtonDown(0))
                {
                    CurrentGameState = GameState.MainGame;
                }
                break;
            case GameState.MainGame:
                mainGameUI.SetActive(true);
                animator.applyRootMotion = false;
                player.transform.rotation = Quaternion.identity;
                animator.SetBool("MainGame",true);
                prepareUI.SetActive(false);
                player.PlayerMovement();
                
                break;
            case GameState.FinishGame:
                player.PlayerMovement();
                animator.SetBool("MainGame",false);
                animator.SetBool("FinishGame",true);
                player.playerModelRoot.Rotate(Vector3.left*5);
                StartCoroutine(FinishGameUIDelay());
                break;
            case GameState.GameOver:
                StartCoroutine(GameOverUIDelay());
                animator.SetBool("MainGame",false);
                animator.SetBool("GameOver",true);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Start()
    {
        StartCoroutine(HandAnimation());
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
    
    IEnumerator GameOverUIDelay()
    {
        yield return new WaitForSeconds(3f);
        gameOverUI.SetActive(true);
    }
    IEnumerator FinishGameUIDelay()
    {
        yield return new WaitForSeconds(2f);
        finishGameUI.SetActive(true);
    }
    
    IEnumerator HandAnimation()
    {
        //-270 90 450
        while (CurrentGameState==GameState.Prepare)
        {
            float timer = 0f;
            Vector3 startPos = hand.localPosition;
            while (true)
            {
                timer += Time.deltaTime*3f;
                hand.localPosition = Vector3.Lerp(startPos,new Vector3(450,hand.localPosition.y,hand.localPosition.z),timer);
                if (timer>=1f)
                {
                    break;
                }
                yield return new WaitForEndOfFrame();
            }
            timer = 0;
            startPos = hand.localPosition;
            while (true)
            {
                timer += Time.deltaTime*3f;
                hand.localPosition = Vector3.Lerp(startPos,new Vector3(90,hand.localPosition.y,hand.localPosition.z),timer);
                if (timer>=1f)
                {
                    break;
                }
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(1f);
            timer = 0;
            startPos = hand.localPosition;
            while (true)
            {
                timer += Time.deltaTime*3f;
                hand.localPosition = Vector3.Lerp(startPos,new Vector3(-270,hand.localPosition.y,hand.localPosition.z),timer);
                if (timer>=1f)
                {
                    break;
                }
                yield return new WaitForEndOfFrame();
            }
            timer = 0;
            startPos = hand.localPosition;
            while (true)
            {
                timer += Time.deltaTime*3f;
                hand.localPosition = Vector3.Lerp(startPos,new Vector3(90,hand.localPosition.y,hand.localPosition.z),timer);
                if (timer>=1f)
                {
                    break;
                }
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(1f);
        }
    }
}