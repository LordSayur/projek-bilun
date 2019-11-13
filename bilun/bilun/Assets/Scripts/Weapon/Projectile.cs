using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Balloon"))
        {
            BalloonController balloon = other.GetComponent<BalloonController>();
            balloon.DestroyBallon();
        }
        Destroy(gameObject);
    }
}
