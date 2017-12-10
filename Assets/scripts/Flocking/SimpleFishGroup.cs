using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFishGroup : FlockingGroup {

	public int score = 30;
	float deletingDist = 20;

	public SimpleFishGroup(int numInstance, GameObject spawnCenterObj, float spawnRadius):  base(numInstance,spawnCenterObj,spawnRadius){
//		Debug.Log ("Simple Fish Group Constr");

	}

	public override bool checkTriggerBehaviour (Transform targetTrans)
	{
		
		float dist = Vector3.Distance (getFlockCenter (), targetTrans.position);

		if (dist < 2.0) {

			if (!this.getScored ()) {
				EventManager.TriggerEvent<FishCollisionEvent, Vector3, string> (targetTrans.position, "Player");
				ScoreManager.score += score;
			}

			base.setScored (true);
			return true;

		} else {
			return false;
		}
	}

	public override void triggerBehaviour ()
	{
//		Debug.Break ();
//		base.setGoalPos (simplePlayerControl.player.transform);
		GameObject goal = this.currGoal ();
		goal.transform.position = simplePlayerControl.player.transform.position;
//		goal.transform.position += new Vector3 (Random.Range (-3f, 3f),
//				Random.Range (-3f, 3f),
//				Random.Range (-3f, 3f));	
		goal.transform.parent = simplePlayerControl.player.transform;
	}

	public override int groupScore ()
	{
		return score;
	}

	public override float getDeleteDist(){
		return deletingDist;
	}
}
