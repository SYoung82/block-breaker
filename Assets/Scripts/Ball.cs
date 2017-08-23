using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	private AudioSource boing;
	void Awake() {

	}
	void Start() {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		boing = GetComponent<AudioSource>();
	}

	void Update() {
		if(!hasStarted) {
			// Lock ball on the paddle if game not started
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Listen for click to start game and launch ball
			if(Input.GetMouseButtonDown(0)) {
				print("Click");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
			}
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		bool breakableBrickCollision = collision.gameObject.name.Contains("Hit"); 
		if(hasStarted && !breakableBrickCollision) {
			boing.Play();
		}
	}
}
