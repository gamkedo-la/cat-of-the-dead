using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;


    private Rigidbody2D rb;
    private float jumpSpeed = 12f;

    bool isOnGround = false;


    private void Awake()
    {
        instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        PlayerMovement();
    }


    // Update is called once per frame
    void Update()
    {

        int groundMask = ~LayerMask.GetMask("Player"); //detect anything but these 
        isOnGround = Physics2D.OverlapCircleAll(transform.position + Vector3.down * 0.6f, 0.49f, groundMask).Length > 0;

        if(Input.GetKeyDown("space"))
        {
            if (isOnGround)
            {
                rb.velocity += new Vector2(0.0f, jumpSpeed);
            }
        }
    }


    private void PlayerMovement()
    {
        float hSpeed = 0.2f;
        float vSpeed = 0.2f;

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity += new Vector2(hSpeed, 0.0f);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.velocity += new Vector2(-hSpeed, 0.0f);
        }

        if (rb.gravityScale == 0)
        {
            if (Input.GetKey("w") || Input.GetKey("up"))
            {
                rb.velocity += new Vector2(0.0f, vSpeed);
            }
        }
        else if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rb.velocity += new Vector2(0.0f, -vSpeed);
        }
    }








}
