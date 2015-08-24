using UnityEngine;
using System.Collections;

public class WayPointSystem : MonoBehaviour {

	public GameObject point1;
	public GameObject point2;

	private bool right = true;

	private float v_left, v_right, dir;
	private Transform cachedTransform;
	//public Transform pivot;
	private Rigidbody2D cachedRigidbody;

	private void Start () {
		cachedTransform = transform.parent.transform;

		v_left = point1.transform.position.x;
		v_right = point2.transform.position.x;
		if (v_left > v_right) {
			v_left = v_right;
			v_right = point1.transform.position.x;
			v_right = point1.transform.position.x;

		}
		dir = v_right;
		Destroy (point1);
		Destroy (point2);
	}


	public float GetTarget (Vector2 curPos) {

		if (cachedTransform.position.x <= v_left&& !right) {
			cachedTransform.localScale = new Vector3 (1f, cachedTransform.localScale.y, cachedTransform.localScale.z);
			right = true;
			dir = v_right;
		}
		if (cachedTransform.position.x >= v_right && right) {
			cachedTransform.localScale = new Vector3 (-1f, cachedTransform.localScale.y, cachedTransform.localScale.z);
			right = false;
			dir = v_left;
		}
		return dir;
	}
}