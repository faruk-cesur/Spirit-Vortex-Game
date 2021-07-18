using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // All Variables
    private float playerSpeed;
    public Camera finishCam;
    
    private void PlayerMovement()
    {
       
    }
    
    private void Update()
    {
        
    }

  
    
    // Player's speed down slowly when reach at finish line
    public void PlayerSpeedDown()
    {
        StartCoroutine(FinishGame());
    }

    // IEnumerator Coroutine to get slow effect
    IEnumerator FinishGame()
    {
        float timer = 0;
        float fixSpeed = playerSpeed;
        while (true)
        {
            timer += Time.deltaTime;
            playerSpeed = Mathf.Lerp(fixSpeed, 0, timer);
            if (timer >= 1f)
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}