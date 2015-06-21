using UnityEngine;
using System.Collections;

public class WeaponSpawner : MonoBehaviour {
	public WeaponScript[] _pool;
	// Use this for initialization
	void Start () {
		Instantiate(_pool[Random.Range(0, _pool.Length)], gameObject.transform.position, gameObject.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
