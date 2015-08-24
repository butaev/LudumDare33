using UnityEngine;
using System.Collections;

public class Vision_Crossbownman : MonoBehaviour {
	
	void OnTriggerStay2D(Collider2D player) {
		if (player.name == "Player") {
			transform.GetComponentInParent<Crossbowman>().Atack();
		}
	}
}