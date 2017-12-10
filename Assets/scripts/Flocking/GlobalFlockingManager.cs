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
//using UnityEditor;
using JetBrains.Annotations;
using System.Text.RegularExpressions;

public class GlobalFlockingManager : MonoBehaviour {


	public static ArrayList allFishGroups;

	/*
	 * 0: simplefish
	 * 1: articulatedFish
	 * 2: Eel
	 */
	public GameObject[] allFishKinds;

	public GameObject player;

	public GameObject goalPrefab;

	public int tankSize = 30;

	public int maxGroup = 5;

	public int[] numInstance = {15,20,25};


	int spawnRad = 3;

	int minInteractionDist = 4;

	void Start () {

		allFishGroups = new ArrayList ();
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

			if (dist > tankSize) {

				deleteGroupContent (flockGroup);
				toBeDeletedIdx [groupIdx] = 1;


			} 

			if (flockGroup.getScored () && dist>flockGroup.getDeleteDist ()) {

				deleteGroupContent (flockGroup);
				toBeDeletedIdx [groupIdx] = 1;

				EventManager.TriggerEvent<FishCollisionEvent, Vector3, string> (player.transform.position, "Player");
				ScoreManager.score -= flockGroup.groupScore ()/1.5;
				Debug.Log ("LOST SCORE!!!!!!!!");

			}

			if (flockGroup.checkTriggerBehaviour (player.transform)) {
				flockGroup.triggerBehaviour ();
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
			Random.Range (1.0f, 5.0f),
			Random.Range (-this.tankSize, this.tankSize));
		
		GameObject spawnCenterObj = (GameObject)Instantiate (goalPrefab, groupSpawnCenter, Quaternion.identity);

		int fishKindId = Random.Range (0, this.allFishKinds.Length);

		GameObject flockPrefab = allFishKinds [fishKindId];

		FlockingGroup flockGroup = FlockingGroupFactory.createGroup (fishKindId, numInstance[fishKindId], spawnCenterObj, spawnRad);

		Vector3[] flockSpawnPos = flockGroup.getGroupSpawnPoints (); 

		GameObject[] flocks = new GameObject[numInstance[fishKindId]];

		for (int i = 0; i < numInstance[fishKindId]; i++) {

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
		Destroy (flockingGroup.currGoal ());

	}
}
