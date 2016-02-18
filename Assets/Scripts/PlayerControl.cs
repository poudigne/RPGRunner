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
    public GameController gameController;
    public AudioSource jumpSound;
    public AudioSource deathSound;

    private Rigidbody2D body;
    private Animator animator;
    private float jumpTimeCounter;
    private float speedMilestoneCount;

    private float speedStore;
    private float speedMilestoneCountStore;
    private float speedIncMilestoneStore;
    private bool stoppedJumping;
    private bool canDoubleJump;
    // Use this for initialization
    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncMilestone;

        speedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncMilestoneStore = speedIncMilestone;
        stoppedJumping = true;
        canDoubleJump = true;
        jumpSound.volume = 0.4f;
        deathSound.volume = 0.4f;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Time.timeScale < 1)
            return;
        //grounded = Physics2D.IsTouchingLayers(collider, groundLayer);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncMilestone;
            speedIncMilestone = speedIncMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }
        body.velocity = new Vector2(moveSpeed, body.velocity.y);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            if (grounded)
            {
                body.velocity = new Vector2(body.velocity.x, jumpForce);
                stoppedJumping = false;
                jumpSound.Play();
            }
            if (!grounded && canDoubleJump)
            {
                canDoubleJump = false;
                stoppedJumping = false;
                body.velocity = new Vector2(body.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                jumpSound.Play();
            }
        }
        if((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)
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
            stoppedJumping = true;
        }
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }

        animator.SetFloat("Speed", body.velocity.x);
        animator.SetBool("Grounded", grounded);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "KillBox")
        {
            
            deathSound.Play();
            gameController.RestartGame();
            moveSpeed = speedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncMilestone = speedIncMilestoneStore;
        }
    }
}
