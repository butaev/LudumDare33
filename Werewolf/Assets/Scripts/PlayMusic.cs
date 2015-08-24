using UnityEngine;
using System.Collections;

public class PlayMusic : MonoBehaviour {

	public AudioClip track;
	

	private AudioSource source;

	private void Start () {
		source = GetComponent<AudioSource>();
	}

	public void PushMusicButton () {
		source.clip = track;
		source.Play ();
	}
}
