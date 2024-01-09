using System;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Camera mainCamera;
    private Vector3 initialPos;
    private float screenWidth, screenHeight;
    
    //Using magic to determine the exact screen width
    private void Start()
    {
        mainCamera = Camera.main;
        initialPos = mainCamera.transform.position;
        screenHeight = 2f * mainCamera.orthographicSize;
        screenWidth = screenHeight * mainCamera.aspect;
    }

    //
    void Update()
    {
        if (player.transform.position.x > initialPos.x + screenWidth / 2)
        {
            initialPos.x += screenWidth;
            mainCamera.transform.position = initialPos;

        }
        if (player.transform.position.x < initialPos.x - screenWidth / 2)
        {
            initialPos.x -= screenWidth;
            mainCamera.transform.position = initialPos;

        }
        if (player.transform.position.y > initialPos.y + screenHeight / 2)
        {
            initialPos.y += screenHeight;
            mainCamera.transform.position = initialPos;
        }
        if (player.transform.position.y < initialPos.y - screenHeight / 2)
        {
            initialPos.y -= screenHeight;
            mainCamera.transform.position = initialPos;
        }
    }
}
