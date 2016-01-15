using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Missions : MonoBehaviour {
//	[SerializeField]private List<GameObject> _checkpoints = new List<GameObject>();
//	[SerializeField]private GameObject _icon;
	private int _current;

	void Update() {
		ShowCurrentCheckpoint ();
	}

	void ShowCurrentCheckpoint() {
//		_icon.transform.position = new Vector2 (_checkpoints [0].transform.position.x, _checkpoints [0].transform.position.y);
	}
}
