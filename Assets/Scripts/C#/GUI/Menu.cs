using UnityEngine;
//using UnityEditor.SceneManagement;
using System.Collections;
using System.IO;
using System;

public class Menu : MonoBehaviour {
	private AsyncOperation async;
	[SerializeField]private GUIStyle _buttonStyle;
	[SerializeField]private GUIStyle _boxStyle;
	[SerializeField]private GUIStyle _backgroundStyle;
	// Use this for initialization
	void Start () {
//		Application.CaptureScreenshot ("Game.jpg");
	}

	// Update is called once per frame
	void Update () {
//		if (async == null)
//			return;
	}

	void OnGUI () {
		Rect _con = new Rect (Screen.width / 2 - 370, Screen.height / 2 - 145, 300, 75);
		Rect _new = new Rect (Screen.width / 2 - 370, Screen.height / 2 - 70, 300, 75);
		Rect _load = new Rect (Screen.width / 2 - 370, Screen.height / 2 + 5, 300, 75);
		Rect _set = new Rect (Screen.width / 2 - 370, Screen.height / 2 + 80, 300, 75);
		Rect _exit = new Rect (Screen.width / 2 - 370, Screen.height / 2 + 155, 300, 75);

		GUI.Box (new Rect (0, 0, Screen.width, Screen.height), GUIContent.none, _backgroundStyle);

		GUI.Box (new Rect (Screen.width / 2 - 70, Screen.height / 2 - 145, 440, 375), GUIContent.none, _boxStyle);
		if (GUI.Button (_con, "Continue", _buttonStyle)) {
//			StartCoroutine (WaitForScene ());
			Application.LoadLevel(1);
		}else if (GUI.Button (_new, "New game", _buttonStyle)) {
		
		}else if (GUI.Button (_load, "Load game", _buttonStyle)) {

		}else if (GUI.Button (_set, "Settings", _buttonStyle)) {

		} else if (GUI.Button (_exit, "Exit", _buttonStyle)) {
			Application.Quit ();
		}

		//Hover 
		if (_con.Contains (Event.current.mousePosition)) {
//			GUI.DrawTexture (new Rect (Screen.width / 2 - 20, Screen.height / 2 - 95, 340, 150), GUIContent.none);
		} else if (_new.Contains (Event.current.mousePosition)) {
			
		} else if (_load.Contains (Event.current.mousePosition)) {
			
		} else if (_set.Contains (Event.current.mousePosition)) {
		
		} else if (_exit.Contains (Event.current.mousePosition)) {
		
		}
	}

//	public static Texture2D LoadPNG(string filePath) {
//
//		Texture2D tex = null;
//		byte[] fileData;
//
//		if (File.Exists(filePath))     {
//			fileData = File.ReadAllBytes(filePath);
//			tex = new Texture2D(2, 2);
//			tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
//		} else {
//			Debug.LogError ("Cant find file");
//		}
//		return tex;
//	}
//
//	IEnumerator WaitForScene() {
//		async = UnityEditor.SceneManagement.EditorSceneManager.LoadSceneAsync (1, UnityEngine.SceneManagement.LoadSceneMode.Single);
//		while (!async.isDone) {
//			int progress = (int)(async.progress * 100);
//			Debug.Log (progress);
//			yield return new WaitForEndOfFrame ();
//		}
//	}

}
