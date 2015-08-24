using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float humanMovementSpeed = 10.0f;
	public float werewolfMovementSpeed = 20.0f;
	public float atackRadius;
	private float timeJump = 1f;
	private float timerJump;
	private Transform cachedTransform;
	private Rigidbody2D cachedRigidbody;
	private Collider2D cachedCollider;
	private bool isGround = false;
	public bool human = true;
	private float yScale;
	private float xScale;
	private bool hiding = false;
	private float direction;
	private Animator anim;
	private RaycastHit2D hit;

	private void Awake() {
		cachedTransform = GetComponent<Transform>();
		cachedRigidbody = GetComponent<Rigidbody2D>();
		cachedCollider = GetComponent<Collider2D>();
		yScale = transform.localScale.y;
		xScale = transform.localScale.x;
		anim = GetComponent<Animator> ();
	}

	void OnTriggerStay2D(Collider2D trigger) {
		if (trigger.transform.GetComponent<Collider2D> ().tag == "Door") {
			if (human && Input.GetButtonDown ("Vertical") && !hiding && Input.GetAxis("Vertical") > 0f) {
				cachedRigidbody.isKinematic = true;
				cachedCollider.enabled = false;
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
				hiding = true;
			}
		}
	}

	private void Atack(float direction) {
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("werewolfAtack") || anim.GetCurrentAnimatorStateInfo(0).IsName("werewolfJump")) {
			return;
		}
		anim.SetBool("Atack", true);
		if (Physics2D.Raycast (cachedTransform.position, new Vector2 (direction, 0), atackRadius, 1 << LayerMask.NameToLayer ("Atack"))) {
			hit = Physics2D.Raycast (cachedTransform.position, new Vector2 (direction, 0), atackRadius, 1 << LayerMask.NameToLayer ("Atack"));
			hit.transform.GetComponentInParent<Footman>().Harm();
		}
	}
	
	private void Update () {
		human = GetComponent<Player_main_script> ().inShadow;
		float horizontal = Input.GetAxis("Horizontal");
		direction = Mathf.Sign (horizontal);
		if (horizontal != 0) {
			anim.SetBool("Run", true);
			anim.SetBool("Idle", false);
			transform.localScale = new Vector2 (direction * xScale, yScale);
		} else {
			anim.SetBool("Run", false);
			anim.SetBool("Idle", true);
		}
		if (human) {
			if (hiding){
				if (Input.GetButtonDown ("Vertical") && Input.GetAxis("Vertical") < 0f){
					cachedCollider.enabled = true;
					cachedRigidbody.isKinematic = false;
					gameObject.GetComponent<SpriteRenderer>().enabled = true;
					hiding = false;
				}
			}else{
				cachedRigidbody.velocity = new Vector2 (horizontal * humanMovementSpeed, cachedRigidbody.velocity.y);
			}
		} else {
			cachedRigidbody.velocity = new Vector2( horizontal * werewolfMovementSpeed, cachedRigidbody.velocity.y);
			isGround = (Physics2D.Raycast (cachedTransform.position, Vector2.down, 10.5f, 1 << LayerMask.NameToLayer ("Ground")) || Physics2D.Raycast (cachedTransform.position, Vector2.down, 10.5f, 1 << LayerMask.NameToLayer ("Box")));
			if (Physics2D.Raycast (cachedTransform.position, Vector2.down, 9f, 1 << LayerMask.NameToLayer ("Atack"))){
				hit = Physics2D.Raycast (cachedTransform.position, Vector2.down, 10.5f, 1 << LayerMask.NameToLayer ("Atack"));
				hit.transform.GetComponentInParent<Footman>().Harm();
				hit.transform.GetComponentInParent<Footman>().Harm();
			}
			if (isGround) {
				anim.SetBool("Jump", false);
				anim.SetBool("noJump", true);
			}else {
				anim.SetBool("Jump", true);
				anim.SetBool("noJump", false);
			}
			if (Input.GetButtonDown ("Vertical") && isGround && timerJump >= timeJump && Input.GetAxis("Vertical") > 0f) {

				cachedRigidbody.AddForce (Vector2.up  * 100000.0f);
				timerJump = 0.0f;
			}
			if (Input.GetKeyDown (KeyCode.Space)){
				Atack(direction);
			}
			timerJump += Time.deltaTime;
		}
		timerJump += Time.deltaTime;
	}
}