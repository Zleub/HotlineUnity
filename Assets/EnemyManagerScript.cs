using UnityEngine;
using System.Collections;

public class EnemyManagerScript : MonoBehaviour {

	public float		speed = 0.3f;

	public	EnemyScript enemy;
	public	EyeScript	eye;

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
	}
	
	public void Move(Vector2 movement)
	{
		float realSpeed = Time.deltaTime * speed;

		Vector3 ManagerDirection = gameObject.transform.position - enemy.gameObject.transform.position;

		Vector2 caca = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y) + new Vector2 (movement.x, movement.y);

		caca = caca + new Vector2(gameObject.transform.position.x, gameObject.transform.position.y).normalized * realSpeed;

		enemy.Move(caca);
		eye.Move(enemy.gameObject.transform.position);
		gameObject.transform.position = caca;//new Vector3(caca.x, caca.y, 0);
	}
}
