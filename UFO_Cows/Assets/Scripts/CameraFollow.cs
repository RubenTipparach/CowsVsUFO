using UnityEngine;
using System.Collections;

/// <summary>
/// This camera smoothly follows the spacecraft around.
/// </summary>
public class CameraFollow : MonoBehaviour {

	[SerializeField]
	private Transform _targetCurrentPos;

	//[SerializeField]
	//private Vector3 _offset;

	[SerializeField]
	private float _slerpSpeed;

	private Vector3 _currentPos;

	private Vector3 _relativeOffset;

	// Use this for initialization
	void Start () {
		// automatically get the offset based on displacement of camera at the start of the game.
		_relativeOffset = (transform.position - _targetCurrentPos.position);
		UpdatePosition();

	}

	// Update is called once per frame
	void FixedUpdate () {
		UpdatePosition();
		// some linear interpolation here.
        transform.position = Vector3.Lerp(transform.position, _currentPos, _slerpSpeed * Time.deltaTime);

	}

	/// <summary>
	/// Updates the position, sets the camera's "anchor" point.
	/// </summary>
	void UpdatePosition() 
	{
		_currentPos = _relativeOffset + _targetCurrentPos.position;
	}
}
