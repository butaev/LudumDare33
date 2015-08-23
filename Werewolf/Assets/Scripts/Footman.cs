using UnityEngine;
using System.Collections;

public class Footman : MonoBehaviour {
	
	public GameObject target;
	public float speed = 10f;
	private bool isAtacking = false;
	private float detectionTime;
	public float coolingTime = 10f;
	public float atackRadius = 1f;
	public float standBeforAtack = 1f;
	private float startAtack = 0;
	private bool startHit = false;
	private float targetX;
	
	public void Atack () {
		if (!startHit && (cachedTransform.position - target.transform.position).magnitude < atackRadius) {
			startHit = true;
			startAtack = 0;
		}
		targetX = target.transform.position.x;
		if (startHit) {
			startAtack += Time.deltaTime;
			if (startAtack > standBeforAtack) {
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
	}
	
	private void Update () {
		detectionTime += Time.deltaTime;
		if (detectionTime > coolingTime) {
			isAtacking = false;
		}
		float step = speed * Time.deltaTime;
		if (poligonCollider.IsTouching (target.GetComponent<BoxCollider2D> ()) || isAtacking) {
			if (poligonCollider.IsTouching (target.GetComponent<BoxCollider2D>())){
				detectionTime = 0;
				isAtacking = true;
			}
			Atack ();
		} else {
			cachedTransform.position = Vector2.MoveTowards (cachedTransform.position, new Vector2(GetComponentInChildren<WayPointSystem>().GetTarget(cachedTransform.position), cachedTransform.position.y), step);
		}
	}
}