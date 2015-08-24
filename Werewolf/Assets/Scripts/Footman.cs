using UnityEngine;
using System.Collections;

public class Footman : MonoBehaviour {
	
	private GameObject target;
	public float speed = 10f;
	private bool isAtacking = false;
	private float detectionTime;
	public float coolingTime = 10f;
	public float atackRadius = 1f;
	public float standBeforAtack = 1f;
	private float startAtack = 0;
	private bool startHit = false;
	private float targetX;
	public int health = 2;
	private Animator anim;
	private float startHitTime;

	public void Harm(){
		health -= 1;
		startHitTime = 0;
		GetComponent<SpriteRenderer>().color = Color.red;
		if (health <= 0) {
			Death();
		}
	}

	public void Death () {
		Destroy (gameObject);
	}

	private void Atack () {
		if (!startHit && (cachedTransform.transform.position - target.transform.position).magnitude < atackRadius) {
			startHit = true;
			anim.SetBool("Swing", true);
			startAtack = 0;
		}
		targetX = target.transform.position.x;
		if (startHit) {
			startAtack += Time.deltaTime;
			if (startAtack > standBeforAtack) {
				anim.SetBool("Atack", true);
				anim.SetBool("Swing", false);
				startHit = false;
				if (transform.localScale.x == -1){
					if (targetX < cachedTransform.position.x){
						if ((cachedTransform.position - target.transform.position).magnitude < atackRadius){
							target.GetComponent<Player_main_script>().Harm();
							return;
						}
					}
				}
				else {
					if (targetX > cachedTransform.position.x){
						if ((cachedTransform.position - target.transform.position).magnitude < atackRadius){
							target.GetComponent<Player_main_script>().Harm();
							return;
						}
					}
				}
			}
		}
		if (!startHit && cachedTransform.position.x <= targetX) {
			cachedTransform.position = new Vector2 (cachedTransform.position.x + speed * Time.deltaTime, cachedTransform.position.y);
			transform.localScale = new Vector3 (1f, cachedTransform.localScale.y, cachedTransform.localScale.z);
		}
		if (!startHit && cachedTransform.position.x >= targetX) {
			cachedTransform.position = new Vector2 (cachedTransform.position.x - speed * Time.deltaTime, cachedTransform.position.y);
			transform.localScale = new Vector3 (-1f, cachedTransform.localScale.y, cachedTransform.localScale.z);
		}
	}

	private PolygonCollider2D poligonCollider;
	private Transform cachedTransform;
	

	private void Awake () {
		cachedTransform = GetComponent<Transform>();
		poligonCollider = GetComponent<PolygonCollider2D>();
		anim = GetComponent<Animator> ();
		target = GameObject.Find ("Player");
	}
	
	private void Update () {
		startHitTime += Time.deltaTime;
		detectionTime += Time.deltaTime;
		if (detectionTime > coolingTime) {
			isAtacking = false;
		}
		if (startHitTime > 0.4) {
			GetComponent<SpriteRenderer>().color = Color.white;
		}
		float step = speed * Time.deltaTime;
		if ((poligonCollider.IsTouching (target.GetComponent<BoxCollider2D> ()) && !target.GetComponent<Controller>().human) || isAtacking) {
			if (poligonCollider.IsTouching (target.GetComponent<BoxCollider2D>())){
				detectionTime = 0;
				isAtacking = true;
			}
			Atack ();
		} else {
			cachedTransform.position = Vector2.MoveTowards (cachedTransform.position, new Vector2(GetComponentInChildren<WayPointSystem>().GetTarget(cachedTransform.position), cachedTransform.position.y), step);
			anim.SetBool("Atack", false);
			anim.SetBool("Swing", false);
		}
	}
}