using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	 
	public static MusicPlayer instance = null;
	// Use this for initialization

	void Awake() {
		Debug.Log("Music player Awake "+ GetInstanceID());
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}

	void Start () {
		Debug.Log("Music player Start " + GetInstanceID());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
