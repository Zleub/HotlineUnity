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
	
	void Rotate (Vector3 target) {

		Vector3 diff = target - transform.position;
		diff.Normalize();
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

		foreach (SpriteRenderer _sprite in _sprites)
			if (_sprite.name == "Weapon")
			{
				Vector3 diff1 = target - _sprite.gameObject.transform.position;
				diff1.Normalize();
				float rot_z1 = Mathf.Atan2(diff1.y, diff1.x) * Mathf.Rad2Deg;

				_sprite.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, rot_z1 + 90);
			}
			else
				_sprite.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);

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
		
		gameObject.transform.Translate( new Vector3(hor * realSpeed, ver * realSpeed, 0));
	}


	void FixedUpdate () {

		Vector3 MouseCoord = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetButtonDown("Fire2"))
		{
			if (_hasweapon)
			{
				GameObject clone = GameObject.Instantiate(_weapon);
				clone.gameObject.layer = LayerMask.NameToLayer("Weapon");
				clone.gameObject.transform.position = gameObject.transform.position;


				Vector3 test = MouseCoord - gameObject.transform.position;
				Vector2 normal = new Vector2 (test.normalized.x, test.normalized.y);
				clone.gameObject.GetComponent<Rigidbody2D>().AddForce(normal * 50, ForceMode2D.Impulse);
				_weapon = null;
				_hasweapon = false;
			}
			else
			{
				Vector3 caca = gameObject.transform.position;
				caca.z -= 10;
				RaycastHit2D test = Physics2D.Raycast(caca, Vector2.zero,
				                                      Mathf.Infinity, LayerMask.NameToLayer("Weapon"));
				if (test)
				{
					print(test.collider.gameObject.name);
				}
			}
		}
		if (Input.GetButtonDown ("Fire1")) {
			if (_hasweapon)
			{
				_weapon.GetComponent<WeaponScript>().Shoot();
			}

		}

		Move ();

		Rotate(MouseCoord) ;
	}

	public void SetHead(Sprite s) {
		_sprites[0].sprite = s;
	}	

	public void SetWeapon(Sprite s) {
		_sprites[1].sprite = s;
	}	

	public void SetBody(Sprite s) {
		_sprites[2].sprite = s;
	}	

}
