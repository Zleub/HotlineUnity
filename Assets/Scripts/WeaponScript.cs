using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	public GameObject	AmmoPrefab;
	public Sprite[] 	_sprites;
	public int			_clip;
	public string		_name;
	public float		_delay = 5f;

	public float		_time = 0;
	
	void Start () {
		gameObject.GetComponent<SpriteRenderer>().sprite = _sprites[0];
		_delay =5f;
	} 

	// Update is called once per frame
	void Update () {
		_time += Time.deltaTime * 1000;
	}
	
	public int Shoot(Vector3 pos, Quaternion rot, Vector3 target, LayerMask l)
	{
		if (AmmoPrefab) {
			if (_clip == 0) {
				AudioSourceScript.asc.Play();
				print ("Out of Ammo");
				return 0;

			}
			_clip -= 1;
			AudioSourceScript.asc.Play();
//			GameObject Player = PlayerScript.ps.gameObject;
//			Vector3 MouseCoord = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			GameObject clone = GameObject.Instantiate (AmmoPrefab);

			clone.transform.position = pos;
//				clone.GetComponent<AmmoScript>().friendly = f;
			clone.transform.rotation = rot;
			clone.GetComponent<SpriteRenderer> ().sprite = _sprites [2];


			Vector3 test = (target - pos).normalized;
			Quaternion rotation = Quaternion.Euler (0, 0, Mathf.Atan2 (test.y, test.x) * Mathf.Rad2Deg);
			clone.gameObject.transform.rotation = rotation;
			clone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (test.x, test.y).normalized * 5;

			clone.GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Interpolate;
			clone.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
			clone.layer = l;

//			clone.GetComponent<Rigidbody2D> ().AddForce( new Vector2 (test.x, test.y) * 5 );
			_time = 0;
			return 1;
		} else {
			AudioSourceScript.asc.Play();
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