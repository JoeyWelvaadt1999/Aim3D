using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveLoad : MonoBehaviour {
	[SerializeField]private GameObject s_CheckPoint;
	private List<GameObject> _checkPoints = new List<GameObject>();
	private Vector3 _newPosition = new Vector3();
	public GameObject CheckPoint {
		get {
			return s_CheckPoint;
		} set {
			s_CheckPoint = value;
		}
	}

	public List<GameObject> CheckPoints {
		get {
			return _checkPoints;
		}
	}

	public Vector3 NewPosition {
		get {
			return _newPosition;
		}
	}

	// Use this for initialization
	public void Save () {
		WWWForm form = new WWWForm();
		form.AddField("PositionX", Mathf.RoundToInt(s_CheckPoint.transform.position.x));//Position x
		form.AddField("PositionY", Mathf.RoundToInt(s_CheckPoint.transform.position.y));//Position y
		form.AddField("PositionZ", Mathf.RoundToInt(s_CheckPoint.transform.position.z));//Position z
		WWW www = new WWW("http://www.joeywelvaadt.com/aim3d/saveload/save.php", form);
		StartCoroutine(WaitForSaveRequest(www));
	}
	
	IEnumerator WaitForSaveRequest(WWW www) {
		yield return www;
		if(www.error != null){
			Debug.Log("Error: " + www.error);
		} else {
			Debug.Log("Ok: " + www.text);
		}
	}

	public void Load () {
		WWW www = new WWW("http://www.joeywelvaadt.com/aim3d/saveload/load.php");
		StartCoroutine(WaitForLoadRequest(www));
	}

	IEnumerator WaitForLoadRequest(WWW www) {
		yield return www;

		string incomingData = www.text;
		print(incomingData);
		string[] split = incomingData.Split("\n"[0]);
		for(int i = 0; i < split.Length; i++) {
			float posX = float.Parse(split[0]);
			float posY = float.Parse(split[1]);
			float posZ = float.Parse(split[2]);
			
			_newPosition = new Vector3(posX, posY, posZ);
		}
		
		GameObject.FindWithTag("Player").transform.position = _newPosition;
	}
}
