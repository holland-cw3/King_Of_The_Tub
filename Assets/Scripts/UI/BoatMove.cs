using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    public GameObject boat;
    public float speed = 1f;
    public float rotateSpeed = 1f; // Adjust this to control the rotation speed
    private float resetPosLeft, resetPosRight;
    private bool rotateClockwise = true;
    private float currentRotation = 0f;

    void Start()
    {
        resetPosLeft = -14f;
        resetPosRight = 14f;
    }

    void Update()
    {
        boat.transform.Translate(Vector3.right * speed * Time.deltaTime);

        int rotationDirection = rotateClockwise ? 1 : -1;

        boat.transform.Rotate(Vector3.forward * rotateSpeed * rotationDirection * Time.deltaTime);
        currentRotation += rotateSpeed * rotationDirection * Time.deltaTime;

        if (currentRotation >= 3f || currentRotation <= -3f)
        {
            rotateClockwise = !rotateClockwise;
            currentRotation = Mathf.Clamp(currentRotation, -3f, 3f); 
        }

        if (boat.transform.position.x > resetPosRight)
        {
            boat.transform.position = new Vector3(resetPosLeft, boat.transform.position.y, boat.transform.position.z);
        }
    }
}
