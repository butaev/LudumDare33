using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {
	
	public GameObject player;
	private float x;
	private float y;
	public float scrollSpeed = 0.5F;
	private Renderer rend;
	
	void Awake (){
		y = transform.position.y;
		x = transform.position.x;
		rend = GetComponent<Renderer>();
	}
	
	void Update () {
		//transform.position = new Vector3 (player.transform.position.x * 0.5f, y, 10f); 
		float offset = Time.time * scrollSpeed;
		rend.material.SetTextureOffset("back", new Vector2(offset, 0));
	}
}
