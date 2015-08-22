using UnityEngine;
using System.Collections;

public class Crossbowman : MonoBehaviour {
	public Transform target;
	public Rigidbody2D arrow;

	public void Atack () {
		Vector3 position = transform.position;
		Vector3 diff = target.position - transform.position;
		diff.Normalize();
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

		Rigidbody2D arrow_clone = Instantiate(arrow, position, Quaternion.Euler(0f, 0f, rot_z)) as Rigidbody2D;
		arrow_clone.velocity = (target.position - transform.position).normalized * 30;
	}
}
