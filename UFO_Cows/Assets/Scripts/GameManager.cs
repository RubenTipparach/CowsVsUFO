using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// This class decicdes when it's time to stop.
/// </summary>
public class GameManager : MonoBehaviour {

	[SerializeField]
	UFO_Controller ufo;

	[SerializeField]
	int cowsNeededToWin;

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
		
		if(ufo.cowScore >= cowsNeededToWin)
		{
			// probably need some scene to end this.
			Application.Quit();
		}
	}
}
