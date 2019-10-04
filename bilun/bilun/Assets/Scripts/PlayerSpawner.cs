using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    
    public GameObject[] players;
    private Transform[] spawnPos;

    // players.length < spawnPos.length

    private void Awake() {
        spawnPos = GetComponentsInChildren<Transform>();
    }

    private void Start() {

        if (players.Length < spawnPos.Length) {
            // for now 2, parameter should be passed from player selection in main menu
            SpawnPlayers(2);

        } else {
            Debug.LogError("Not enough player spawn position for the given players size");
        }

    }

    private void SpawnPlayers(int playersJoined) {

        List<int> occupiedPos = new List<int>();

        for (int i = 0; i < playersJoined; i++) {

            int r = 0;

            do {

                r = Random.Range(1, spawnPos.Length);

            } while (occupiedPos.Contains(r));

            occupiedPos.Add(r);

            GameObject clonePlayer = Instantiate(players[i]);
            clonePlayer.transform.position = new Vector3(spawnPos[r].position.x, spawnPos[r].position.y, spawnPos[r].position.z);

        }

        occupiedPos.Clear();

    }

}
