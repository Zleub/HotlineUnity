using UnityEngine;
using System.Collections;

public class IAScript : MonoBehaviour {

	public struct Pair {
		public GameObject		start;
		public GameObject		target;
		public GameObject		enemy;
		public int				cmp;
	};

	private bool _active = true;

	public GameObject[]		enemyArray;
	public GameObject[]		flagArray;
	public Pair[]			pairArray;
	
	// Use this for initialization
	void Start () {
		enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
		flagArray = GameObject.FindGameObjectsWithTag("Flag");

//		print(enemyArray.Length);
		pairArray = new Pair[enemyArray.Length];
		for (int i = 0; i < enemyArray.Length; i++)
		{
			pairArray[i].enemy = enemyArray[i];
			pairArray[i].cmp = 0;
			pairArray[i].target = null;
			Search(ref pairArray[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
		pairArray = new Pair[enemyArray.Length];
		for (int i = 0; i < enemyArray.Length; i++)
		{
			pairArray[i].enemy = enemyArray[i];
			pairArray[i].cmp = 0;
			pairArray[i].target = null;
			Search(ref pairArray[i]);
		}

		for (int i = 0; i < pairArray.Length; i++)
		{
			if (pairArray[i].enemy.GetComponent<EnemyManagerScript>()._active == false)
			{
				continue ;
			}

			pairArray[i].cmp += 1;

			if (pairArray[i].cmp > 10) {
				Search(ref pairArray[i]);
				pairArray[i].cmp = 0;
			}
			else
			{
				if ((pairArray[i].target.transform.position - pairArray[i].enemy.transform.position).magnitude > 1)
					Move(pairArray[i]);
			}
		}
	}

	void Move(Pair pair) {
//		print (pair.target);
	
//		print ("move");
		pair.enemy.GetComponent<EnemyManagerScript>().RotateIA(pair.target.transform.position);
		pair.enemy.GetComponent<EnemyManagerScript>().MoveIA(pair.target.transform.position - pair.enemy.transform.position);
	}

	void Search(ref Pair pair) {

//		print ("Search");

		float maxrange = 100;
		Vector3 v = new Vector3 (maxrange, maxrange, 0);
		GameObject enemy = pair.enemy;
//		GameObject f = null;
			
		foreach (GameObject flag in flagArray)
		{
			Vector3 distance = flag.transform.position - enemy.transform.position;
//			print (distance.magnitude);
			if (distance.magnitude < 3) {
				pair.start = flag;
			} 

			if (flag != pair.start && distance.magnitude < v.magnitude) {
				v = distance;
				pair.target = flag;
//				print (pair.target.gameObject.name);
			}
		}
//		print ("distance to " + f.name + " : " + v.magnitude);
//		enemy.GetComponent<EnemyScript>().Rotate(pair.target.transform.position);
//		enemy.GetComponent<EnemyScript>().Move(pair.target.transform.position - enemy.transform.position);
	}

}
