using UnityEngine;
using System.Collections;

public class SetCheckPoint : MonoBehaviour {
	void OnTriggerEnter(Collider coll) {
		if(coll.tag == "Player") {
			SaveLoad sl = FindObjectOfType<SaveLoad>();
			if(!sl.CheckPoints.Contains(this.gameObject)){
				sl.CheckPoint = this.gameObject;
				sl.CheckPoints.Add(sl.CheckPoint);
				sl.Save();
			}

		}
	}
}
