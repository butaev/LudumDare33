using UnityEngine;
using System.Collections;

public class Vision : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D player) {
		if (player.name == "Player") {
			transform.GetComponentInParent<Crossbowman>().Shooting();
		}
	}
}