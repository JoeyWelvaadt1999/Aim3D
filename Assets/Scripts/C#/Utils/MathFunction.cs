using UnityEngine;
using System.Collections;

public class MathFunction : MonoBehaviour {
	[SerializeField]private int _parLength;
	[SerializeField]private int _linLength;
	float[] _parValues;
	float[] _linValues;

	public float[] SetParabola(int offset, bool positive) {
		_parValues = new float[_parLength];

		for (int i = 0; i < _parLength; i++) {
			float xOffset = i - Mathf.CeilToInt (_parLength / 2);

			if(positive)
				_parValues [i] = -pow (xOffset) + 0 + offset; 
			else
				_parValues [i] = pow (xOffset) + 0 + offset; 
		}
		return _parValues;
	}
	
	public float[] SetLinear() {
		_linValues = new float[_linLength];
		for (int i = 0; i < _linLength; i++) {
			float offset = i;
			_linValues [i] = offset;
		}

		return _linValues;
	}

	float pow (float x) {
		return x * x;
	}
}