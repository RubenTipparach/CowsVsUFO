using UnityEngine;
using System.Collections;

/// <summary>
/// What can a cow do? Other than sit there and become completely helpless.
/// </summary>
public class CowBehaviour : MonoBehaviour {

	[SerializeField]
	AudioClip cowNoise;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Called when [trigger enter]. The cow hit's the ship's trigger sphere,
	/// it gets abducted. A sound plays, and score counter goes up, and the cow disapears.
	/// </summary>
	/// <param name="collider">The collider.</param>
	void OnTriggerEnter(Collider collider)
	{
		var ufo = collider.GetComponent<UFO_Controller>();
		if (ufo != null)
		{
			PlayCowSound();
            ufo.cowScore += 1;
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// Plays the cow sound.
	/// </summary>
	public void PlayCowSound()
	{
		AudioSource.PlayClipAtPoint(cowNoise, transform.position);
	}
}
