using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float movementSpeed = 10.0f;
	public float timeJump = 0.5f;
	public float timerJump;
	private Transform cachedTransform;
	private Rigidbody2D cachedRigidbody;
	private bool isGround = false;
	
	private void Awake() {
		cachedTransform = GetComponent<Transform>();
		cachedRigidbody = GetComponent<Rigidbody2D>();
	}
	
	private void Update () {

		float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

		cachedTransform.position = new Vector2 (cachedTransform.position.x + horizontal, cachedTransform.position.y);

		isGround = Physics2D.Raycast (cachedTransform.position, Vector2.down, 3.315f, 1 << LayerMask.NameToLayer ("Ground"));

		if (Input.GetButtonDown ("Vertical") && isGround && timerJump >= timeJump) {
			cachedRigidbody.AddForce (Vector2.up  * 500.0f);
			timerJump = 0.0f;
		}
		timerJump += Time.deltaTime;
	}
}