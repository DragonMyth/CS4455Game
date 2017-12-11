using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ArticFishGroup : FlockingGroup {


	public int score = 70;
	float deletingDist = 15;

	public ArticFishGroup(int numInstance, GameObject spawnCenterObj, float spawnRadius):  base(numInstance,spawnCenterObj,spawnRadius){
	}

	public override bool checkTriggerBehaviour (Transform targetTrans)
	{
		float dist = Vector3.Distance (getFlockCenter (), targetTrans.position);

		if (dist < 2.0) {
			Debug.Log ("THIS IS Articulated Fish GROUP!!!!!!!");
			if (!this.getScored ()) {
				EventManager.TriggerEvent<FishCollisionEvent, Vector3, string> (targetTrans.position, "Player");
				ScoreManager.score += score;
			}

			base.setScored (true);
			base.illuminateFlocks ();
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
			goal.transform.position = simplePlayerControl.player.transform.position + simplePlayerControl.player.transform.up * 3+simplePlayerControl.player.transform.forward * 7.5f;

		} else if(side ==1) {
			goal.transform.position = simplePlayerControl.player.transform.position - simplePlayerControl.player.transform.up * 3+simplePlayerControl.player.transform.forward * 7.5f;

		}
		goal.transform.position += new Vector3 (Random.Range (-1.5f, 1.5f),
			Random.Range (-1.5f, 1.5f),
			Random.Range (-1.5f, 1.5f));	

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
