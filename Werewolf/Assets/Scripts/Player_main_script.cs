using UnityEngine;
using System.Collections;

public class Player_main_script : MonoBehaviour {

	private int health = 4;

	private Transform cachedTransform;
	private Rigidbody2D cachedRigidbody;

	private void Awake() {
		cachedTransform = GetComponent<Transform>();
		cachedRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D arrow) {
		if (arrow.tag == "Projecttile") {
			Destroy(arrow.gameObject);
			health -= 1;
			Debug.Log(health);
		}
	}

	private bool InShadow(){
		Physics.Raycast (cachedTransform.position, new Vector3(0, 0, 3f), 3.315f, 1 << LayerMask.NameToLayer ("Ground"));
	}
}
