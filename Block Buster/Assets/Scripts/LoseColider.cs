using UnityEngine;
using System.Collections;

public class LoseColider : MonoBehaviour {

	private LevelManager levelManager;

	void Start() {
		levelManager = FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D (Collider2D trigger) {
		print ("Trigger 2D!");
		levelManager.LoadLevel ("Lose");

	}

	void OnCollisionEnter2D (Collision2D collision) {
		print ("Collision 2D!");
		levelManager.LoadLevel ("Lose");
	}
}
