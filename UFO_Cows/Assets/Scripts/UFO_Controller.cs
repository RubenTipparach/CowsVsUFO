using UnityEngine;
using System.Collections;

/// <summary>
/// Main class for the UFO spaceship.
/// </summary>
public class UFO_Controller : MonoBehaviour {

	[SerializeField]
	private float _forceAmount;

	[SerializeField]
	float sideRange;

	[SerializeField]
	GameObject _cone;

	[SerializeField]
	float lifeForce = 10;

	[SerializeField]
	float radiusOfBeam = 2;

	public int cowScore = 0;

	private Rigidbody _rigidbody;

	//[SerializeField]
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody>();
		//var audio = GetComponent<AudioSource>
    }

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			Ray ray = new Ray(transform.position, Vector3.down *  10);
			RaycastHit hit;
			_cone.SetActive(true); // turn on the UFO "flashlight"

			// cast some thick raysat the ground.
			if (Physics.SphereCast(ray, radiusOfBeam, out hit))
			{
				//Debug.Log(hit.transform.gameObject.name + " hit!");
				// Abduct if its a cow!
				var aCow = hit.transform.GetComponent<CowBehaviour>();
                if (aCow != null)
				{
					Vector3 pull = (transform.position - aCow.transform.position ).normalized;
					//Debug.Log(pull);
					// Pulls the cows toward your ship.
					aCow.GetComponent<Rigidbody>().AddForce(pull * lifeForce, ForceMode.Force);
				}
			}
		}

		if(Input.GetKeyUp(KeyCode.Space))
		{
			_cone.SetActive(false); // turn off the UFO "flashlight"
		}
	}

	/// <summary>
	/// Takes in input from WASD or arrow keys.
	/// </summary>
	void FixedUpdate()
	{
		float forward = Input.GetAxis("Vertical");
		float right = Input.GetAxis("Horizontal");

		_rigidbody.AddForce(new Vector3(right, 0, forward) * _forceAmount, ForceMode.Impulse);

		float centerOffset = Mathf.Abs(transform.position.x);

		if(centerOffset > sideRange)
		{
			_rigidbody.velocity = Vector3.zero;
			transform.Translate((sideRange - centerOffset) * Mathf.Sign(transform.position.x) *.1f, 0, 0);
		}
	}
}
