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

public class FlockingGroup {
	int numInstance;
	GameObject goalPos;
	Vector3[] groupFlockSpawnPoints;
	GameObject[] allFlocks;
	bool scored;
	float deletingDist;

	public FlockingGroup(int numInstance, GameObject goalObj, float spawnRadius){
		this.numInstance = numInstance;
		this.goalPos = goalObj;
		this.groupFlockSpawnPoints = new Vector3[numInstance];
		this.allFlocks = new GameObject[numInstance];
		this.scored = false;
		instantiateFlocks (goalObj.transform.position,spawnRadius);

	}


	void instantiateFlocks(Vector3 spawnCenter, float spawnRadius){
		for (int i = 0; i < this.numInstance; i++) {
			Vector3 spawnPos = spawnCenter + new Vector3 (Random.Range (-spawnRadius, spawnRadius),
				Random.Range (1.0f, spawnRadius),
				Random.Range (-spawnRadius, spawnRadius));
			this.groupFlockSpawnPoints [i] = spawnPos;
		} 

	}
		

	public GameObject currGoal(){
		
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


	public bool getScored(){
		return scored;
	}

	public void setScored(bool scored){
		this.scored = scored;
	}

	public virtual bool checkTriggerBehaviour(Transform targetTrans){
		return false;
	}

	public virtual void triggerBehaviour(){
		return;
	}

	public virtual int groupScore(){
		return 0;
	}

	public virtual float getDeleteDist(){
		return deletingDist;
	}
}
