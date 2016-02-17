using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed;
    public float speedMultiplier;
    public float speedIncMilestone;
    public float jumpForce;
    public float jumpTime;

    public bool grounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    
    private Rigidbody2D body;
    private Animator animator;
    private float jumpTimeCounter;
    private float speedMilestoneCount;
    // Use this for initialization
    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncMilestone;
    }

    // Update is called once per frame
    void Update ()
    {
        //grounded = Physics2D.IsTouchingLayers(collider, groundLayer);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncMilestone;
            speedIncMilestone = speedIncMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }
        body.velocity = new Vector2(moveSpeed, body.velocity.y);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if(jumpTimeCounter > 0.0f)
            {
                body.velocity = new Vector2(body.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
        }
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
        }

        animator.SetFloat("Speed", body.velocity.x);
        animator.SetBool("Grounded", grounded);

    }
}
