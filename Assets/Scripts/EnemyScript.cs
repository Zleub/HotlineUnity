using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	
	public float				speed = 10f;
	
	private SpriteRenderer[]	_sprites;
	private Animator			_animator;
	public bool					_hasweapon = false;
	public GameObject			_weapon;
	
	void Start () {
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

	}
	
	void FixedUpdate () {

		
	}
	
	public void SetHead(Sprite s) { _sprites[0].sprite = s;	}	
	
	public void SetWeapon(Sprite s) { _sprites[1].sprite = s; }	
	
	public void SetBody(Sprite s) { _sprites[2].sprite = s;	}	
	
	public int GetAmmo() { return _weapon.GetComponent<WeaponScript>().GetAmmo(); }
}
