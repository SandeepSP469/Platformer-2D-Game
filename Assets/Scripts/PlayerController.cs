using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Animator animator;
	private void Awake()
	{
		Debug.Log("Player controller awake");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collision: " + collision.gameObject.name);
	}

	public void Update()
	{
		float speed = Input.GetAxisRaw("Horizontal");
		animator.SetFloat("Speed", Mathf.Abs(speed));

		Vector3 scale = transform.localScale;
		if (speed < 0)
		{
			scale.x = -1f * Mathf.Abs(scale.x);
		}
		else if (speed > 0)
		{
			scale.x = Mathf.Abs(scale.x);
		}
		transform.localScale = scale;


		void Crouch(bool crouch)
		{
			animator.SetBool("Crouch", crouch);
		}
		{
			if (Input.GetKey(KeyCode.LeftControl))
			{
				Crouch(true);
			}
			else
			{
				Crouch(false);
			}
		}


		float jump = Input.GetAxis("Vertical");

		JumpAnimation(jump);

		void JumpAnimation(float vertical)
		{
			if (vertical > 0)
			{
				animator.SetTrigger("Jump");
			}
		}
	}
}
