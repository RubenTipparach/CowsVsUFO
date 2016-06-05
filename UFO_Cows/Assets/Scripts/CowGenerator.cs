using UnityEngine;
using System.Collections;

/// <summary>
/// Generates a herd of cows, this is an Editor friendly script.
/// Though I haven't figured out a good way to handle cleaning things up.
/// </summary>
[ExecuteInEditMode]
public class CowGenerator : MonoBehaviour {

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

	/// <summary>
	/// Generates the cows.
	/// </summary>
	public void GenerateCows()
	{
		for (int i = 0; i < rows; i++)
		{

			int rotationSign = Random.Range(0, 2) == 1 ? 1 : -1;

			float spacing = Random.Range(minSpaceBetweenRowOfCows, maxSpaceBetweenRowOfCows);

			float xPos = Random.Range(0, spaceFromCenter * 2) - spaceFromCenter;

			GameObject f1 = GameObject.Instantiate(cowPrefab, new Vector3(xPos, 1f, i * spacing), Quaternion.Euler(0, 90 * rotationSign, 0)) as GameObject;

			f1.transform.parent = this.transform;
		}

		Debug.Log("Cows Generated!");
	}

	/// <summary>
	/// Clears all the cows that are children of this object.
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

		Debug.Log("Cows destroyed!");
	}
}
