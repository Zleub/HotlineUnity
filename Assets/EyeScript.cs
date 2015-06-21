using UnityEngine;
using System.Collections;

public class EyeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay (Collider c) {
		print(c.gameObject.name);
	}

	public void Move(Vector3 position) {
		gameObject.transform.position = position;
	}
}
