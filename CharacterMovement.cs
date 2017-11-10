using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

	public float speeed = 1.0f;
	public float jumpSpeed = 0.5f;
	public LayerMask groundLayer;

	private Transform gCheck;
	private float scaleX = 1.0f;
	private float scaleY = 1.0f;

	// Use this for initialization
	void Start ()
	{
		gCheck = transform.FindChild ("GCheck");
		scaleX = this.transform.localScale.x;
		scaleY = this.transform.localScale.y;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		float mSpeed = Input.GetAxis ("Horizontal");
		bool isTouched = Physics2D.OverlapPoint (gCheck.position, groundLayer);

		if (Input.GetKey (KeyCode.Space)) {

			if (isTouched) {
				Debug.Log (Vector2.up * jumpSpeed);
				this.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpSpeed, ForceMode2D.Force);
				isTouched = false;
			}
		}

		if (mSpeed > 0) {
			transform.localScale = new Vector2 (scaleX, scaleY);
		} else if (mSpeed < 0) {
			transform.localScale = new Vector2 (-scaleX, scaleY);
		}

		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (mSpeed * speeed, GetComponent<Rigidbody2D> ().velocity.y);

		
	}
}
