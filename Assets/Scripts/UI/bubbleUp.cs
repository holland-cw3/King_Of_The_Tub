using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleUp : MonoBehaviour
{
    public GameObject bubble;
    public float speed = 1f;
    private float resetPosTop, resetPosBottom, resetPosLeft, resetPosRight;

  

    void Start()
    {
        resetPosBottom = -18f;
        resetPosTop = -7f;
        resetPosLeft = -14f;
        resetPosRight = 14f;
    }

    void Update()
    {
        bubble.transform.Translate(Vector3.left * speed * Time.deltaTime);

        bubble.transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (bubble.transform.position.y > resetPosTop)
        {
            bubble.transform.position = new Vector3(bubble.transform.position.x, resetPosBottom, bubble.transform.position.z); ;
        }
        if (bubble.transform.position.x < resetPosLeft)
        {
            bubble.transform.position = new Vector3(resetPosRight, bubble.transform.position.y, bubble.transform.position.z);
        }
    }
}
