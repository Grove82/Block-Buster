using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public static int breakableCount = 0;
	public Sprite[] hitSprites;
	public GameObject smoke;

	private int timesHit = 0;
	private LevelManager levelManager;
	private bool isBreakable; 


	void Start () {
		isBreakable = this.tag == "Breakable";
		if (isBreakable) {
			breakableCount++;
		}

		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if(isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits() {
		int maxHits = hitSprites.Length + 1;

		timesHit = timesHit + 1;

		if (timesHit >= maxHits) {
			breakableCount--;
			PuffSmoke ();
			Destroy (gameObject);
			levelManager.BrickDestroyed ();
		} else {
			LoadSprites ();
		}
	}

	void PuffSmoke() {
		smoke.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer> ().color;
		Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
	}

	void LoadSprites() {
		int spriteIndex = timesHit - 1;

		if (hitSprites [spriteIndex] != null) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError ("Brick is missing sprite for index " + spriteIndex);
		}
	}

	// TODO remove this when done 
	void SimulateWin() {
		levelManager.LoadNextLevel ();
	}
}
