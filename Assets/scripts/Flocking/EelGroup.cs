using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework.Internal.Filters;

public class EelGroup : FlockingGroup {

	public int score  = 100;
	float deletingDist = 15;

	public EelGroup(int numInstance, GameObject spawnCenterObj, float spawnRadius):  base(numInstance,spawnCenterObj,spawnRadius){
		//		Debug.Log ("Simple Fish Group Constr");

	}

	public override bool checkTriggerBehaviour (Transform targetTrans)
	{
		float dist = Vector3.Distance (getFlockCenter (), targetTrans.position);

		if (dist < 2.0 && !this.getScored ()) {
			Debug.Log ("THIS IS Eel GROUP!!!!!!!");
			if (!this.getScored ()) {
				EventManager.TriggerEvent<EelCollisionEvent, Vector3, string> (targetTrans.position, "Player");
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
		
		GameObject goal = this.currGoal();
		int side = Random.Range (0, 2);
		if (side == 0) {
			goal.transform.position = simplePlayerControl.player.transform.position + simplePlayerControl.player.transform.right+simplePlayerControl.player.transform.forward * 3;

		} else if(side ==1) {
			goal.transform.position = simplePlayerControl.player.transform.position - simplePlayerControl.player.transform.right+simplePlayerControl.player.transform.forward * 3;

		}

		goal.transform.position += new Vector3 (Random.Range (-1f, 1f),
			Random.Range (-1f, 1f),
			Random.Range (-1f, 1f));		
		goal.transform.parent = simplePlayerControl.player.transform;
		Debug.Log ("Simple fish flock goal: " + base.currGoal ().transform.position);

	}

	public override int groupScore ()
	{
		return score;
	}

	public override float getDeleteDist(){
		return deletingDist;
	}
}
