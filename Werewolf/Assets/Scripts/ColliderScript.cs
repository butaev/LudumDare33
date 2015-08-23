using UnityEngine;
using System.Collections;

public class ColliderScript : MonoBehaviour {

	public Transform player;
	private BoxCollider2D box;

	void Awake(){
		box = transform.GetComponentInParent<BoxCollider2D>();
	}

	void Update () {
		if (player.position.y - 2 < transform.position.y) {
			box.enabled = false;
		} else {
			box.enabled = true;//
		}
	}
}
