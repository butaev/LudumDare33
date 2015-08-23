using UnityEngine;
using System.Collections;

public class Moon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public bool MoonActive (){
		if (gameObject.activeSelf) {
			return true;
		} else {
			return false;
		}
	}
}
