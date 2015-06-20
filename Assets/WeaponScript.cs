using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	public Sprite[] _sprites;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer>().sprite = _sprites[0]; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
