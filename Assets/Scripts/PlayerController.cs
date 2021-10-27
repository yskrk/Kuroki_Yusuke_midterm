using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	// "public" vals
	[SerializeField] private float speed = 10.0f;
	[SerializeField] private float jumpForce = 500.0f;
	[SerializeField] private float groundCheckRadius = 0.1f;
	[SerializeField] private Transform groundCheckPos;
	[SerializeField] private LayerMask whatIsGround;

	// private vals
	private Rigidbody2D rBody;
	private Animator anim;
	private bool isGrounded = false;
	private bool isDucking = false;
	private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

	// physics
	private void FixedUpdate() {
		float horiz = Input.GetAxis("Horizontal");
		isGrounded = GroundCheck();

		// jump code here
		if (isGrounded && Input.GetAxis("Jump") > 0) {
			rBody.AddForce(new Vector2(0.0f, jumpForce));
			isGrounded = false;
		}

		rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

		// ducking
		if (isGrounded && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))) {
			isDucking = true;
			rBody.velocity = new Vector2(0.0f, 0.0f);
		} else {
			isDucking = false;
		}
		
		// check if the sprite needs to be flipped
		if (isFacingRight && rBody.velocity.x < 0 || !isFacingRight && rBody.velocity.x > 0) {
			Flip();
		}

		// communicate with the animator
		anim.SetFloat("xSpeed", Mathf.Abs(rBody.velocity.x));
		anim.SetFloat("ySpeed", rBody.velocity.y);
		anim.SetBool("isGrounded", isGrounded);
		anim.SetBool("isDucking", isDucking);
	}

	private bool GroundCheck() {
		return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
	}

	private void Flip() {
		Vector3 temp = transform.localScale;
		temp.x *= -1;
		transform.localScale = temp;

		isFacingRight = !isFacingRight;
	}
}