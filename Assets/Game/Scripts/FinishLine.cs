using System;
using System.Collections;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public AudioSource finishSound;
    
    // Using OnTriggerEnter to change game state when player arrives finish line
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponentInParent<PlayerController>();
        if (player)
        {
            player.finishCam = true;
            player.PlayerSpeedDown();
            finishSound.Play();

            //GameManager.gameManager.winGoldText.text = GameManager.gameManager.goldText.text; // Toplam topladığımız ruh parçacığı
            GameManager.Instance.CurrentGameState = GameManager.GameState.FinishGame;
        }
    }


}
