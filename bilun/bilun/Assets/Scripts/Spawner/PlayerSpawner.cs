using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Singleton<PlayerSpawner> {
    
    public GameObject[] players;
    private Transform[] spawnPos;

    // players.length < spawnPos.length
    
    public void SpawnPlayers(int playersJoined) {
        if(spawnPos == null)
            spawnPos = GetComponentsInChildren<Transform>();

        if (players.Length < spawnPos.Length) {
            List<int> occupiedPos = new List<int>();

            for (int i = 0; i < playersJoined; i++) {

                int r = 0;

                do {

                    r = Random.Range(1, spawnPos.Length);

                } while (occupiedPos.Contains(r));

                occupiedPos.Add(r);

                GameObject clonePlayer = Instantiate(players[i]);

                clonePlayer.name = players[i].name;

                clonePlayer.transform.position = new Vector3(spawnPos[r].position.x, spawnPos[r].position.y, spawnPos[r].position.z);
                GameManager.Instance.players.Add(clonePlayer);
                PlayerManager playerManager = clonePlayer.GetComponent<PlayerManager>();
                if (playerManager == null)
                    return;
                playerManager.Setup(spawnPos[r]);
            }

            occupiedPos.Clear();

        } else {
            Debug.LogError("Not enough player spawn position for the given players size");
        }
    }
}
