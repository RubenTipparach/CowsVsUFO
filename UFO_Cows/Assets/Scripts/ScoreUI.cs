using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Updates the score in the UI.
/// </summary>
public class ScoreUI : MonoBehaviour {

	[SerializeField]
	UFO_Controller ufo;

	Text _scoreText;

	// Use this for initialization
	void Start ()
	{
		_scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ufo != null)
		{
			_scoreText.text = string.Format("Score: {0}", ufo.cowScore);
		}
	}
}
