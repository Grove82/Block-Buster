using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private Rigidbody2D body;
	private bool hasStarted;

	void Awake() {
		body = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown (0)) {
				print ("left buttton down");
				body.velocity = new Vector2 (2f, 10f);
				hasStarted = true;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D x) {

		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 02f));

		if (hasStarted) {
			GetComponent<AudioSource> ().Play ();
			GetComponent<Rigidbody2D> ().velocity += tweak;
		}
	}
}
