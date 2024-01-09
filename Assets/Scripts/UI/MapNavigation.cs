using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MapNavigation : MonoBehaviour
{
    public GameObject startButton;

   // public Image image;
   // private Color imageColor;


    private Camera mainCamera;
    private Vector3 initialPos;
    private float screenWidth, screenHeight;
    private String sceneName;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        initialPos = mainCamera.transform.position;
        screenHeight = 2f * mainCamera.orthographicSize;
        screenWidth = screenHeight * mainCamera.aspect;
        sceneName = "Tutorial";
       // imageColor = image.color;

    }

    // Update is called once per frame
    public void NavRight()
    {
        if (initialPos.x + screenWidth >= 50)
        {
            initialPos.x = 0;
            mainCamera.transform.position = initialPos;
        }
        else { 
            initialPos.x += screenWidth;
            mainCamera.transform.position = initialPos;
        }
        buttonRedirection();
    }

    

    public void NavLeft()
    {
        if (initialPos.x - screenWidth >= 0)
        {
            initialPos.x -= screenWidth;
            mainCamera.transform.position = initialPos;
        }

        buttonRedirection();
    }

    public void StartLevel()
    {
        
        SceneManager.LoadScene(sceneName);
    }

    private void buttonRedirection()
    {
        int pos = (int)initialPos.x;
        startButton.SetActive(true);
        if (pos == 0)
        {
            UnityEngine.Debug.Log("Prologue");
            sceneName = "Tutorial";
        }
        if (pos == 22)
        {
            UnityEngine.Debug.Log("The Sewers");
            sceneName = "TheSewer";
        }
        if (pos == 44)
        {
            startButton.SetActive(false);
            UnityEngine.Debug.Log("TBD");
            sceneName = "";
        }
        
    }
}
