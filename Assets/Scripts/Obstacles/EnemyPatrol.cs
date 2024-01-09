using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    public float speed;
    Vector3 targetPos;

    public GameObject paths;
    public Transform[] pathPoints;
    int pointIndex;
    int pointCount;
    int direction = 1;

    public float waitDuration;
    int speedMultiplier = 1;

    private void Awake()
    {
        pathPoints = new Transform[paths.transform.childCount];
        for (int i = 0; i < paths.gameObject.transform.childCount; i++)
        {
            pathPoints[i] = paths.transform.GetChild(i).gameObject.transform;
        }
    }

    private void Start()
    {
        pointCount = pathPoints.Length;
        pointIndex = 1;
        targetPos = pathPoints[pointIndex].transform.position;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        var step = speedMultiplier * speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        if (direction > 5)
        {
            if (transform.position == targetPos)
            {
                NextPoint();
            }
        }
    }

    void NextPoint()
    {
        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }

        if (pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;
        targetPos = pathPoints[pointIndex].transform.position;
        if (targetPos.x == pathPoints[pointIndex - 1].transform.position.x && targetPos.y < pathPoints[pointIndex - 1].transform.position.y)
        {
            gameObject.transform.Rotate(0, 0, 90);
        } 
        if (targetPos.x > pathPoints[pointIndex - 1].transform.position.x && targetPos.y == pathPoints[pointIndex - 1].transform.position.y)
        {
            gameObject.transform.Rotate(0, 0, 90);
        }
        if (targetPos.x == pathPoints[pointIndex - 1].transform.position.x && targetPos.y > pathPoints[pointIndex - 1].transform.position.y)
        {
            gameObject.transform.Rotate(0, 0, 90);
        }
        if (targetPos.x < pathPoints[pointIndex - 1].transform.position.x && targetPos.y == pathPoints[pointIndex - 1].transform.position.y)
        {
            gameObject.transform.Rotate(0, 0, 90);
        }
        StartCoroutine(waitNextPoint());
    }

    IEnumerator waitNextPoint()
    {
        speedMultiplier = 0;
        yield return new WaitForSeconds(waitDuration);
        speedMultiplier = 1;
    }
}
