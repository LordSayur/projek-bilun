using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    // public bool isGameOver = false;

    public GameObject gameOverUI;
    public Text playerWonText;

    public void Trigger() {
        
        Time.timeScale = 0f;

        // Get the player who won
        string playerWon = GameObject.FindGameObjectWithTag("Balloon").GetComponentInParent<PlayerInput>().name;
        playerWonText.text = playerWon + " is the winner!";

        gameOverUI.SetActive(true);



    }

}
