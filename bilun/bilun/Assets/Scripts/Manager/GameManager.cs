using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public List<GameObject> players;
    public int TotalWin = 10;

    public float startWaitDuration = 5f;
    public float endWaitDuration = 5f;

    WaitForSeconds startWait;
    WaitForSeconds endWait;

    GameObject roundWinner = null;
    GameObject gameWinner = null;

    float countdownBeforeStart = 0f;

    public RoundState roundState = RoundState.Start;

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

    void Update()
    {
        switch(roundState)
        {
            case RoundState.Start:
                countdownBeforeStart -= Time.deltaTime;
                UIManager.Instance.UpdateCountdownUI(countdownBeforeStart);
                break;
            case RoundState.InProcess:
                UIManager.Instance.StopCountdownUI();
                break;
            case RoundState.End:

                break;
        }
    }

    IEnumerator GameLoop()
    {
        yield return StartCoroutine(StartRound());

        yield return StartCoroutine(InProcessRound());

        yield return StartCoroutine(EndRound());

        if (gameWinner != null)
        {
            GameOver.Instance.Trigger(gameWinner);
            // SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            StartCoroutine (GameLoop ());
        }

        yield return null;
    }

    IEnumerator StartRound()
    {
        roundState = RoundState.Start;
        countdownBeforeStart = startWaitDuration;

        //Reset players
        ResetAllPlayers ();

        //Disable players
        DisableAllPlayers ();

        //Spawn all pickups
        PickupSpawner.Instance.SpawnPickups();

        //Reset Camera

        // Wait for 5 second before start

        yield return startWait;
    }

    IEnumerator InProcessRound()
    {
        roundState = RoundState.InProcess;

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
        roundState = RoundState.End;

        //Disable players
        DisableAllPlayers();

        //Get round winner
        roundWinner = null;
        roundWinner = GetRoundWinner ();

        if (roundWinner != null)
        {
            PlayerManager playerManager = roundWinner.GetComponent<PlayerManager>();
            playerManager.roundWin++;

            UIManager.Instance.OpenRoundWinnerUI(playerManager.playerName);
        }

        //Check if game winner
        gameWinner = GetGameWinner ();

        //Update UI

        yield return endWait;

        UIManager.Instance.CloseRoundWinnerUI();

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
            if (playerManager.roundWin == TotalWin)
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

public enum RoundState
{
    Start,
    InProcess,
    End
}