using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text scoreText;
	public Text restartText;
	public Text gameOverText;
	private bool restart;
	private bool gameOver;
	private int score;

	void Start () {
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update () {
		if (restart && Input.GetKeyDown (KeyCode.R) ) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Instantiate (hazard, SpawnPoint (), Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void GameOver() {
		gameOverText.text = "Game Over";
		gameOver = true;
	}

	public void AddScore (int value) {
		score += value;
		UpdateScore ();
	}

	void UpdateScore () {
		scoreText.text = "Score: " + score;
	}

	Vector3 SpawnPoint () {
		return new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
	}
}
