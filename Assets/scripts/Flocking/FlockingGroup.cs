//Team MacroHard:
//	  Binchen Hu, bhu77@gatech.edu, bhu77
//    Jiazheng Sun, jsun303 @gatech.edu, jsun303
//    Jingyi Li, jinli647 @gatech.edu, jinli647
//    Yunbo Zhang, yzhang3027 @gatech.edu, yzhang3027
//    Ziming He, zhe66 @gatech.edu, zhe66

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingGroup {
	int fishKindId;
	int numInstance;
	Vector3 goalPos;
	Vector3[] groupFlockSpawnPoints;
	GameObject[] allFlocks;

	public FlockingGroup(int fishKindId, int numInstance, Vector3 spawnCenter, int spawnRadius){
		this.fishKindId = fishKindId;
		this.numInstance = numInstance;
		this.goalPos = spawnCenter;
		this.groupFlockSpawnPoints = new Vector3[numInstance];
		this.allFlocks = new GameObject[numInstance];
		instantiateFlocks (spawnCenter,spawnRadius);

	}


	void instantiateFlocks(Vector3 spawnCenter, int spawnRadius){
		for (int i = 0; i < this.numInstance; i++) {
			Vector3 spawnPos = spawnCenter + new Vector3 (Random.Range (-spawnRadius, spawnRadius),
				Mathf.Min(3,Random.Range (-spawnRadius, spawnRadius)),
				Random.Range (-spawnRadius, spawnRadius));
			this.groupFlockSpawnPoints [i] = spawnPos;
		} 

	}

	public void setGoalPos(Vector3 newGoal){

		this.goalPos = newGoal;
	}


	public Vector3 currGoal(){
		
		return this.goalPos;
	}

	public Vector3[] getGroupSpawnPoints(){
		
		return groupFlockSpawnPoints;
	}

	public void setFlock(GameObject[] flockGos){
		
		allFlocks = flockGos;

	}

	public GameObject[] getFlocksInGroup(){
		
		return allFlocks;
	
	}

	public Vector3 getFlockCenter(){

		Vector3 flockCenter = Vector3.zero;
		for (int i = 0; i < this.allFlocks.Length; i++) {
			
			flockCenter += allFlocks [i].transform.position;

		}

		return flockCenter/this.allFlocks.Length;

	}
}
