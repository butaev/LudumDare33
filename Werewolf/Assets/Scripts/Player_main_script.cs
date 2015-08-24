using UnityEngine;
using System.Collections;

public class Player_main_script : MonoBehaviour {

	private int health = 4;
	public bool inShadow = false;
	public GameObject moon;
	
	void OnTriggerEnter2D(Collider2D trigger) {
		if (trigger.tag == "Projecttile") {
			Destroy(trigger.gameObject);
			health -= 1;
			Debug.Log(health);
		}
	}

	void OnTriggerExit2D(Collider2D building) {
		if (building.tag == "Shadow") {
			inShadow = false;
		}
	}

	void OnTriggerStay2D(Collider2D shadow) {
		if (shadow.tag == "Shadow") {
			inShadow = true;
		}
	}

	private void Update(){
		if (inShadow) {
			//GetComponent<SpriteRenderer> ().color = Color.red;
		} else {
			//GetComponent<SpriteRenderer> ().color = Color.blue;
		}
	}
}