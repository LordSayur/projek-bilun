using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
    private void Awake() {
        // For the numbers of players is two, parameter should be passed from player selection in main menu
        GetComponentInChildren<PlayerSpawner>().SpawnPlayers(2);
        GetComponentInChildren<PickupSpawner>().SpawnPickups();
    }
    

}
