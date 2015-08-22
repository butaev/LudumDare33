using UnityEngine;
using System.Collections;

public class Player_main_script : MonoBehaviour {

	private int health = 4;
	private bool InShadow = false;
	private Transform cachedTransform;
	private Rigidbody2D cachedRigidbody;

	private void Awake() {
		cachedTransform = GetComponent<Transform>();
		cachedRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D trigger) {
		if (trigger.tag == "Projecttile") {
			Destroy(trigger.gameObject);
			health -= 1;
			Debug.Log(health);
		}
		if (trigger.tag == "Shadow") {
			InShadow = true;
		}
	}

	void OnTriggerExit2D(Collider2D building) {
		if (building.tag == "Shadow") {
			InShadow = false;

		}
	}
	
	/*private bool InShadow(){
		if (Physics.Raycast (cachedTransform.position, new Vector3 (0, 0, 3f), 3.315f, 1 << LayerMask.NameToLayer ("Ground"))) {
			return true;
		} else {
			return false;
		}
	}*/

	private void Update(){
		if (InShadow) {
			GetComponent<SpriteRenderer> ().color = Color.red;
		} else {
			GetComponent<SpriteRenderer> ().color = Color.blue;
		}
	}

}
