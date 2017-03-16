using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// public variables show up in properties as editable value
	public float speed;

	private Rigidbody2D rb2d;

	void Start()
	{
		// I think this is assigning SELF to rb2d??
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Code for physics actions; checked just before physics-based rendering
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
	}
}
