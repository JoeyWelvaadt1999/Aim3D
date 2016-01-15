using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {
	private List<GameObject> _keys = new List<GameObject>();
	// Use this for initialization
	public void AddToList (GameObject key) {
		_keys.Add (key);
	}

	public void RemoveFromList(GameObject key) {
		_keys.Remove (key);
	}
}
