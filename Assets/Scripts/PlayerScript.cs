using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public static PlayerScript	ps;
	public float				speed = 10f;

	private SpriteRenderer[]	_sprites;
	private Animator			_animator;
	public bool					_hasweapon = false;
	public GameObject			_weapon;

	void Start () {
		ps = this;
		_sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
		_animator = gameObject.GetComponentInChildren<Animator>();
	}

	void Rotate (Vector3 target)
	{
		foreach (SpriteRenderer _sprite in _sprites)
		{
			target.z = _sprite.gameObject.transform.position.z;
			_sprite.gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, _sprite.gameObject.transform.position - target);
		}
	}

	void Move()
	{
		float hor;
		float ver;
		
		hor = Input.GetAxis("Horizontal");
		ver = Input.GetAxis("Vertical");

		if (hor == 0f && ver == 0)
			_animator.SetBool("Walking", false);
		else
			_animator.SetBool("Walking", true);

		float realSpeed = Time.deltaTime * speed;

		Vector2 t = new Vector2(hor, ver);

//		gameObject.transform.Translate( new Vector3(hor * realSpeed, ver * realSpeed, 0));
		gameObject.GetComponent<Rigidbody2D>().MovePosition(gameObject.GetComponent<Rigidbody2D>().position + t * realSpeed);
	}

	void FixedUpdate () {
		Vector3 MouseCoord = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Move ();
		
		Rotate(MouseCoord) ;

		if (Input.GetButtonDown("Fire2"))
		{
			if (_hasweapon)
			{
//				GameObject clone = GameObject.Instantiate(_weapon);
//				clone.gameObject.layer = LayerMask.NameToLayer("Weapon");
				_weapon.GetComponent<WeaponScript>().gameObject.transform.position = gameObject.transform.position;
				_weapon.GetComponent<WeaponScript>().GetComponent<SpriteRenderer>().sprite = _weapon.GetComponent<WeaponScript>()._sprites[0];

				Vector3 test = MouseCoord - gameObject.transform.position;
				Vector2 normal = new Vector2 (test.normalized.x, test.normalized.y);
				_weapon.GetComponent<WeaponScript>().gameObject.GetComponent<Rigidbody2D>().AddForce(normal * 50, ForceMode2D.Impulse);
				_weapon = null;
				_hasweapon = false;
				SetWeapon(null);
			}
			else
			{
				Vector3 caca = gameObject.transform.position;
				caca.z -= 10;
				RaycastHit2D hit = Physics2D.Raycast(caca, Vector2.zero, Mathf.Infinity, 1<<11);
				if (hit)
				{
					_weapon = hit.collider.gameObject;
					_weapon.GetComponent<WeaponScript>().GetComponent<SpriteRenderer>().sprite = null;
					_hasweapon = true;
					SetWeapon(_weapon.GetComponent<WeaponScript>()._sprites[1]);
				}
			}
		}
		if (Input.GetButtonDown("Fire1")) {
			if (_hasweapon)
			{
				_weapon.GetComponent<WeaponScript>().Shoot();
			}

		}

	}

	public void SetHead(Sprite s) { _sprites[0].sprite = s;	}	

	public void SetWeapon(Sprite s) { _sprites[1].sprite = s; }	

	public void SetBody(Sprite s) { _sprites[2].sprite = s;	}	

	public int GetAmmo() { return _weapon.GetComponent<WeaponScript>().GetAmmo(); }
}
