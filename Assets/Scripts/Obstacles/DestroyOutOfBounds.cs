using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -75)
        {
            Destroy(gameObject);
        }
        /*
        if (transform.position.x < -75)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > 125)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > 20)
        {
            Destroy(gameObject);
        }
        */
    }
}
