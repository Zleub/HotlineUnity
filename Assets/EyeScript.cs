using UnityEngine;
using System.Collections;

public class EyeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D c) {
		if (c.gameObject.layer == LayerMask.NameToLayer("Character"))
		{
			Vector2 myself = new Vector2(
				gameObject.GetComponentInParent<EnemyManagerScript>().transform.position.x,
				gameObject.GetComponentInParent<EnemyManagerScript>().transform.position.y
				);

			Vector2 target = new Vector2(
				gameObject.transform.rotation.x,
				gameObject.transform.rotation.y
			);
			gameObject.GetComponentInParent<EnemyManagerScript>().setIA(false);
			gameObject.GetComponentInParent<EnemyManagerScript>().Rotate(c.gameObject.transform.position);
			gameObject.GetComponentInParent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
			gameObject.GetComponentInParent<EnemyScript>()._weapon.GetComponent<WeaponScript>().Shoot(gameObject.transform.position, gameObject.transform.rotation, c.gameObject.transform.position, 12);
			gameObject.GetComponentInParent<EnemyScript>()._weapon.GetComponent<WeaponScript>()._clip += 1;
		}
	}

	public void Move(Vector3 position) {
		gameObject.transform.position = position;
	}

	public void Rotate(Vector3 target) {
		target.z = gameObject.transform.position.z;
		gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, gameObject.transform.position - target);
	}
	
}
