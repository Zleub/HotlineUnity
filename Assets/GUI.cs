using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponentInParent<Text>().text = PlayerScript.ps.GetAmmo().ToString();
	}
}
