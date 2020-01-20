using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Animator characterAnimator;

    public float originalBaseSpeed { get; private set;  }

    public float baseSpeed = 1f;
    public int actualSpeedLevel = 0;
    public float accelByLevel = 2f;
    public float jumpForce = 1f;

    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheckA;
    public Transform groundCheckB;
    public LayerMask whatIsGround;
    public bool canJump = true;
    public bool canAccel = true;


    // Start is called before the first frame update
    void Start()
    {
        characterAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        originalBaseSpeed = baseSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapArea(groundCheckA.position, groundCheckB.position, whatIsGround);

        rb.velocity = new Vector2(baseSpeed + actualSpeedLevel * accelByLevel , rb.velocity.y);

        characterAnimator.SetBool("isGrounded", isGrounded);
        characterAnimator.SetFloat("speed", (baseSpeed + actualSpeedLevel * accelByLevel)/(originalBaseSpeed + 2 * accelByLevel));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && isGrounded && canJump)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            if (actualSpeedLevel < 2)
                actualSpeedLevel++;
        }

        if (Input.GetKeyDown(KeyCode.Q) && canAccel)
        {
            if (actualSpeedLevel > 0)
                actualSpeedLevel--;
        }
    }
}
