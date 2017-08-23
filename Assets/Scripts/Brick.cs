using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public int maxHits;
	private int timesHit;
	private LevelManager levelManager;

	void Start() {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnCollisionExit2D() {
		timesHit++;
		if(timesHit >= maxHits) {
			Destroy(gameObject);
		}
		else {
			LoadSprites();
		}
	}

	void LoadSprites() {
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
	}
}
