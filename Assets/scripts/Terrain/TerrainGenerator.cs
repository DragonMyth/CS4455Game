/**
 * Team MacroHard
 * Binchen Hu
 * Jiazheng Sun
 * Jingyi Li
 * Yunbo Zhang
 * Ziming He
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

	// Use this for initialization
	public float deltaScale = 10.0f;
	public int heightScale = 10;

	public int obstableHeight = 2;
	void Start () {
		Random.InitState (24);

		Mesh mesh = GetComponent <MeshFilter> ().mesh;
		Vector3[] vertices = mesh.vertices;

		for (int v = 0; v < vertices.Length; v++) {

			int randObstacles = Random.Range (0, 500);

			float obstacle = 1f;
			if (randObstacles < 5) {
				obstacle = obstableHeight;
			}

			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / deltaScale,
				(vertices [v].z + this.transform.position.z) / deltaScale) * heightScale * obstacle;
		}


		mesh.vertices = vertices;
		mesh.RecalculateBounds ();
		mesh.RecalculateNormals ();

		this.gameObject.AddComponent<MeshCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
