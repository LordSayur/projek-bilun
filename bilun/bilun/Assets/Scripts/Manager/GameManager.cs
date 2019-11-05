using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public List<GameObject> players;
    public int TotalRound = 10;

    public float startWaitDuration = 5f;
    public float endWaitDuration = 5f;

    WaitForSeconds startWait;
    WaitForSeconds endWait;

    GameObject roundWinner = null;
    GameObject gameWinner = null;

    void Start()
    {
        startWait = new WaitForSeconds(startWaitDuration);
        endWait = new WaitForSeconds(endWaitDuration);

        //Spawn all players
        PlayerSpawner.Instance.SpawnPlayers(2);

        //Setup Camera
        CameraController.Instance.SetupCamera();

        //Start game loop
        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop()
    {
        yield return StartCoroutine(StartRound());

        yield return StartCoroutine(InProcessRound());

        yield return StartCoroutine(EndRound());

        if (gameWinner != null)
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            StartCoroutine (GameLoop ());
        }

        yield return null;
    }

    IEnumerator StartRound()
    {
        //Reset players
        ResetAllPlayers ();

        //Disable players
        DisableAllPlayers ();

        //Spawn all pickups
        PickupSpawner.Instance.SpawnPickups();

        //Reset Camera

        //Update UI Round

        // Wait for 5 second before start

        yield return startWait;
    }

    IEnumerator InProcessRound()
    {
        //Enable players
        EnableAllPlayers ();

        //UI CLear

        //Check if one player left go to end
        while (!CheckIfOnePlayerLeft())
        {
            yield return null;
        }
    }

    IEnumerator EndRound()
    {
        //Disable players
        DisableAllPlayers();

        //Get round winner
        roundWinner = null;
        roundWinner = GetRoundWinner ();

        if (roundWinner != null)
        {
            PlayerManager playerManager = roundWinner.GetComponent<PlayerManager>();
            playerManager.roundWin++;
        }

        //Check if game winner
        gameWinner = GetGameWinner ();

        //Update UI

        yield return endWait;

        // Destroy all pickups
        PickupSpawner.Instance.DestroyAllPickups();
    }

    bool CheckIfOnePlayerLeft()
    {
        int playerCount = 0;

        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].activeSelf)
                playerCount++;
        }

        return playerCount <= 1;
    }

    GameObject GetRoundWinner()
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].activeSelf)
                return players[i];
        }

        return null;
    }

    GameObject GetGameWinner()
    {
        for (int i = 0; i < players.Count; i++)
        {
            PlayerManager playerManager = players[i].GetComponent<PlayerManager>();
            if (playerManager.roundWin == TotalRound)
                return players[i];
        }

        return null;
    }

    void ResetAllPlayers ()
    {
        foreach(GameObject player in players)
        {
            PlayerManager playerManager = player.GetComponent<PlayerManager>();
            playerManager.ResetPlayer();
        }
    }

    void EnableAllPlayers ()
    {
        foreach(GameObject player in players)
        {
            PlayerManager playerManager = player.GetComponent<PlayerManager>();
            playerManager.EnablePlayer();
        }
    }

    void DisableAllPlayers ()
    {
        foreach(GameObject player in players)
        {
            PlayerManager playerManager = player.GetComponent<PlayerManager>();
            playerManager.DisablePlayer();
        }
    }
}