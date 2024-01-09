using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


public class FadeInOut : MonoBehaviour
{
    
    public Image image;
    private Color imageColor;
    // Start is called before the first frame update
    void Start()
    {
        imageColor = image.color;

    }

    // Update is called once per frame
    void Update()
    {
        imageColor.a = (Mathf.Sin(Time.time * 2f) + 1.0f) / 2.0f;
        image.color = imageColor;
    }
}
