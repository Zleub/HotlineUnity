using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		PlayerScript.ps.SetHead(null);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3 (
			PlayerScript.ps.gameObject.transform.position.x,
			PlayerScript.ps.gameObject.transform.position.y,
			-10f
		);
		if (Input.GetKeyDown("r"))
			Application.LoadLevel(Application.loadedLevel);
	}
}
