using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : Singleton<PickupSpawner>  {

    public GameObject[] weaponMalee;
    public GameObject[] weaponRanged;

    public GameObject[] powerUps;


    private Transform[] spawnPos;
    private List<int> occupiedPos = new List<int>();

    private List<GameObject> spawnPickups = new List<GameObject>();

    public void SpawnPickups() {

        if(spawnPos == null)
            spawnPos = GetComponentsInChildren<Transform>();

        int totalPickups = weaponMalee.Length + weaponRanged.Length + powerUps.Length;
        int totalPos = spawnPos.Length - 1;

        int totalMalee = Mathf.RoundToInt(totalPos * 0.5f);
        int totalRanged = Mathf.RoundToInt(totalPos * 0.3f);
        int totalPowerup = Mathf.RoundToInt(totalPos * 0.2f);

        // Debug.Log(totalMalee + "," + totalRanged +  "," + totalPowerup + "/ " + totalPos);

        if (totalPickups < spawnPos.Length) {

            InstantiateObj(totalMalee, weaponMalee);
            InstantiateObj(totalRanged, weaponRanged);
            InstantiateObj(totalPowerup, powerUps);

            occupiedPos.Clear();

        } else {
            Debug.LogError("Not enough pickup spawn position for the total given pickup size");
        }
    }

    private void InstantiateObj(int totalObj, GameObject[] arrayObj) {
        int r;

        if (totalObj == 0)
            return;

        for (int i = 0; i < totalObj; i++) {

            do {

                r = Random.Range(1, spawnPos.Length);

            } while (occupiedPos.Contains(r));

            occupiedPos.Add(r);

            int randObj = Random.Range(0, arrayObj.Length);

            GameObject cloneObj = Instantiate(arrayObj[randObj]);
            cloneObj.transform.position = new Vector3(spawnPos[r].position.x, spawnPos[r].position.y, spawnPos[r].position.z);
            spawnPickups.Add(cloneObj);
        }
    }

    public void DestroyAllPickups()
    {
        foreach(GameObject pickup in spawnPickups)
            Destroy(pickup);
    }
    
}
