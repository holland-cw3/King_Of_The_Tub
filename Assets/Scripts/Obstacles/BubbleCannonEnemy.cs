using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCannonEnemy : MonoBehaviour
{
    public GameObject bubble;
    public Transform bubblePos;

    //private float timer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ShootCoroutine());
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            shoot();
            yield return new WaitForSeconds(1.6f);
        }
    }

    void shoot()
    {
        Instantiate(bubble, bubblePos.position, Quaternion.identity);
    }
}
