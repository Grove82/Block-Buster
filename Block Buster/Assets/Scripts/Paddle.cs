using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float minx, maxx;
	public bool autoplay = false;
	private Ball ball;
	private bool gameStart = false;


	void Start(){
		ball = GameObject.FindObjectOfType<Ball> ();
		gameStart = true;
	}
	// Update is called once per frame
	void Update () {
		if (gameStart) {
			if (autoplay == false) {
				MoveWithMouse ();
			} else {
				AutoPlay ();
			}
		}
	}

	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3 (transform.position.x, transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minx, maxx);
		transform.position = paddlePos;
	}

	void AutoPlay(){
		Vector3 paddlePos = new Vector3 (0f, transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minx, maxx);
		transform.position = paddlePos;
	}

}
