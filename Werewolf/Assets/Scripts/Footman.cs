using UnityEngine;
using System.Collections;

public class Footman : MonoBehaviour {

	public Transform target;
	private Transform cachedTransform;
	public float movementSpeed = 0.01f;

	void Awake () {
		cachedTransform = GetComponent<Transform>();
	}
	void Start () {
	}
	
	public void Atack () {
		float velocity = Mathf.Sign (transform.position.x - target.position.x);
		cachedTransform.position = new Vector2 (cachedTransform.position.x + movementSpeed * Time.deltaTime, cachedTransform.position.y);
	}
}
