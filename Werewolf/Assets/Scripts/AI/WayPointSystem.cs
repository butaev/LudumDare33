using UnityEngine;
using System.Collections;

public class WayPointSystem : MonoBehaviour {

	public float speed = 10.0f;

	public GameObject point1;
	public GameObject point2;
	
	private float x1, x2;

	private Transform cachedTransform;
	private Rigidbody2D cachedRigidbody;
	private void OnDrawGizmos() {
		Gizmos.color = new Color(1, 1, 0, 0.5F);
		Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
	}

	private void Start () {
		cachedTransform = transform.parent.transform;
		x1 = point1.transform.position.x;
		x2 = point2.transform.position.x;
		Destroy (point1);
		Destroy (point2);
	}

	private void Update () {

		float horizontal = speed * Time.deltaTime;
		
		cachedTransform.position = new Vector2 (cachedTransform.position.x + horizontal, cachedTransform.position.y);

		if (cachedTransform.position.x <= x1 && speed < 0) {
			speed = -1f * speed;
			cachedTransform.transform.localScale += new Vector3(-2f, 0, 0);
		}
		if (cachedTransform.position.x >= x2 && speed > 0) {
			speed = -1f * speed;
			cachedTransform.transform.localScale += new Vector3(2f, 0, 0);
		}
	}
}
