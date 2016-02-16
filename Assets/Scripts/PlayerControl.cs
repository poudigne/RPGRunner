using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public bool grounded;
    public LayerMask groundLayer;

    private Rigidbody2D body;
    private Collider2D collider;
    private Animator animator;

	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        grounded = Physics2D.IsTouchingLayers(collider, groundLayer);
        body.velocity = new Vector2(moveSpeed, body.velocity.y);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }
        animator.SetFloat("Speed", body.velocity.x);
        animator.SetBool("Grounded", grounded);

    }
}
