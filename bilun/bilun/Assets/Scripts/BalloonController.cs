using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BalloonController : MonoBehaviour
{
    // parameter variables
    public UnityEvent onHit;

    // reference variables
    private MeshRenderer BalloonMaterial;
    private SphereCollider BalloonCollider;

    void Awake()
    {
        BalloonMaterial = GetComponent<MeshRenderer>();
        BalloonCollider = GetComponent<SphereCollider>();
    }

    private void Start() {
        RandomizeColor();
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     RandomizeColor();
        // }
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     onHit.Invoke();
    // }

    void RandomizeColor(){

        if (BalloonMaterial == null)
            return;

        BalloonMaterial.material.SetColor("_BaseColor", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
    }

    public void DestroyBallon(){
        PlayerHealth player = GetComponentInParent<PlayerHealth>();
        if (player != null)
            player.TakeDamage();

        Destroy(gameObject);
    }
}
