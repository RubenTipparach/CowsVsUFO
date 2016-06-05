using UnityEngine;
using System.Collections;

/// <summary>
/// Generates a fence parametrically.
/// </summary>
[ExecuteInEditMode]
public class FenceGenerator : MonoBehaviour {

	[SerializeField]
	GameObject fencePrefab;

	[SerializeField]
	private int rows = 10;

	[SerializeField]
	private float spaceFromCenter = 5;

	[SerializeField]
	private float spaceBetweenPolls = 5;

	/// <summary>
	/// Generates the fence.
	/// </summary>
	public void GenerateFence()
	{
		for (int i = 0; i < rows; i++)
		{
			GameObject f1 = GameObject.Instantiate(fencePrefab, new Vector3(spaceFromCenter, .5f, i * spaceBetweenPolls), Quaternion.identity) as GameObject;
			GameObject f2 = GameObject.Instantiate(fencePrefab, new Vector3(-spaceFromCenter, .5f, i * spaceBetweenPolls), Quaternion.identity) as GameObject;

			f1.transform.parent = this.transform;
			f2.transform.parent = this.transform;
		}

		Debug.Log("Fence Generated!");
	}

	/// <summary>
	/// Clears all the fence that are children of this.
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
