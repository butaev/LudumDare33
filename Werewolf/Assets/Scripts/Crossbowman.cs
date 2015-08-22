using UnityEngine;
using System.Collections;

public class Crossbowman : MonoBehaviour {

	public Rigidbody2D arrow;

	void Start () {
	}
	
	public Rigidbody2D Shooting () {
		Vector3 position = transform.position;
		Rigidbody2D arrow_clone = Instantiate(arrow, position, Quaternion.identity) as Rigidbody2D;
		arrow_clone.velocity = Vector2.left * 30;
		return arrow_clone;
	}

	void Update () {
		//if (Input.GetKeyDown ("w")) {
		/*if (isDetectPlayer) {
			Rigidbody2D arrow_clone = Shooting ();
			arrow_clone.velocity = Vector2.left * 50;
		}*/
	}
}
