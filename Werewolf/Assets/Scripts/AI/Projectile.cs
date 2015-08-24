using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D trigger) {
		if (trigger.tag == "Ground") {
			Destroy(gameObject);
		}
	}
}
