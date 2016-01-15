using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Key : MonoBehaviour {
	[SerializeField]private List<GameObject> _keyUsables = new List<GameObject>();
	private GameObject _player;
	PlayerInventory _playerInventory;
	// Use this for initialization
	void Start () {
		_player = GameObject.FindWithTag ("Player");
		_playerInventory = _player.GetComponent<PlayerInventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		GetKey ();
	}

	private void GetKey() {
		float distance = Vector3.Distance (transform.position, _player.transform.position);

		if (Input.GetKeyDown (KeyCode.Joystick1Button0) && distance < 3.5f) {
			
			_playerInventory.AddToList(this.gameObject);
			Destroy (this.gameObject);
		}
	}

	private void UseKey() {
		for (int i = 0; i < _keyUsables.Count; i++) {
			if (Vector3.Distance (_player.transform.position, _keyUsables [i].transform.position) < 3.5f && Input.GetKeyDown(KeyCode.Joystick1Button0)) {
				_playerInventory.RemoveFromList (_keyUsables [i]);
			}
		}
	}
}
