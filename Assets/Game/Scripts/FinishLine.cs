using System;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // Using OnTriggerEnter to change game state when player arrives finish line
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponentInParent<PlayerController>();
        if (player)
        {
            player.finishCam = true;
            player.PlayerSpeedDown();
            //AudioSource.PlayClipAtPoint(GameManager.gameManager.winSound,GameManager.gameManager.player.transform.position,0.5f); // finish olunca çalan ses
            //GameManager.gameManager.winGoldText.text = GameManager.gameManager.goldText.text; // Toplam topladığımız ruh parçacığı
            GameManager.Instance.CurrentGameState = GameManager.GameState.FinishGame;
        }
    }
}
