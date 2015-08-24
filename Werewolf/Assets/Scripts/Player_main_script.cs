using UnityEngine;
using System.Collections;

public class Player_main_script : MonoBehaviour {

	private int health = 4;
	public bool inShadow = false;
	public GameObject moon;
	private Animator anim;

	void Awake () {
		anim = GetComponent<Animator> ();
	}

	public void Harm(){
		health -= 1;
		Debug.Log (health);
		if (health <= 0) {
			Death ();
		}
	}

	public void Death () {
		Destroy (gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D trigger) {
		if (trigger.tag == "Projecttile") {
			Destroy(trigger.gameObject);
			Harm();
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
			anim.SetBool("Human", true);
			anim.SetBool("Wolf", false);
		} else {
			anim.SetBool("Wolf", true);
			anim.SetBool("Human", false);
		}
	}
}