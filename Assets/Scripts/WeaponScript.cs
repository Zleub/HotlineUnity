using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	public GameObject	AmmoPrefab;
	public Sprite[] 	_sprites;
	public int			_clip;
	public string		_name;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer>().sprite = _sprites[0];

	} 

	// Update is called once per frame
	void Update () {

	}
	
	public int Shoot()
	{
		if (AmmoPrefab) {
			if (_clip == 0) {
				print ("Out of Ammo");
				GetComponents<AudioSource> () [1].PlayDelayed (0f);
				return 0;

			}
			_clip -= 1;
			GetComponents<AudioSource> () [0].PlayDelayed (0f);
			GameObject Player = PlayerScript.ps.gameObject;
			Vector3 MouseCoord = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			GameObject clone = GameObject.Instantiate (AmmoPrefab);

			clone.transform.position = Player.transform.position;
			clone.transform.rotation = Player.GetComponentsInChildren<SpriteRenderer> () [1].gameObject.transform.rotation;
			clone.GetComponent<SpriteRenderer> ().sprite = _sprites [2];


			Vector3 test = (MouseCoord - Player.transform.position).normalized;
			Quaternion rotation = Quaternion.Euler (0, 0, Mathf.Atan2 (test.y, test.x) * Mathf.Rad2Deg);
			clone.gameObject.transform.rotation = rotation;
			clone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (test.x, test.y).normalized * 50;
			return 1;
		} else {
			GetComponents<AudioSource> () [0].PlayDelayed (0f);
			return 1;
		}
	}

	public int GetAmmo()
	{
		if (AmmoPrefab)
			return _clip;
		else
			return 999;
	}
	public string GetName()
	{
		return _name;
	}

}