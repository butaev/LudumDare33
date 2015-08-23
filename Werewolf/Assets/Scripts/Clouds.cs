using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour {


	private Transform cachedTransform;

	private void Awake () {
		cachedTransform = GetComponent<Transform>();
	}

	private void Update () {
		
	}
}
