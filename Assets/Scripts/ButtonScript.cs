using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {


	public Texture2D	cursorTexture;
	public Vector2 		hotSpot = Vector2.zero;
	public CursorMode	cursorMode = CursorMode.Auto;

	// Use this for initialization
	void Start () {
//		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
//		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame() {
		Debug.Log ("GameStart");
	}

	public void QuitGame() {
		Application.Quit();
	}

	public void PauseGame() {
		Time.timeScale = 0;
	}

	public void ResumeGame() {
		Time.timeScale = 1;
	}

}
