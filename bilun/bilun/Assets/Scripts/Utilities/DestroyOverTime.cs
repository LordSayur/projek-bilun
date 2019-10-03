using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float delayTime = 5f;

    void Start()
    {
        Destroy(this.gameObject, delayTime);
    }

}
