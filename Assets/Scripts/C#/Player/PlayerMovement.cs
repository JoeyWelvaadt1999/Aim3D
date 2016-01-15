using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]private bool _inWater = false;
	private bool _floatUp = true;
	private bool _canJump = false;
	private float _changeDirection = 0.0f;

	public bool InWater {
		get{ return _inWater;}
		set{ _inWater = value;}
	}

	//Speed
	private float _swimmingSpeed = 2.0f;
	private float _speed = 7.5f;
	private float _rotateSpeed = 3.0f;

	//Components
	private Rigidbody _rb;
	private Animator _animator;
	private AudioSource _audioSource;

	//Sounds
	[SerializeField]private AudioClip _runningSound;

	//Rotation
	float _currentXRotation;
	float _velocityXRotation;
	float _xRotation;
	float _currentYRotation;
	float _velocityYRotation;
	float _yRotation;
	float _smoothDamp = 0.1f;

	private MathFunction _drawParabola;
	private List<Coroutine> coroutines = new List<Coroutine>();
	private Coroutine co;

	public enum MovementState {
		walking = 0,
		swimming = 1,
		running = 2,
		jumping = 3,
		idle = 4
	};

	void Awake() {
		_rb = GetComponent<Rigidbody>();
		_animator = GetComponentInChildren<Animator> ();
		_drawParabola = GetComponent<MathFunction> ();
		_audioSource = GetComponent<AudioSource> ();
	}

	void Update() {
		if (!_inWater)
			Rotate (-20, 20);
		else
			Swimming ();
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
		case MovementState.idle:
//			if (!_animator.GetCurrentAnimatorStateInfo (0).IsName ("Idle") && _rb.velocity.x == 0 || _rb.velocity.z == 0 && co == null) 
//				_animator.Play ("Idle", -1, 0f);

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

			transform.Translate (new Vector3 (x * _speed * Time.deltaTime, 0, z * _speed * Time.deltaTime), Space.Self);

			if(!_animator.GetCurrentAnimatorStateInfo(0).IsName("Walk")) 
				_animator.Play ("Walk", -1, 0f);
		}
	}

	void Running() {
		if(!_inWater) {
			float x = Input.GetAxis ("Horizontal");
			float z = Input.GetAxis ("Vertical");

			if (_audioSource.isPlaying != _runningSound) {
				_audioSource.PlayOneShot (_runningSound);
			}
			if(!_animator.GetCurrentAnimatorStateInfo(0).IsName("Run")) 
				_animator.Play ("Run", -1, 0f);

			float newSpeed = _speed * 2f;
			transform.Translate (new Vector3 (x * newSpeed * Time.deltaTime, 0, z * newSpeed * Time.deltaTime), Space.Self);
		}
	}

	void Swimming() {
		if(_inWater) {
			Vector3 tpos = transform.position;
			tpos.y -= 0.1f;
			transform.position = tpos;

			Rotate(-int.MaxValue, int.MaxValue);
			if (Input.GetKey(KeyCode.Joystick1Button1)) {
				if (co == null) {
					co = StartCoroutine_Auto(CalculateAcceleration(false, 9, 0.5f)) as Coroutine;
				} 

				if(!_animator.GetCurrentAnimatorStateInfo(0).IsName("Swimming")) 
					_animator.Play ("Swimming", -1, 0f);
			}
		}
	}

	void Jumping() {
		if(!_inWater) {
			Debug.Log (IsGrounded ());
			if(_canJump && IsGrounded()) {
				if (!_animator.GetCurrentAnimatorStateInfo (0).IsName ("Jump")) {
					_animator.Play ("Jump", -1, 0f);
				}
				if (co == null) {
					co = StartCoroutine_Auto (CalculateJumpHeight()) as Coroutine;
				} 



				_canJump = false;
			}
		}
	}

	IEnumerator CalculateJumpHeight() {
		float[] values = _drawParabola.SetLinear();
		for (int i = 0; i < values.Length; i++) {
			float acceleration = values [i];
			_rb.velocity += new Vector3 (0,transform.up.y * acceleration,0);
			yield return new WaitForEndOfFrame ();
		}

		co = null;
	}

	IEnumerator CalculateAcceleration (bool positive, int offset, float wait) {
		float[] values = _drawParabola.SetParabola (offset,positive);
		for (int i = 0; i < values.Length; i++) {
			float acceleration = values[i] / 10;
			_rb.velocity += new Vector3 (transform.forward.x * acceleration, transform.forward.y * acceleration, transform.forward.z * acceleration);

			if (values [i] != 0)
				yield return new WaitForSeconds (wait);
			else 
				yield return new WaitForSeconds (0);
		}	

		co = null;

	} 

	void Rotate(int minClamp, int maxClamp) {
		float joyRightX = Input.GetAxis("JoyRightY");
		float joyRightY = Input.GetAxis("JoyRightX");

		_xRotation += joyRightX * _rotateSpeed;
		_yRotation += joyRightY * _rotateSpeed;

		_xRotation = Mathf.Clamp (_xRotation, minClamp, maxClamp);

		_currentXRotation = Mathf.SmoothDamp (_currentXRotation, _xRotation, ref _velocityXRotation, _smoothDamp);
		_currentYRotation = Mathf.SmoothDamp (_currentYRotation, _yRotation, ref _velocityYRotation, _smoothDamp);

		if (!_inWater) {
			Camera.main.transform.rotation = Quaternion.Euler (_currentXRotation, _currentYRotation, 0);
			transform.rotation = Quaternion.Euler (0, _currentYRotation, 0);
		} else {
			transform.rotation = Quaternion.Euler (_currentXRotation, _currentYRotation, 0);
		}
	}

	bool IsGrounded (){
		Debug.DrawRay (transform.position - new Vector3 (0, 1f, 0), Vector3.down);

		RaycastHit hit;
		if (Physics.Raycast (transform.position, new Vector3 (0, -1f, 0), out hit, 1.6f, LayerMask.GetMask("Terrain"))) {
			return true;
		} else
			return false;
	}
}