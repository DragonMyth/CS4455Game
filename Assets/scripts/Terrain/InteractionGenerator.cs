using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Policy;

public class InteractionGenerator : MonoBehaviour {

	int frameCount=0;

	public GameObject[] interactionPrefabs = new GameObject[0];

	public int[] interactionNums = new int[0];

	public int[] interactionProb = new int[0];

	void Start () {
		int frameCount=0;
	}


	
	// Update is called once per frame
	void Update () {
		if (frameCount <= 5) {
			frameCount ++;
		}

		if (frameCount == 1) {
			Mesh mesh = GetComponent <MeshFilter> ().mesh;

			Vector3[] vertices = mesh.vertices;

			Vector3[] normals = mesh.normals;

			for (int i = 0; i < interactionNums.Length; i++) {


				for (int j = 0; j < interactionNums [i]; j++) {
					int spawnInd = Random.Range (0, vertices.Length - 1);
					int spanProb = Random.Range (1, 100);
					if (spanProb < interactionProb [i]) {

						GameObject obj = Instantiate (interactionPrefabs [i], transform.TransformPoint (vertices [spawnInd]), Quaternion.identity);

						obj.transform.up = normals [spawnInd];

						obj.transform.parent = transform;
					}

				}
			}
		}
	}
}
