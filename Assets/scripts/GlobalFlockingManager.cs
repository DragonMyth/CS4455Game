using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GlobalFlockingManager : MonoBehaviour {

	// Use this for initialization
	public GameObject fishPrefab;
	public static int fishCount = 100;
	public static GameObject[] allFish = new GameObject[fishCount]; 
	public int tankSize = 5;


	public static Vector3 goalPos = Vector3.zero;
	void Start () {
		
		for(int i=0;i<fishCount;i++){
			Vector3 pos = new Vector3 (Random.Range (-tankSize, tankSize),
				              Random.Range (-tankSize, tankSize),
				              Random.Range (-tankSize, tankSize));
			allFish [i] = (GameObject)Instantiate (fishPrefab, pos, Quaternion.identity); 
		}


	}
	
	// Update is called once per frame
	void Update () {

		GameObject temp = GameObject.Find("Player");

		goalPos = temp.transform.position;
	}
}
