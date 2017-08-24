using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public static int breakableBrickCount = 0;
	private bool isBreakable;
	public AudioClip crack;
	public Sprite[] hitSprites;
	private int timesHit;
	private LevelManager levelManager;
	public GameObject smoke;

	void Start() {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();;
		isBreakable = (this.tag == "Breakable");
		if(isBreakable) {
			breakableBrickCount++;
		}
	}

	void OnCollisionExit2D() {
		if(isBreakable) {
			AudioSource.PlayClipAtPoint(crack, transform.position);
			HandleHits();
		}
	}

	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;

		if(timesHit >= maxHits) {
			breakableBrickCount--;
			Vector3 brickPos = new Vector3(this.transform.position.x + 0.5f, this.transform.position.y, this.transform.position.z);
			GameObject smokePuff = Instantiate(smoke, brickPos, Quaternion.identity);
			ParticleSystem.MainModule smokePuffMain = smokePuff.GetComponent<ParticleSystem>().main;
			smokePuffMain.startColor = this.GetComponent<SpriteRenderer>().color;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		}
		else {
			LoadSprites();
		}
	}

	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
}
