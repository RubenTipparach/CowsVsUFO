using UnityEngine;
using System.Collections;


public enum Level
{
	sceneDark
		
}
/// <summary>
/// I was just having fun with colorful procedural backgrounds.
/// Having some random funness. Most of this code here was written for fun
/// and to teach myself how to procedurally draw stuff with polygons.
/// </summary>
[ExecuteInEditMode]
public class VertexLitSphere : MonoBehaviour {

	[SerializeField]
	float width = 10;

	[SerializeField]
	float height = 10;

	[SerializeField]
	Level level;

	// Use this for initialization
	void Start()
	{
	
		if (level == Level.sceneDark)
		{
			DrawScene2();
        }
	}

	void DrawScene2()
	{
		var meshFilter = GetComponent<MeshFilter>();
		var mesh = new Mesh();

		//lets start from origin.
		Vector3[] vertices = new Vector3[18];

		// 1/8 of the sphere... Yay!
		// Upper left corner
		vertices[0] = Vector3.up;
		vertices[1] = Quaternion.Euler(-45, 90, 0) * Vector3.forward;
		vertices[2] = Quaternion.Euler(-45, 0, 0) * Vector3.forward;

		vertices[3] = Vector3.right;
		vertices[4] = Quaternion.Euler(0, 45, 0) * Vector3.forward;
		vertices[5] = Vector3.forward;

		//lower left corner
		vertices[6] = Quaternion.Euler(45, 0, 0) * -Vector3.forward;
		vertices[7] = Quaternion.Euler(0, 45, 0) * Vector3.right;
		vertices[8] = -Vector3.forward;

		//lower right cornet
		vertices[9] = Quaternion.Euler(-45, -90, 0) * Vector3.forward;
		vertices[10] = Quaternion.Euler(0, -135, 0) * Vector3.forward;
		vertices[11] = Quaternion.Euler(0, -90, 0) * Vector3.forward;

		//upper right
		vertices[12] = Quaternion.Euler(0, -45, 0) * Vector3.forward;

		// Lower hemisphere shit!
		// upper left
		vertices[13] = Vector3.down;
		vertices[14] = Quaternion.Euler(45, 90, 0) * Vector3.forward;
		vertices[15] = Quaternion.Euler(45, 0, 0) * Vector3.forward;

		// lower left
		vertices[16] = Quaternion.Euler(-45, 0, 0) * -Vector3.forward;

		// lower right
		vertices[17] = Quaternion.Euler(45, -90, 0) * Vector3.forward;

		// Triangles and shit!
		int[] tri = new int[32 * 3];

		// 1/8 of the triangles upper hem
		tri[0] = 0;
		tri[1] = 1;
		tri[2] = 2;

		tri[3] = 1;
		tri[4] = 3;
		tri[5] = 4;

		tri[6] = 4;
		tri[7] = 2;
		tri[8] = 1;

		tri[9] = 4;
		tri[10] = 5;
		tri[11] = 2;

		//lower left (uh)
		tri[12] = 0;
		tri[13] = 6;
		tri[14] = 1;

		tri[15] = 1;
		tri[16] = 6;
		tri[17] = 7;

		tri[18] = 1;
		tri[19] = 7;
		tri[20] = 3;

		tri[21] = 6;
		tri[22] = 8;
		tri[23] = 7;

		//lower right (uh)
		tri[24] = 0;
		tri[25] = 9;
		tri[26] = 6;

		tri[27] = 9;
		tri[28] = 11;
		tri[29] = 10;

		tri[30] = 6;
		tri[31] = 9;
		tri[32] = 10;

		tri[33] = 6;
		tri[34] = 10;
		tri[35] = 8;

		//upper right
		tri[36] = 0;
		tri[37] = 2;
		tri[38] = 9;

		tri[39] = 9;
		tri[40] = 2;
		tri[41] = 12;

		tri[42] = 9;
		tri[43] = 12;
		tri[44] = 11;

		tri[45] = 2;
		tri[46] = 5;
		tri[47] = 12;

		// (bh) bottom hem
		// upper left
		tri[48] = 13;
		tri[49] = 15;
		tri[50] = 14;

		tri[51] = 14;
		tri[52] = 4;
		tri[53] = 3;

		tri[54] = 14;
		tri[55] = 15;
		tri[56] = 4;

		tri[57] = 15;
		tri[58] = 5;
		tri[59] = 4;

		//lower left
		tri[60] = 14;
		tri[61] = 3;
		tri[62] = 7;

		tri[63] = 16;
		tri[64] = 13;
		tri[65] = 14;

		tri[66] = 14;
		tri[67] = 7;
		tri[68] = 16;

		tri[69] = 16;
		tri[70] = 7;
		tri[71] = 8;

		//lower right
		tri[72] = 13;
		tri[73] = 16;
		tri[74] = 17;

		tri[75] = 16;
		tri[76] = 10;
		tri[77] = 17;

		tri[78] = 8;
		tri[79] = 10;
		tri[80] = 16;

		tri[81] = 10;
		tri[82] = 11;
		tri[83] = 17;

		//upper right
		tri[84] = 13;
		tri[85] = 17;
		tri[86] = 15;

		tri[87] = 11;
		tri[88] = 12;
		tri[89] = 17;

		tri[90] = 17;
		tri[91] = 12;
		tri[92] = 15;

		tri[93] = 12;
		tri[94] = 5;
		tri[95] = 15;

		//Debug.Log(printVectors(vertices));
		//Debug.Log(printTriangles(tri));

		// <-------------------------------------------> \\
		Color32[] colors = new Color32[vertices.Length];

		for (int i = 0; i < vertices.Length; i++)
		{
			colors[i] = new Color(0.00f, .005f, 0.05f, 1f);
			//colors[i] = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
		}

		//custom colors
		//colors[1] = new Color(1f, 1f, 1, 1);

		colors[0] = new Color(.0f, .5f, .2f, 1);
		colors[2] = new Color(.0f, .5f, .2f, 1);
		//colors[9] = new Color(.1f, .1f, .5f, 1);
		//colors[6] = new Color(.1f, .1f, .5f, 1);

		colors[5] = new Color(.0f, .5f, .2f, 1);
		colors[12] = new Color(.0f, .5f, .2f, 1);
		colors[11] = new Color(.0f, .5f, .2f, 1);
		//colors[10] = new Color(.7f, .5f, .5f, 1);
		//colors[8] = new Color(.7f, .5f, .5f, 1);
		//colors[7] = new Color(.7f, .5f, .5f, 1);
		//colors[3] = new Color(.5f, .5f, .1f, 1);
		//colors[4] = new Color(.5f, .5f, .1f, 1);

		Vector3[] normals = new Vector3[6];
		for (int i = 0; i < normals.Length; i++)
		{
			normals[i] = -Vector3.forward;
		}

		// Assign the lists.
		meshFilter.mesh = mesh;
		mesh.vertices = vertices;
		mesh.triangles = tri;
		mesh.colors32 = colors;
	}

	//this is for simple learnig purposes
	void DrawSemiSphere()
	{
		var meshFilter = GetComponent<MeshFilter>();
		var mesh = new Mesh();

		//lets start from origin.
		Vector3[] vertices = new Vector3[18];

		// 1/8 of the sphere... Yay!
		// Upper left corner
		vertices[0] = Vector3.up;
		vertices[1] = Quaternion.Euler(-45, 90, 0) * Vector3.forward;
        vertices[2] = Quaternion.Euler(-45, 0, 0) * Vector3.forward;

		vertices[3] = Vector3.right;
		vertices[4] = Quaternion.Euler(0, 45, 0) * Vector3.forward;
		vertices[5] = Vector3.forward;

		//lower left corner
		vertices[6] = Quaternion.Euler(45, 0, 0) * -Vector3.forward;
		vertices[7] = Quaternion.Euler(0, 45, 0) * Vector3.right;
		vertices[8] = -Vector3.forward;

		//lower right cornet
		vertices[9] = Quaternion.Euler(-45, -90, 0) * Vector3.forward;
		vertices[10] = Quaternion.Euler(0, -135, 0) * Vector3.forward;
		vertices[11] = Quaternion.Euler(0, -90, 0) * Vector3.forward;

		//upper right
		vertices[12] = Quaternion.Euler(0, -45, 0) * Vector3.forward;

		// Lower hemisphere shit!
		// upper left
		vertices[13] = Vector3.down;
		vertices[14] = Quaternion.Euler(45, 90, 0) * Vector3.forward;
		vertices[15] = Quaternion.Euler(45, 0, 0) * Vector3.forward;

		// lower left
		vertices[16] = Quaternion.Euler(-45, 0, 0) * -Vector3.forward;

		// lower right
		vertices[17] = Quaternion.Euler(45, -90, 0) * Vector3.forward;

		// Triangles and shit!
		int[] tri = new int[32 * 3];

		// 1/8 of the triangles upper hem
		tri[0] = 0;
		tri[1] = 1;
		tri[2] = 2;

		tri[3] = 1;
		tri[4] = 3;
		tri[5] = 4;

		tri[6] = 4;
		tri[7] = 2;
		tri[8] = 1;

		tri[9] = 4;
		tri[10] = 5;
		tri[11] = 2;

		//lower left (uh)
		tri[12] = 0;
		tri[13] = 6;
		tri[14] = 1;

		tri[15] = 1;
		tri[16] = 6;
		tri[17] = 7;

		tri[18] = 1;
		tri[19] = 7;
		tri[20] = 3;

		tri[21] = 6;
		tri[22] = 8;
		tri[23] = 7;

		//lower right (uh)
		tri[24] = 0;
		tri[25] = 9;
		tri[26] = 6;

		tri[27] = 9;
		tri[28] = 11;
		tri[29] = 10;

		tri[30] = 6;
		tri[31] = 9;
		tri[32] = 10;

		tri[33] = 6;
		tri[34] = 10;
		tri[35] = 8;

		//upper right
		tri[36] = 0;
		tri[37] = 2;
		tri[38] = 9;

		tri[39] = 9;
		tri[40] = 2;
		tri[41] = 12;

		tri[42] = 9;
		tri[43] = 12;
		tri[44] = 11;

		tri[45] = 2;
		tri[46] = 5;
		tri[47] = 12;

		// (bh) bottom hem
		// upper left
		tri[48] = 13;
		tri[49] = 15;
		tri[50] = 14;

		tri[51] = 14;
		tri[52] = 4;
		tri[53] = 3;

		tri[54] = 14;
		tri[55] = 15;
		tri[56] = 4;

		tri[57] = 15;
		tri[58] = 5;
		tri[59] = 4;

		//lower left
		tri[60] = 14;
		tri[61] = 3;
		tri[62] = 7;

		tri[63] = 16;
		tri[64] = 13;
		tri[65] = 14;

		tri[66] = 14;
		tri[67] = 7;
		tri[68] = 16;

		tri[69] = 16;
		tri[70] = 7;
		tri[71] = 8;

		//lower right
		tri[72] = 13;
		tri[73] = 16;
		tri[74] = 17;

		tri[75] = 16;
		tri[76] = 10;
		tri[77] = 17;

		tri[78] = 8;
		tri[79] = 10;
		tri[80] = 16;

		tri[81] = 10;
		tri[82] = 11;
		tri[83] = 17;

		//upper right
		tri[84] = 13;
		tri[85] = 17;
		tri[86] = 15;

		tri[87] = 11;
		tri[88] = 12;
		tri[89] = 17;

		tri[90] = 17;
		tri[91] = 12;
		tri[92] = 15;

		tri[93] = 12;
		tri[94] = 5;
		tri[95] = 15;

		//Debug.Log(printVectors(vertices));
		//Debug.Log(printTriangles(tri));

		// <-------------------------------------------> \\
		Color32[] colors = new Color32[vertices.Length];

		for (int i = 0; i < vertices.Length; i++)
		{
			colors[i] = new Color(0, .1f, .2f, 1f);
			//colors[i] = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
		}

		//custom colors
		colors[1] = new Color(1f, 1f, 1, 1);

		colors[0] = new Color(.9f, .5f, .5f, 1);
		colors[2] = new Color(0, .1f, .2f, 1f);
		colors[9] = new Color(.9f, .5f, .5f, 1);
		colors[6] = new Color(0, .1f, .2f, 1f);

		colors[5] = new Color(0, .1f, .2f, 1f);
		colors[12] = new Color(0, .1f, .2f, 1f);
		colors[11] = new Color(0, .1f, .2f, 1f);
		colors[10] = new Color(0, .1f, .2f, 1f);

		colors[8] = new Color(0, .1f, .2f, 1f);
		colors[7] = new Color(.9f, .5f, .5f, 1);
		colors[3] = new Color(0, .1f, .2f, 1f);
		colors[4] = new Color(0, .1f, .2f, 1f);

		Vector3[] normals = new Vector3[6];
		for (int i = 0; i < normals.Length; i++)
		{
			normals[i] = -Vector3.forward;
		}

		// Assign the lists.
		meshFilter.mesh = mesh;
		mesh.vertices = vertices;
		mesh.triangles = tri;
		mesh.colors32 = colors;
	}

	void DrawAnIcosahedron()
	{
		var meshFilter = GetComponent<MeshFilter>();
		var mesh = new Mesh();

		//lets start from origin.
		Vector3[] vertices = new Vector3[6];

		vertices[0] = new Vector3(0, 1, 0);
		vertices[1] = new Vector3(1, 0, 0);
		vertices[2] = new Vector3(0, 0, 1);
		vertices[3] = new Vector3(-1, 0, 0);
		vertices[4] = new Vector3(0, 0, -1);
		vertices[5] = new Vector3(0, -1, 0);

		int[] tri = new int[8 * 3];

		//inverted icosa
		//tri[0] = 0;
		//tri[1] = 2;
		//tri[2] = 1;

		//tri[3] = 0;
		//tri[4] = 3;
		//tri[5] = 2;

		//tri[6] = 0;
		//tri[7] = 4;
		//tri[8] = 3;

		//tri[9] = 0;
		//tri[10] = 1;
		//tri[11] = 4;

		//tri[12] = 1;
		//tri[13] = 2;
		//tri[14] = 5;

		//tri[15] = 2;
		//tri[16] = 3;
		//tri[17] = 5;

		//tri[18] = 3;
		//tri[19] = 4;
		//tri[20] = 5;

		//tri[21] = 4;
		//tri[22] = 1;
		//tri[23] = 5;

		//>-------------------------------<\\

		tri[0] = 0;
		tri[1] = 1;
		tri[2] = 2;

		tri[3] = 0;
		tri[4] = 2;
		tri[5] = 3;

		tri[6] = 0;
		tri[7] = 3;
		tri[8] = 4;

		tri[9] = 0;
		tri[10] = 4;
		tri[11] = 1;

		tri[12] = 2;
		tri[13] = 1;
		tri[14] = 5;

		tri[15] = 3;
		tri[16] = 2;
		tri[17] = 5;

		tri[18] = 4;
		tri[19] = 3;
		tri[20] = 5;

		tri[21] = 1;
		tri[22] = 4;
		tri[23] = 5;

		Color32[] colors = new Color32[vertices.Length];

		for (int i = 0; i < vertices.Length; i++)
		{
			colors[i] = new Color(0, 0, .1f, 1f);
		}

		colors[1] = new Color(.9f, .9f, 1, 1);

		Vector3[] normals = new Vector3[6];
		for (int i = 0; i < normals.Length; i++)
		{
			normals[i] = -Vector3.forward;
		}

		// Assign the lists.
		meshFilter.mesh = mesh;
		mesh.vertices = vertices;
		mesh.triangles = tri;
		mesh.colors32 = colors;
		//mesh.normals = normals;
	}

	/// <summary>
	/// Draws a grid of square polygons.
	/// </summary>
	/// <param name="rows">Row size.</param>
	/// <param name="columns">Column size.</param>
	void PatchOfSquare(int rows, int columns)
	{
		var meshFilter = GetComponent<MeshFilter>();
		var mesh = new Mesh();

		// vertices have an extra row/column for padding the edges.
		Vector3[] vertices = new Vector3[(rows + 1) * (columns + 1)];

		// x * y * number of triangles per cell * number of vertices per triangle
		int[] tri = new int[rows * columns * 2 * 3];

		// Now we programmaticall draw the patch.
		for (int i = 0; i < columns + 1; i++)
		{
			for (int j = 0; j < rows + 1; j++)
			{
				vertices[i * (columns + 1) + j] = new Vector3(width * i, height * j, 0);
			}
		}

		// Draw triangles.
		for (int i = 0; i < columns; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				int a = (i * (columns) + j) * 6; // this is the square offset.
				Debug.Log("pos" + (a) + "max" + tri.Length);
				// Our base line is a 2 x 2 square.
				tri[a] = i * (columns + 1) + j;                             // 0
				tri[a + 1] = i * (columns + 1) + j + columns + 1;               // 3
				tri[a + 2] = i * (columns + 1) + j + 1;                         // 1

				tri[a + 3] = i * (columns + 1) + j + columns + 1;       // 3
				tri[a + 4] = i * (columns + 1) + j + columns + 2;  // 4
				tri[a + 5] = i * (columns + 1) + j + 1;                         // 1
			}
		}

		Debug.Log(printVectors(vertices));
		Debug.Log(printTriangles(tri));
		// Assign the colors.
		Color32[] colors = new Color32[vertices.Length];

		for (int i = 0; i < vertices.Length; i++)
		{
			colors[i] = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
		}



		// Assign the lists.
		meshFilter.mesh = mesh;
		mesh.vertices = vertices;
		mesh.triangles = tri;
		mesh.colors32 = colors;

	}

	void StripOfSquares()
	{
		var meshFilter = GetComponent<MeshFilter>();
		var mesh = new Mesh();

		int numberOfStrips = 10;
		Vector3[] vertices = new Vector3[numberOfStrips * 2 + 2];
		int[] tri = new int[6 * numberOfStrips];

		vertices[0] = new Vector3(0, 0, 0); // v0
		vertices[vertices.Length/2] = new Vector3(0, height, 0); // v2

		/*
			vertices[0] = new Vector3(0, 0, 0);
			vertices[1] = new Vector3(width, 0, 0);
			vertices[2] = new Vector3(0, height, 0);
			vertices[3] = new Vector3(width, height, 0);
		 */

		// Create 4 strips.
		for (int i = 0; i < numberOfStrips; i++)
		{
			vertices[i + vertices.Length / 2 + 1] = new Vector3(width * i + width, height, 0); // v3
			vertices[i + 1] = new Vector3(width + width * i, 0, 0); // v1

			int a = i * 6;

			// goes through the following sequence and repeat.
			tri[a] = i;									// 0
			tri[a + 1] = i + vertices.Length / 2;		// 2
			tri[a + 2] = i + 1;							// 1

			tri[a + 3] = i + vertices.Length / 2;		// 2
			tri[a + 4] = i + vertices.Length / 2 + 1;	// 3
			tri[a + 5] = i + 1;							// 1
		}

		meshFilter.mesh = mesh;
		mesh.vertices = vertices;
		mesh.triangles = tri;

		Debug.Log(printVectors(vertices));
		Debug.Log(printTriangles(tri));
		//mesh.normals = normals;
		//mesh.uv = uv;

		Color32[] colors = new Color32[vertices.Length];

		for (int i = 0; i < vertices.Length; i++)
		{
			colors[i] = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)); 
        }

		mesh.colors32 = colors;
	}

	string printVectors(Vector3[] v)
	{
		string s = "";

		foreach( var v1 in v)
		{
			s += string.Format("[{0}]", v1);
		}

		return s;
	}

	string printTriangles(int[] tri)
	{
		string s = "";
		int tris = tri.Length / 3;

		for (int i = 0; i < tris; i++ )
		{
			s += string.Format("tri" + i + "[{0}, {1}, {2}]", tri[i * 3], tri[(i * 3 + 1)], tri[(i * 3 + 2)]);
		}

		return s;
	}

	void BasicSquare()
	{
		var meshFilter = GetComponent<MeshFilter>();
		var mesh = new Mesh();

		Vector3[] vertices = new Vector3[4];
		vertices[0] = new Vector3(0, 0, 0);
		vertices[1] = new Vector3(width, 0, 0);
		vertices[2] = new Vector3(0, height, 0);
		vertices[3] = new Vector3(width, height, 0);

		int[] tri = new int[6];
		tri[0] = 0;
		tri[1] = 2;
		tri[2] = 1;

		tri[3] = 2;
		tri[4] = 3;
		tri[5] = 1;

		Vector3[] normals = new Vector3[4];
		normals[0] = Vector3.forward;
		normals[1] = Vector3.forward;
		normals[2] = Vector3.forward;
		normals[3] = Vector3.forward;

		Vector2[] uv = new Vector2[4];
		uv[0] = new Vector2(0, 0);
		uv[1] = new Vector2(1, 0);
		uv[2] = new Vector2(0, 1);
		uv[3] = new Vector2(1, 1);

		//colors
		Color32[] colors = new Color32[vertices.Length];

		colors[0] = Color.cyan;
		colors[1] = Color.yellow;
		colors[2] = Color.blue;
		colors[3] = Color.green;

		//for (int i = 0; i < vertices.Length; i++ )
		//{
		//	colors[i] = Color32.Lerp(Color.red, Color.cyan, vertices[i].y);
		//}

		meshFilter.mesh = mesh;
		mesh.vertices = vertices;
		mesh.triangles = tri;
		//mesh.normals = normals;
		//mesh.uv = uv;
		mesh.colors32 = colors;
	}

	float[] randomOffset = new float[8];
	float[] lastOffset = new float[8];
	float[] getNewPattern = new float[8];

	float timer = 3;
	float coolDown = 3;

	bool[] up = new bool[8];

	// Update is called once per frame
	void Update () {
		
	}
}
