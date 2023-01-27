using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Animator animator;
	public ScoreControl scorecounter;
	public float speed;
	private Rigidbody2D rigidbody2d;
	public float jumpvelocity;
	public bool isJumping;
	

    private void Awake()
    {
		rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
    }

	public void Pickupkey()
    {
		Debug.Log("Key picked up");
		scorecounter.increasescore(10);
    }


    private void Update()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		PlayerAnimation(horizontal);
		MoveCharacter(horizontal);
		Jumping();
	}

	private void PlayerAnimation(float horizontal)
	{
		animator.SetFloat("Speed", Mathf.Abs(horizontal));

		Vector3 scale = transform.localScale;
		if (horizontal < 0)
		{
			scale.x = -1f * Mathf.Abs(scale.x);
		}
		else if (horizontal > 0)
		{
			scale.x = Mathf.Abs(scale.x);
		}
		transform.localScale = scale;

	}

	private void MoveCharacter(float horizontal)
	{
		Vector3 position = transform.position;
		position.x = position.x + horizontal * speed * Time.deltaTime;
		transform.position = position;

	}

	private void Jumping()
    {
		if (Input.GetKey(KeyCode.Space) && isJumping)
		{
			animator.SetTrigger("Jump");
			isJumping = false;
			rigidbody2d.AddForce(new Vector2(0f, jumpvelocity), ForceMode2D.Force);
		}
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
			isJumping = true;
        }
    }

}