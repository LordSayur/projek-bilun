using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : Singleton<GameOver> {

    // public bool isGameOver = false;

    public GameObject gameOverUI;
    public Text playerWonText;

    public void Start() {
        Time.timeScale = 1f;
    }

    public void Trigger(GameObject winner) {
        
        Time.timeScale = 0f;

        // Get the player who won
        // string playerWon = GameObject.FindGameObjectWithTag("Balloon").GetComponentInParent<PlayerInput>().name;
        PlayerManager player = winner.GetComponent<PlayerManager>();
        playerWonText.text = player.playerName + " is the winner!";

        gameOverUI.SetActive(true);
    }

}
