using UnityEngine;
using System.Collections;

public class AudioSourceScript : MonoBehaviour {

	public static AudioSourceScript asc;

	void Start() { asc = this; }

	public void Play() {
		GetComponent<AudioSource> ().PlayDelayed (0f);
	}
}
