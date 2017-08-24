using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;

	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
	}

	void Update() {
		if(!autoPlay) {
			MoveWithMouse();
		}
		else {
			AutoPlay();
		}
	}

	void MoveWithMouse() {
		float mousePosInBlocks = Mathf.Clamp((Input.mousePosition.x / Screen.width) * 16 - 0.5f, 0f, 15f);
		Vector3 paddlePos = new Vector3(mousePosInBlocks, this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePos;
	}

	void AutoPlay() {
		Vector3 paddlePos = new Vector3(0f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, 0f, 15f);
		this.transform.position = paddlePos;
	}
}
