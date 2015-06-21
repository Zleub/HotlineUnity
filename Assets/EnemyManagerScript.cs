using UnityEngine;
using System.Collections;

public class EnemyManagerScript : MonoBehaviour {

	public GameObject	gameCheck;

	public float		speed = 0.3f;

	public	EnemyScript enemy;
	public	EyeScript	eye;
	public	bool		_active = true;
	public	Vector2		velocity;

	// Use this for initialization
	void Start () {
		enemy = gameObject.GetComponentInChildren<EnemyScript>();
		eye = gameObject.GetComponentInChildren<EyeScript>();
	}
	
	// Update is called once per frame
	void Update () {
		velocity = enemy.gameObject.GetComponent<Rigidbody2D>().velocity;			
	}

	public void Rotate (Vector3 target)
	{
		enemy.Rotate(target);
		eye.Rotate(target);
	}
	
	public void Move(Vector2 movement)
	{
		float realSpeed = Time.deltaTime * speed;
		Vector2 caca = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y) + new Vector2 (movement.x, movement.y).normalized * realSpeed;

		enemy.Move(caca);
		eye.Move(enemy.gameObject.transform.position);
	}


	public void RotateIA (Vector3 target)
	{
		if (_active == false) { return ; }

		enemy.Rotate(target);
		eye.Rotate(target);
	}
	
	public void MoveIA(Vector2 movement)
	{
		if (_active == false) { return ; }

		float realSpeed = Time.deltaTime * speed;
		Vector2 caca = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y) + new Vector2 (movement.x, movement.y).normalized * realSpeed;
		
		enemy.Move(caca);
		eye.Move(enemy.gameObject.transform.position);
	}

	public void setIA(bool b) { _active = b; }
}
