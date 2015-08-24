using UnityEngine;
using System.Collections;

public class Crossbowman : MonoBehaviour {
	private Transform target;
	public GameObject arrow;
	public int health = 2;

	void Awake () {
		target = GameObject.Find ("Player").transform;
	}

	public void Harm(){
		health -= 1;
		GetComponent<SpriteRenderer>().color = Color.red;
		if (health <= 0) {
			Death();
		}
	}
	
	public void Death () {
		Destroy (gameObject);
	}

	public void Atack () {
		Vector2 position = transform.position;
		Vector2 diff = target.position - transform.position;
		diff.Normalize();
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		GameObject arrow_clone = Instantiate (arrow, position, Quaternion.Euler (0f, 0f, rot_z)) as GameObject;
		arrow_clone.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * 50;
	}
}
