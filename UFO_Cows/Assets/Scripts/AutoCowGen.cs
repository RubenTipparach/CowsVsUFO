using UnityEngine;
using System.Collections;

/// <summary>
/// This class generates the cows when the game starts.
/// You can kind of see them "bounce" around. Maybe try to use Awake() for stability, 
/// and also It might just be the darn rigidbody acting up.
/// </summary>
public class AutoCowGen : MonoBehaviour {
	[SerializeField]
	GameObject cowPrefab;

	[SerializeField]
	private int rows = 10;

	[SerializeField]
	private float spaceFromCenter = 5;

	[SerializeField]
	private float minSpaceBetweenRowOfCows = 10;

	[SerializeField]
	private float maxSpaceBetweenRowOfCows = 50;


	void Start()
	{
		GenerateCows();
    }

	/// <summary>
	/// Generates the cows. These are the same methods as the editor ones.
	/// </summary>
	public void GenerateCows()
	{
		for (int i = 0; i < rows; i++)
		{

			int rotationSign = Random.Range(0, 1) == 1 ? 1 : -1;

			float spacing = Random.Range(minSpaceBetweenRowOfCows, maxSpaceBetweenRowOfCows);

			float xPos = Random.Range(0, spaceFromCenter * 2) - spaceFromCenter;

			GameObject f1 = GameObject.Instantiate(cowPrefab, new Vector3(xPos, 1f, i * spacing), Quaternion.Euler(0, 90 * rotationSign, 0)) as GameObject;

			f1.transform.parent = this.transform;
		}

		Debug.Log("Fence Generated!");
	}

	/// <summary>
	/// Clears this instance.
	/// </summary>
	public void Clear()
	{
		foreach (Transform child in transform)
		{
			if (child != null)
			{
				DestroyImmediate(child.gameObject);
			}
		}

		Debug.Log("Fence destroyed!");

	}

}
