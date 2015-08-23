using UnityEngine;
using System.Collections;

public class WayPointSystem : MonoBehaviour {

	public GameObject point1;
	public GameObject point2;

	private bool right = false;
	private Vector2 v1, v2, dir;
	private Transform cachedTransform;
	private Rigidbody2D cachedRigidbody;
	private void OnDrawGizmos() {
		Gizmos.color = new Color(1, 1, 0, 0.5F);
		Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
	}

	private void Start () {
		cachedTransform = transform.parent.transform;
		v1 = new Vector2 (point1.transform.position.x, point1.transform.position.y);
		v2 = new Vector2 (point2.transform.position.x, point1.transform.position.y);
		Destroy (point1);
		Destroy (point2);
		cachedTransform.localScale = new Vector3 (-1f, cachedTransform.localScale.y, cachedTransform.localScale.z);
	}


	public Vector2 GetTarget (Vector2 curPos) {

		if (Vector2.Distance(curPos, v1) <= 10.5f && right) {
			cachedTransform.localScale = new Vector3 (-1f, cachedTransform.localScale.y, cachedTransform.localScale.z);
			right = false;
			dir = v2;
		}
		if (Vector2.Distance(curPos, v2) <= 10.5f && !right) {
			cachedTransform.localScale = new Vector3 (+1f, cachedTransform.localScale.y, cachedTransform.localScale.z);
			right = true;
			dir = v1;
		}
		return dir;
	}
}
