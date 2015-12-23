using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {

	public int jumpHeight;
	public bool canJump;
	public int moveSpeed;

	private bool facingRight = true;

	// Use this for initialization
	void Start () {
		canJump = true;
	}

	// Update is called once per frame
	void Update () {
		float x;
		float y;
		if (Input.GetKeyDown(KeyCode.Space) && canJump) {
			x = GetComponent<Rigidbody2D>().velocity.x;
			GetComponent<Rigidbody2D>().velocity = new Vector2(x, jumpHeight);
			canJump = false;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			y = GetComponent<Rigidbody2D>().velocity.y;
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, y);

			if (facingRight) {
				flip ();
			}
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			y = GetComponent<Rigidbody2D>().velocity.y;
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, y);

			if (!facingRight) {
				flip ();
			}
		}
	}

	void flip () {
		Rigidbody2D rigidBody = GetComponent<Rigidbody2D> ();
		Vector3 flipScale = rigidBody.transform.localScale;
		flipScale.x *= -1;

		rigidBody.transform.localScale = flipScale;

		facingRight = !facingRight;
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.CompareTag("ground")) {
			canJump = true;
		}
	}
		
}