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
		if (coll.gameObject.name == "Character" && gameObject.layer == 12)
			Application.LoadLevel(Application.loadedLevel);
		if (coll.gameObject.name == "Enemy" && gameObject.layer == 14) {
			Destroy(coll.gameObject.GetComponentInParent<EnemyManagerScript>().gameObject);
			Destroy(gameObject);
		}
		if (coll.gameObject.layer ==  9) {
			Destroy (this.gameObject);
		}
		else {
			print (coll.gameObject.name);
		}
	}
}
