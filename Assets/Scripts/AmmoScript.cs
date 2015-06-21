using UnityEngine;
using System.Collections;

public class AmmoScript : MonoBehaviour {

	public bool friendly;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Character" && !friendly)
			print ("player got hit");
		if (coll.gameObject.tag == "Enemy" && friendly)
			print ("enemy got hit");
		if (coll.gameObject.layer ==  9) {
			print ("Wall");
			Destroy (this.gameObject);
		}
		else {
			print (coll.gameObject.name);
		}
	}
}
