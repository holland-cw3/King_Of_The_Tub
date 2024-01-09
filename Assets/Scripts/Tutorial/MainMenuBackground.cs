using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class MainMenuBackground : MonoBehaviour
{
    public GameObject water1, water2, water3, water4;
    public float speed = 1f;
    private float resetPosLeft, resetPosRight;



    // Start is called before the first frame update
    void Start()
    {
        resetPosLeft = -1500f;
        resetPosRight = 4300f;
    }

    // Update is called once per frame
    void Update()
    {
        


        water1.transform.Translate(Vector3.left * (speed - 0.1f) * Time.deltaTime);
        water3.transform.Translate(Vector3.left * (speed + 0.1f) * Time.deltaTime);
        water2.transform.Translate(Vector3.right * (speed + 0.1f) * Time.deltaTime);
        water4.transform.Translate(Vector3.right * (speed - 0.1f) * Time.deltaTime);


        if (water1.transform.position.x < resetPosLeft)
        {
            water1.transform.position = new Vector3(resetPosRight, water1.transform.position.y, water1.transform.position.z);
        }
        if (water3.transform.position.x < resetPosLeft)
        {
            water3.transform.position = new Vector3(resetPosRight, water3.transform.position.y, water3.transform.position.z);
        }

        // Check if water2 and water4 have reached the reset position
        if (water2.transform.position.x > resetPosRight)
        {
            water2.transform.position = new Vector3(resetPosLeft, water2.transform.position.y, water2.transform.position.z);
        }
        if (water4.transform.position.x > resetPosRight)
        {
            water4.transform.position = new Vector3(resetPosLeft, water4.transform.position.y, water4.transform.position.z);
        }
    }
}
