using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]private bool _inWater = false;
	private bool _floatUp = true;
	private bool _canJump = false;

	private float _changeDirection = 0.0f;
	private float _speed = 7.5f;
	private float _rotateSpeed = 50.0f;

	private Rigidbody _rb;

	public enum MovementState {
		walking = 0,
		swimming = 1,
		running = 2,
		jumping = 3
	};

	void Awake() {
		_rb = GetComponent<Rigidbody>();
	}

	void Update() {
		Swimming();
	}

	public void SetState(MovementState ms) {
		switch(ms) {
		case MovementState.walking:
			Walking();
			break;
		case MovementState.swimming:
			Swimming();
			break;
		case MovementState.running:
			Running();
			break;
		case MovementState.jumping:
			_canJump = true;
			break;
		default:
			break;
		}
	}

	void FixedUpdate() {
		Jumping();

	}

	void Walking () {
		if(!_inWater) {
			float x = Input.GetAxis("Horizontal");
			float z = Input.GetAxis("Vertical");
			Vector3 movement = new Vector3(x, 0f, z);
			_rb.velocity = movement * _speed;	
		}
	}

	void Swimming() {
		if(_inWater) {
			float joyRightX = Input.GetAxis("JoyRightX");
			float joyRightZ = Input.GetAxis("JoyRightY");
			float joyLeftx = Input.GetAxis("Horizontal");
			float joyLeftz = Input.GetAxis("Vertical");

			if(_rb.velocity == Vector3.zero) {
				if(_floatUp) {
					_changeDirection += Time.deltaTime / 40;

					Vector3 transformPos = transform.position;
					transformPos.y += _changeDirection;
					transform.position = transformPos;

					if(_changeDirection >= 0.02f) {
						_floatUp = false;
					}	
				}
				if(!_floatUp) {
					_changeDirection -= Time.deltaTime / 40;

					Vector3 transformPos = transform.position;
					transformPos.y -= _changeDirection;
					transform.position = transformPos;

					if(_changeDirection <= 0) {
						_floatUp = true;
					}
				}
			}

			 if(joyRightZ < 0.9f && joyRightZ > 0 || joyRightZ > -0.9f && joyRightZ < 0) {
				joyRightZ = 0;
			} else {
				transform.Rotate(new Vector3(joyRightZ * _rotateSpeed * Time.deltaTime, 0, 0));
			}

			Debug.Log("joyRightZ " + joyRightZ);
		}
	}

	void Running() {
		if(!_inWater) {
			float newSpeed = _speed * 2f;
			float x = Input.GetAxis("Horizontal");
			float z = Input.GetAxis("Vertical");
			Vector3 movement = new Vector3(x, 0f, z);
			_rb.velocity = movement * newSpeed;
		}
	}

	void Jumping() {
		if(!_inWater) {
			if(_canJump && IsGrounded()) {
				_rb.AddForce(Vector3.up * 300, ForceMode.Force);
				Debug.Log("Is jumping");
				_canJump = false;
			}
		}
	}

	bool IsGrounded (){
		return Physics.Linecast(transform.position , transform.position + (new Vector3(0,-0.6f,0)));
	}

}
