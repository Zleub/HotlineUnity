using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
