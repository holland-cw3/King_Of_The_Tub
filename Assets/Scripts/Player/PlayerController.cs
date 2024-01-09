using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IDataPersistence
{
    //Private Variables
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] LayerMask groundLayer, beakLayer, enemyLayer, breakLayer;
    [SerializeField] Transform feet, beak;


    public float speed = 10f;
    public float jumpForce = 15f;
    public float gravityModifier;
    private Vector2 movementInput;

    public Animator animator;

    private float jumpCooldown;
    public bool facingRight;

    private bool canFly = true;
    private float flyCooldown = .6f; // The duration of the cooldown in seconds
    private float lastFlyTime = 0f;

    public float KBForce, KBCounter, KBTotalTime;
    public bool KnockFromRight;

    public GameObject playerProjectile;
    public Transform projectilePos;

    public float smashCounter;
    public bool smash;
    public float smashTime;


    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = LayerMask.GetMask("Enemy");
        breakLayer = LayerMask.GetMask("Breakable");
        facingRight = true;
        playerRb = GetComponent<Rigidbody2D>();
        Physics2D.gravity *= gravityModifier;
        smashCounter = 0f;
    }


    public void LoadData(GameData data) 
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }

    public void Update()
    {   
       
        //onMove is setting these values, Update is just ensuring continuous movement.
        float horizontalInput = movementInput.x;
        float verticalInput = movementInput.y;

        //for player animations
        //animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        //CheckGrounded();
        //CheckBeakCollision();
        
        if (KBCounter <= 0)
        {
            if (Time.time - lastFlyTime >= flyCooldown)
            {
                canFly = true;
            }
            // If the vertical input is significant, Jump
            if (verticalInput > 0.5f && canFly)
            {
                Fly();
                canFly = false;
                lastFlyTime = Time.time;

            }
            // Right or left movement input
            if (horizontalInput > 0.5f || horizontalInput < -0.5f)
                moveLeftOrRight(horizontalInput);
        } else
        {
            if (KnockFromRight == true)
            {
                playerRb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                playerRb.velocity = new Vector2(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;
        }
    }

    public void onMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }

    void moveLeftOrRight(float horizInput)
    {
        float movement = horizInput * speed * Time.deltaTime;
        transform.Translate(new Vector3(movement, 0f, 0f));

        
        if (horizInput > 0.5f && !facingRight)
        {
            Flip();
            facingRight = true;
        }
        else if (horizInput < -0.5f && facingRight)
        {
            Flip();
            facingRight = false;
        }
    }

    void Fly()
    {
        playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Breakable" || collision.gameObject.tag == "Enemy") 
        {
            if (Physics2D.OverlapCircle(feet.position, .2f, breakLayer)) {
                Destroy(collision.gameObject);
            }
            if (Physics2D.OverlapCircle(feet.position, .2f, enemyLayer))
            {
                Destroy(collision.gameObject);
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void CheckBeakCollision()
    {
        if (Physics2D.OverlapCircle(beak.position, .2f, enemyLayer))
        {
            //Just testing if it works. It does so whatever we want to do with the beak can be here
            UnityEngine.Debug.Log("Destroy");
        }
    }
}

