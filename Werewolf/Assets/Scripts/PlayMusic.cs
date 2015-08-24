using UnityEngine;
using System.Collections;

public class PlayMusic : MonoBehaviour {	

	private AudioSource source;

	private void Start () {
		source = GetComponent<AudioSource>();
		source.Play ();
		source.loop = true;
		DontDestroyOnLoad(gameObject);
	}

	public void PushMusicButton () {
		if (source.isPlaying) {
			source.Pause ();
		} else {
			source.Play ();
		}
	}
}
