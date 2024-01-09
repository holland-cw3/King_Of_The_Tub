using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    public float upSpeed, downSpeed;
    public Transform up, down;
    public Sprite upSprite, downSprite;
    public SpriteRenderer artworkSprite;

    private bool isMovingUp;
    private bool isMovingDown;

    private int damage;
    public Player player;
    public PlayerController playerController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && artworkSprite.sprite == downSprite)
        {
            playerController.KBCounter = playerController.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                playerController.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playerController.KnockFromRight = false;
            }
            player.takeDamage(damage);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        damage = 0;
        transform.position = down.position;
        artworkSprite.sprite = downSprite;
        isMovingDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingDown)
        {
            MoveDown();
            if (transform.position.y <= down.position.y)
            {
                isMovingDown = false;
                StartCoroutine(WaitAndMoveUp());
            }
        }
        else if (isMovingUp)
        {
            MoveUp();
            if (transform.position.y >= up.position.y)
            {
                isMovingUp = false;
                StartCoroutine(WaitAndMoveDown());
            }
        }
    }

    void MoveUp()
    {
        transform.position = Vector2.MoveTowards(transform.position, up.position, upSpeed * Time.deltaTime);
    }

    void MoveDown()
    {
        transform.position = Vector2.MoveTowards(transform.position, down.position, downSpeed * Time.deltaTime);
    }

    IEnumerator WaitAndMoveUp()
    {
        
        yield return new WaitForSeconds(1f);
        artworkSprite.sprite = upSprite;
        damage = 0;
        isMovingUp = true;
    }

    IEnumerator WaitAndMoveDown()
    {
        artworkSprite.sprite = downSprite;
        damage = 10;
        yield return new WaitForSeconds(.6f);
        isMovingDown = true;
    }
}
