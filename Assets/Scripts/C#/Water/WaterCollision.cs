using UnityEngine;
using System.Collections;

public class WaterCollision : MonoBehaviour {
	void OnTriggerEnter(Collider coll) {
		if (coll.transform.tag == "Player") {
			PlayerMovement playerMovement = coll.GetComponent<PlayerMovement> ();
			playerMovement.InWater = true;
			coll.transform.GetComponent<Rigidbody>().useGravity = false;
		}
	}

	void OnTriggerExit(Collider coll) {
		if (coll.transform.tag == "Player") {
			PlayerMovement playerMovement = coll.GetComponent<PlayerMovement> ();
			playerMovement.InWater = false;
			coll.transform.GetComponent<Rigidbody>().useGravity = true;
		}
	}
}
