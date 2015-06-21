using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	public GameObject	AmmoPrefab;
	public Sprite[] 	_sprites;
	public int			_clip;
	public string		_name;
	public float		_delay;

	private float		_time = 0;
	
	void Start () {
		gameObject.GetComponent<SpriteRenderer>().sprite = _sprites[0];

	} 

	// Update is called once per frame
	void Update () {
		_time += Time.deltaTime;
	}
	
	public int Shoot()
	{
		if (AmmoPrefab && _time > _delay) {
			if (_clip == 0) {
				GetComponents<AudioSource> () [1].PlayDelayed (0f);
				print ("Out of Ammo");
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

			clone.GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Interpolate;
			clone.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;

//			clone.GetComponent<Rigidbody2D> ().AddForce( new Vector2 (test.x, test.y) * 5 );
			_time = 0;
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