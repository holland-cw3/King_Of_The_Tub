using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStraightBubble : MonoBehaviour
{
    private Rigidbody2D rb;
    //public Player player;
    public float force;
    private float timer;
    
    public bool shootRight, shootLeft, shootUp;
    private Rigidbody2D rbOrigin;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbOrigin = rb;

        if (shootRight == true )
        {
            Vector3 direction = new Vector3(1, 0);
            rb.velocity = new Vector2(direction.x, 0).normalized * force;
        }
        else if (shootLeft == true)
        {
            Vector3 direction = new Vector3(-1, 0);
            rb.velocity = new Vector2(direction.x, 0).normalized * force;
        }
        else if (shootUp == true)
        {
            Vector3 direction = new Vector3(0, 1);
            rb.velocity = new Vector2(0, direction.y).normalized * force;
        }
        else
        {
            Vector3 direction = new Vector3(0, -1);
            rb.velocity = new Vector2(0, direction.y).normalized * force;
        }
    }

    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player playerHealth = other.GetComponent<Player>();
            if (playerHealth != null)
            {
                playerHealth.takeDamage(50);
            }
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
