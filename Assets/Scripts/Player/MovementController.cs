using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 1f;

    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheckA;
    public Transform groundCheckB;
    public LayerMask whatIsGround;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckA.position, groundCheckB.position, whatIsGround);
        rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
