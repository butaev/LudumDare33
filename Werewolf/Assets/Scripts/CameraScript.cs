using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	
	public GameObject player;
	private float y;
	private float x;
	public float hight;

	void Awake (){
		y = transform.position.y;
		x = transform.position.x;
	}
	
	void Update () {
		if (player.transform.position.y < hight) {
			transform.position = new Vector3 (player.transform.position.x + x, y, -10f); 
		} else {
			transform.position = new Vector3 (player.transform.position.x + x, (player.transform.position.y - hight) + y, -10f);
		}
	}
}
