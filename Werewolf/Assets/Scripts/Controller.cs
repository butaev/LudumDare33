using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float humanMovementSpeed = 10.0f;
	public float werewolfMovementSpeed = 20.0f;
	private float timeJump = 0.5f;
	private float timerJump;
	private Transform cachedTransform;
	private Rigidbody2D cachedRigidbody;
	private bool isGround = false;
	private bool inShadow;
	public bool human = true;
	
	private void Awake() {
		cachedTransform = GetComponent<Transform>();
		cachedRigidbody = GetComponent<Rigidbody2D>();
	}

	private void Update () {
		human = GetComponent<Player_main_script> ().inShadow;
		if (human) {
			float horizontal = Input.GetAxis("Horizontal");
			cachedRigidbody.velocity = new Vector2( horizontal * humanMovementSpeed, cachedRigidbody.velocity.y);
		} else {
			float horizontal = Input.GetAxis("Horizontal");
			cachedRigidbody.velocity = new Vector2( horizontal * werewolfMovementSpeed, cachedRigidbody.velocity.y);
			isGround = (Physics2D.Raycast (cachedTransform.position, Vector2.down, 6f, 1 << LayerMask.NameToLayer ("Ground")) || Physics2D.Raycast (cachedTransform.position, Vector2.down, 6f, 1 << LayerMask.NameToLayer ("Box")));
			if (Input.GetButtonDown ("Vertical") && isGround && timerJump >= timeJump) {
				cachedRigidbody.AddForce (Vector2.up  * 100000.0f);
				timerJump = 0.0f;
			}
			timerJump += Time.deltaTime;
		}
		timerJump += Time.deltaTime;
	}
}