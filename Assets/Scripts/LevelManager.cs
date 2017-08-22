using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("Level load requested for: " + name);
		SceneManager.LoadScene(name);
	}

	public void LoadNextLevel() {
		print("Loading next level " + SceneManager.sceneCount + 1);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitRequest() {
		Debug.Log("Quit request submitted.");
		Application.Quit();
	}
}
