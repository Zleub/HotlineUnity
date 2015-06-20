using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FireWeaponScript : MonoBehaviour {
	public Sprite[] _sprites;
	public int		_clip;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer>().sprite = _sprites[0]; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int Shoot()
	{
		if (_clip == 0) {
			print ("Out of Ammo");
			return 0;
		}
		_clip -= 1;
		print ("Pan Pan");
		//instancie prefabs ?
		return 1;
	}


	public int GetAmmo()
	{
		return _clip;
	}

}

