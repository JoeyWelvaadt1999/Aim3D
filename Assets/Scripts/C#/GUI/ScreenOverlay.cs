using UnityEngine;
using System.Collections;

public class ScreenOverlay : MonoBehaviour {
	[SerializeField]private Texture _inWater;
	private PlayerMovement _playerMovement;

	void Start() {
		_playerMovement = GetComponentInParent<PlayerMovement> ();
	}

	void Setup() {

	}

	void OnGUI (){
		if (_playerMovement.InWater) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), _inWater);
		}
	}
}
