using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
        Score.score = 0;
	}

	public void StartGameBtn(string newGameLevel) {
		SceneManager.LoadScene(newGameLevel);
	}

	public void ExitGameBtn() {
		Application.Quit();
	}
}
