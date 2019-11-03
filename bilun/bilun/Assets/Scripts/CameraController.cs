using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // parameters variable
    Vector3 offset;
    [SerializeField] float minZoom = 60f;
    [SerializeField] float maxZoom = 90f;
    [SerializeField] float limitZoom = 50f;

    // reference variable
    private GameObject[] players;
    private Camera mainCamera;
    private Vector3 velocity;
    [SerializeField] private float smoothTime = 0.5f;

    void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        mainCamera = GetComponent<Camera>();
        offset = transform.position - GetCenterPoint(players);
    }

    void LateUpdate()
    {
        UpdateCameraPosition();
        UpdateCameraZoom();

    }

    private void UpdateCameraZoom()
    {
        float newZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance(players) / limitZoom);
        mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, newZoom, Time.deltaTime);
    }

    private void UpdateCameraPosition()
    {
        if (players.Length == 0)
        {
            return;
        }
        Vector3 centerPosition = GetCenterPoint(players);
        Vector3 newPosition = centerPosition + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    private Vector3 GetCenterPoint(GameObject[] players)
    {
        if (players.Length == 1)
        {
            return players[0].transform.position;
        }

        Bounds bounds = GetBounds(players);

        return bounds.center;
    }

    private float GetGreatestDistance(GameObject[] Players)
    {
        Bounds bound = GetBounds(players);

        return bound.size.x;
    }

    private Bounds GetBounds(GameObject[] players)
    {
        var bounds = new Bounds(players[0].transform.position, Vector3.zero);

        foreach (var player in players)
        {
            bounds.Encapsulate(player.transform.position);
        }

        return bounds;
    }
}
