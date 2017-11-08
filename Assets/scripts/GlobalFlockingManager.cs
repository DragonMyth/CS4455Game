using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GlobalFlockingManager : MonoBehaviour {

	// Use this for initialization
	public GameObject[] fishPrefabs;
	public static int[] fishCounts = {50,50};

	public static Hashtable allFishTable = new Hashtable();

	public int tankSize = 5;


	public static Vector3 goalPos = Vector3.zero;


	void Start () {

	
		for (int i = 0; i < fishPrefabs.Length; i++) {
			allFishTable.Add (i,new GameObject[fishCounts[i]]);
		}

		foreach(int key in allFishTable.Keys){
			GameObject[] allFishofKind = allFishTable [key] as GameObject[];

			for (int j=0;j<allFishofKind.Length;j++){
				Vector3 pos = new Vector3 (Random.Range (-tankSize, tankSize),
					Random.Range (-tankSize, tankSize),
					Random.Range (-tankSize, tankSize));
				allFishofKind [j] = (GameObject)Instantiate (fishPrefabs[key], pos, Quaternion.identity); 

			}
		}
			


	}
	
	// Update is called once per frame
	void Update () {

		GameObject temp = GameObject.Find("Player");

		goalPos = temp.transform.position;
	}
}
