using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float humanMovementSpeed = 10.0f;
	public float werewolfMovementSpeed = 20.0f;
	private float timeJump = 0.5f;
	private float timerJump;
	private Transform cachedTransform;
	private Rigidbody2D cachedRigidbody;
	private Collider2D cachedCollider;
	private bool isGround = false;
	private bool inShadow;
	public bool human = true;

	private bool hiding = false;

	private void Awake() {
		cachedTransform = GetComponent<Transform>();
		cachedRigidbody = GetComponent<Rigidbody2D>();
		cachedCollider = GetComponent<Collider2D>();
	}

	void OnTriggerStay2D(Collider2D trigger) {
		if (human) {

			if (Input.GetButtonDown ("Vertical") && !hiding && trigger.transform.GetComponent<Collider2D> ().tag == "Door" && Input.GetAxis("Vertical") > 0f) {
				Debug.Log ("Test1");
				cachedCollider.enabled = false;
				cachedRigidbody.isKinematic = true;
				hiding = true;
				return;
			}
			if (Input.GetButtonDown ("Vertical") && hiding) {
				Debug.Log ("Test2");
				cachedRigidbody.isKinematic = false;
				hiding = false;
				return;
			}
		}
	}

	private void Update () {
		human = GetComponent<Player_main_script> ().inShadow;
		if (human) {
			float horizontal = Input.GetAxis ("Horizontal");

			if (hiding && Input.GetButtonDown ("Vertical")) {
				horizontal = 0f;
			}
			cachedRigidbody.velocity = new Vector2 (horizontal * humanMovementSpeed, cachedRigidbody.velocity.y);

			if (Input.GetButtonDown ("Horizontal") && hiding) {
				horizontal = Input.GetAxis ("Horizontal");
				Debug.Log ("Test3");
				cachedCollider.enabled = true;
				cachedRigidbody.isKinematic = false;
			}
		} else {
			float horizontal = Input.GetAxis("Horizontal");
			cachedRigidbody.velocity = new Vector2( horizontal * werewolfMovementSpeed, cachedRigidbody.velocity.y);
			isGround = (Physics2D.Raycast (cachedTransform.position, Vector2.down, 6f, 1 << LayerMask.NameToLayer ("Ground")) || Physics2D.Raycast (cachedTransform.position, Vector2.down, 6f, 1 << LayerMask.NameToLayer ("Box")));
			if (Input.GetButtonDown ("Vertical") && isGround && timerJump >= timeJump && Input.GetAxis("Vertical") > 0f) {
				cachedRigidbody.AddForce (Vector2.up  * 100000.0f);
				timerJump = 0.0f;
			}
			timerJump += Time.deltaTime;
		}
		timerJump += Time.deltaTime;
	}
}