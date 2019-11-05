using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentBalloon = 0;

    public GameObject splashEffect;

    void Awake()
    {
        currentBalloon = GetComponentsInChildren<BalloonController>().Length;
    }

    public void TakeDamage()
    {
        currentBalloon--;

        if (currentBalloon <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (splashEffect != null)
            Instantiate(splashEffect, transform.position + Vector3.up * 0.65f, Quaternion.identity);

        gameObject.SetActive(false);
    }

    public void Reactivate()
    {
        foreach(BalloonController balloon in GetComponentsInChildren<BalloonController>(true))
            balloon.gameObject.SetActive(true);

        currentBalloon = GetComponentsInChildren<BalloonController>().Length;

        gameObject.SetActive(true);
    }
}
