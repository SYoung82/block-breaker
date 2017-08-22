using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int maxHits;
	private int timesHit;

	void Start() {
		timesHit = 0;
	}

	void OnCollisionEnter2D() {
		timesHit++;
	}
}
