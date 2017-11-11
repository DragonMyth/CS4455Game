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
using UnityEditor;
using JetBrains.Annotations;
using System.Text.RegularExpressions;

public class GlobalFlockingManager : MonoBehaviour {


	public static ArrayList allFishGroups = new ArrayList();

	public GameObject[] allFishKinds;

	public GameObject player;


	public int tankSize = 30;

	public int maxGroup = 5;

	public int numInstance = 15;


	int spawnRad = 3;

	int minInteractionDist = 5;

	void Start () {

		for (int groupNum = 0; groupNum < maxGroup; groupNum++) {

			instantiatOneGroup ();

		}

	}


	void Update () {


		int[] toBeDeletedIdx = new int[allFishGroups.Count];
		for (int groupIdx=0; groupIdx < allFishGroups.Count; groupIdx++) {

			FlockingGroup flockGroup = ((FlockingGroup)allFishGroups [groupIdx]);


			Vector3 groupCenter = flockGroup.getFlockCenter ();

			float dist = Vector3.Distance (groupCenter, player.transform.position);

//			Debug.Log ("Dist is :" + dist);

			if (dist > tankSize) {

//				Debug.Log ("DElete COntent!!");

				deleteGroupContent (flockGroup);
				toBeDeletedIdx [groupIdx] = 1;
			} else if (dist < tankSize && dist > minInteractionDist) {

				flockGroup.setGoalPos (groupCenter);
			
			} else if (dist < minInteractionDist) {
			
				flockGroup.setGoalPos (player.transform.position);
			}
		
		}

		ArrayList newAllFishGroups = new ArrayList();
		for (int i = 0; i < toBeDeletedIdx.Length; i++) {
			if (toBeDeletedIdx [i] != 1) {
				newAllFishGroups.Add (allFishGroups[i]);
			}
		}

		allFishGroups = newAllFishGroups;

		int currGroupsSize = allFishGroups.Count;

		for (; currGroupsSize < maxGroup; currGroupsSize++) {
			instantiatOneGroup ();
		
		}

	}



	void instantiatOneGroup(){

		Vector3 playerPos = player.transform.position;

		Vector3 groupSpawnCenter = playerPos + new Vector3 (Random.Range (-this.tankSize, this.tankSize),
			Random.Range (-10, 10),
			Random.Range (-this.tankSize, this.tankSize));

		int fishKindId = Random.Range (0, this.allFishKinds.Length);

		GameObject flockPrefab = allFishKinds [fishKindId];

		FlockingGroup flockGroup = new FlockingGroup (fishKindId, numInstance, groupSpawnCenter, spawnRad);

		Vector3[] flockSpawnPos = flockGroup.getGroupSpawnPoints (); 

		GameObject[] flocks = new GameObject[numInstance];

		for (int i = 0; i < numInstance; i++) {

			GameObject flockGo = (GameObject)Instantiate (flockPrefab, flockSpawnPos[i], Quaternion.identity);

			Flock flock = flockGo.GetComponent <Flock> ();

			flock.setFlockGroup (flockGroup);

			flocks [i] = flockGo;

		}

		flockGroup.setFlock (flocks);

		allFishGroups.Add (flockGroup);
	}

	void deleteGroupContent(FlockingGroup flockingGroup){

		foreach (GameObject go in flockingGroup.getFlocksInGroup ()) {
		
			Destroy (go);
		
		}
	
	
	}
}
