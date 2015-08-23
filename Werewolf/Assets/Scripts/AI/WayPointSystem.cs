using UnityEngine;
using System.Collections;

public class WayPointSystem : MonoBehaviour {

	public GameObject point1;
	public GameObject point2;

	private bool right = true;
	private Vector2 v1, v2;
	private float v_left, v_right, dir;
	private Transform cachedTransform;
	private Rigidbody2D cachedRigidbody;
	/*private void OnDrawGizmos() {
		Gizmos.color = new Color(1, 1, 0, 0.5F);
		Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
	}*/

	private void Start () {
		cachedTransform = transform.parent.transform;
		v1 = point1.transform.position;
		v2 = point2.transform.position;
		v_left = point1.transform.position.x;
		v_right = point2.transform.position.x;
		if (v_left > v_right) {
			v_left = v_right;
			v1 = v2;
			v_right = point1.transform.position.x;
			v2 = point1.transform.position;
		}
		Destroy (point1);
		Destroy (point2);
		//cachedTransform.localScale = new Vector3 (-1f, cachedTransform.localScale.y, cachedTransform.localScale.z);
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