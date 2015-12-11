using UnityEngine;
using System.Collections;

public class ScreenOverlay : MonoBehaviour {
	[SerializeField]private Texture _inWater;
	void Setup() {

	}

	void OnGUI (){
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), _inWater);
	}
}
