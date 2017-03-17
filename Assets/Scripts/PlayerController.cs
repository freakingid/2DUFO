using UnityEngine;
using System.Collections;

// using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	// public variables show up in properties as editable value
	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody2D rb2d;
	// count of Pickups we have picked up
	private int count;

	void Start ()
	{
		// I think this is assigning SELF to rb2d??
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		winText.text = "";
		SetCountText ();
	}

	// Code for physics actions; checked just before physics-based rendering
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
	}

	/*
	 * Triggers are different from Colliders,
	 * In that they don't actually create a physical collision / stop / bounce.
	 */
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("PickUp")) {
			// Yay, let's disable other
			other.gameObject.SetActive (false);
			// increment count
			count++;
			SetCountText ();
		}
	}

	/*
	 * Update UI count display
	 */
	void SetCountText ()
	{
		// update count
		countText.text = "Count: " + count.ToString ();
		// Game over?
		if (count >= 10) {
			// that is all
			winText.text="You Win!";
		}
	}
}
