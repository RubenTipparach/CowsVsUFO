using UnityEngine;
using System.Collections;

// Rotate the space for extra zen.
public class RotateBckg : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(-Vector3.right * Time.deltaTime);
	}
}
