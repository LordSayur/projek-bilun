using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public string playerName = "Player 1";
    
    PlayerHealth playerHealth;
    PlayerMovement playerMovement;
    PlayerAttack playerAttack;
    PlayerAction playerAction;

    public int roundWin { get; set; }

    Transform SpawnPointT;

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        playerAction = GetComponent<PlayerAction>();
    }

    public void ResetPlayer()
    {
        playerHealth.Reactivate();

        transform.position = SpawnPointT.position;
        transform.rotation = SpawnPointT.rotation;
    }

    public void DisablePlayer()
    {
        playerMovement.enabled = false;
        playerAttack.enabled = false;
        playerAction.enabled = false;
    }

    public void EnablePlayer()
    {
        playerMovement.enabled = true;
        playerAttack.enabled = true;
        playerAction.enabled = true;
    }

    public void Setup(Transform SpawnPointT)
    {
        this.SpawnPointT = SpawnPointT;
    }
}
