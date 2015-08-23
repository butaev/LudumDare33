using UnityEngine;
using System.Collections;

public class Footman : MonoBehaviour {
	
	public GameObject target;
	public float speed = 10f;
	
	public void Atack () {
		
		if (cachedTransform.position.x <= target.transform.position.x) {
			cachedTransform.position = new Vector2 (cachedTransform.position.x + speed * Time.deltaTime, cachedTransform.position.y);
		}
		if (cachedTransform.position.x >= target.transform.position.x) {
			cachedTransform.position = new Vector2 (cachedTransform.position.x - speed * Time.deltaTime, cachedTransform.position.y);
		}
	}

	private PolygonCollider2D poligonCollider;
	private Transform cachedTransform;
	

	private void Awake () {
		cachedTransform = GetComponent<Transform>();
		poligonCollider = GetComponent<PolygonCollider2D>();
	}
	
	private void Update () {

		float step = speed * Time.deltaTime;

		if (poligonCollider.IsTouching (target.GetComponent<BoxCollider2D> ())) {
			Debug.Log ("Test");
			Atack ();
		} else {
			cachedTransform.position = Vector3.MoveTowards (cachedTransform.position, GetComponentInChildren<WayPointSystem>().GetTarget(cachedTransform.position), step);
		}
	}
}