using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonTracker : MonoBehaviour {

    // Tracks number of ballons in gameplay

    private int totalBalloon;

    private void Start() {
        // Assuming 1 player have 1 balloon

        totalBalloon = GetComponentInChildren<PlayerSpawner>().players.Length;
        
    }

    private void Update() {
        if (totalBalloon <= 1) {
            // GetComponent<GameOver>().Trigger();
        }
    }

    public void BalloonDestroyed() {
        totalBalloon--;
    }

    public void BallonAdded() {
        totalBalloon++;
    }
    
}
