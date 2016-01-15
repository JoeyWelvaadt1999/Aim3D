using UnityEngine;
using System.Collections;


public class JoystickInput : MonoBehaviour {

	private PlayerMovement _pm;
	// Use this for initialization
	void Start () {
		_pm = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");


		if (x != 0 || z != 0) {
			if (Input.GetKey (KeyCode.Joystick1Button7)) {
				_pm.SetState (PlayerMovement.MovementState.running);
			} else {
				_pm.SetState (PlayerMovement.MovementState.walking);
			}
		} else {
			_pm.SetState (PlayerMovement.MovementState.idle);
		}

		if(Input.GetKeyDown(KeyCode.Joystick1Button3)) {//Joystick1Button3
			_pm.SetState(PlayerMovement.MovementState.jumping);
		}
	}

}
