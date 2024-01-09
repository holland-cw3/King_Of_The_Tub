using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingSpikes : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;
    public float distance;
    public bool isFalling = false;

    Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;

        if (isFalling == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);

            Debug.DrawRay(transform.position, Vector2.down*distance, Color.red);

            if(hit.transform != null)
            {
                if (hit.transform.tag == "Player")
                {
                    SpikeManager.Instance.StartCoroutine("SpawnSpike", new Vector2(transform.position.x, transform.position.y));
                    rb.gravityScale = 4;
                    isFalling = true;
                    Destroy(gameObject, 2f);
                }
            }
        }
        
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            boxCollider2D.enabled = false;
            SpikeManager.Instance.player.takeDamage(5);
        } else if (collision.gameObject.tag == "Ground")
        {
            boxCollider2D.enabled = false;
        }
    }
}
