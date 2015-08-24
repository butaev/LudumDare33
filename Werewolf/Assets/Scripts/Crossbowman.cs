using UnityEngine;
using System.Collections;

public class Crossbowman : MonoBehaviour {
	private Transform target;
	public GameObject arrow;
	public int health = 2;
	private float direction = 1f;
	public float turnTime = 5f;
	private float startTurnTime = 0f;
	private float scaleY;
	private float reloadTime= 2f;
	private float startShootTime = 0f;
	private Animator anim;

	private void Awake () {
		target = GameObject.Find ("Player").transform;
		scaleY = transform.localScale.y;
		anim = GetComponent<Animator> ();
	}

	public void Harm(){
		health -= 1;
		GetComponent<SpriteRenderer>().color = Color.red;
		if (health <= 0) {
			Death();
		}
	}

	void Update () {
		if (startShootTime > 0.3) {
			anim.SetBool("Atack", false);
		}
		startTurnTime += Time.deltaTime;
		startShootTime += Time.deltaTime;
		if (startTurnTime > turnTime) {
			startTurnTime = 0f;
			if (direction > 0) {
				transform.localScale = new Vector2(-1f, scaleY);
				direction = -1f;
			} else {
				transform.localScale = new Vector2(1f, scaleY);
				direction = 1f;
			}

		}
	}

	public void Death () {
		Destroy (gameObject);
	}

	public void Atack () {
		if (startShootTime > reloadTime) {
			anim.SetBool("Atack", true);
			startShootTime = 0f;
			Vector2 position = transform.position;
			Vector2 diff = target.position - transform.position;
			diff.Normalize ();
			float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
			GameObject arrow_clone = Instantiate (arrow, position, Quaternion.Euler (0f, 0f, rot_z)) as GameObject;
			arrow_clone.GetComponent<Rigidbody2D> ().velocity = (target.position - transform.position).normalized * 50;
		}
	}
}
