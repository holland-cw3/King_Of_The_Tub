using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private PlayerController playerController;
    public bool facingRight;
    public Rigidbody2D projectileRb;
    public float speed; 
    public float projectileCount;
    public float projectileLife; 
    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        facingRight = playerController.facingRight;
        if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
        if (projectileCount <= 0)
            Destroy(gameObject);


    }

    private void FixedUpdate()
    {
        if(facingRight)
        {
            projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);
        } else
        {
            projectileRb.velocity = new Vector2(-speed, projectileRb.velocity.y);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
