using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float initialMoveSpeed = 7f;
    public float maxMoveSpeed = 8f;
    public float accelerationRate = 2f;
    public float initialJumpForce = 10f;
    public float maxJumpTime = 0.25f;
    public float jumpMultiplier = 1.75f;
    public float jumpBufferTime = 0.05f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;

    [Header("Platform Interaction")]
    public float platformCheckRadius = 0.2f;
    public LayerMask platformLayer;

    private Rigidbody2D rb;
    public bool isGrounded { get; private set; }
    private float moveInput;
    private float currentMoveSpeed;
    private bool isJumping;
    private float jumpTimeCounter;
    private float jumpBufferCounter;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentMoveSpeed = initialMoveSpeed;
    }

    void Update()
    {
        SoundManager.Instance.PlaySound3D("Running", transform.position);
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetBool("isJumping", !isGrounded);


        // kontrollera r�relse
        moveInput = Input.GetAxis("Horizontal");

        // Accelerate 
        if (Mathf.Abs(moveInput) > 0)
        {
            currentMoveSpeed = Mathf.Min(currentMoveSpeed + accelerationRate * Time.deltaTime, maxMoveSpeed);
        }
        else
        {
            currentMoveSpeed = initialMoveSpeed;
        }

        rb.velocity = new Vector2(moveInput * currentMoveSpeed, rb.velocity.y);

        // Add this line to flip the sprite based on movement direction
        if (moveInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput) * 2, 2, 1); // Using 2 since your current scale is 2
        }

        //r spelaren p marken?
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // jump buffer handler
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        // start jump if grounded and either jump button just pressed or buffer active
        if ((jumpBufferCounter > 0) && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = maxJumpTime;
            rb.velocity = new Vector2(rb.velocity.x, initialJumpForce);
            jumpBufferCounter = 0;
          
        }

        // continue jump while button is held
        if (Input.GetButton("Jump") && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, initialJumpForce * jumpMultiplier);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        // end jump when button is released
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
          
        }

        // Add this to handle platform dropping
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            StartCoroutine(DisableCollision());
        }
    }

    private IEnumerator DisableCollision()
    {
        // Check if we're standing on a one-way platform
        Collider2D[] platforms = Physics2D.OverlapCircleAll(groundCheck.position, platformCheckRadius, platformLayer);
        
        if (platforms.Length > 0)
        {
            foreach (Collider2D platform in platforms)
            {
                if (platform.GetComponent<PlatformEffector2D>() != null)
                {
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), platform, true);
                    yield return new WaitForSeconds(0.25f);
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), platform, false);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // visa markkontrollens radie i scenen
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
