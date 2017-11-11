﻿//Team MacroHard:
//	  Binchen Hu, bhu77@gatech.edu, bhu77
//    Jiazheng Sun, jsun303 @gatech.edu, jsun303
//    Jingyi Li, jinli647 @gatech.edu, jinli647
//    Yunbo Zhang, yzhang3027 @gatech.edu, yzhang3027
//    Ziming He, zhe66 @gatech.edu, zhe66

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TerrainGenerator : MonoBehaviour {

	// Use this for initialization
	float deltaScale = 10.0f;
	int heightScale = 10;
	void Start () {

		Mesh mesh = GetComponent <MeshFilter> ().mesh;
		Vector3[] vertices = mesh.vertices;

		for (int v = 0; v < vertices.Length; v++) {
			vertices [v].y = Mathf.PerlinNoise ((vertices [v].x + this.transform.position.x) / deltaScale,
				(vertices [v].z + this.transform.position.z) / deltaScale) * heightScale;
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
