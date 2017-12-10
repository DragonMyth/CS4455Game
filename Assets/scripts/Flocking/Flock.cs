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
using System;
//using NUnit.Framework;

public class Flock : MonoBehaviour {


//	public float neighbourDistance = 1.0f;
//	public int speciesKind = 0;
	public float minIntraRepulseDist = 1.0f;
	public float minInterRepulseDist = 2.0f;
	public float lowerSpeed = 0.5f;
	public float higherSpeed = 1f;
	public float rotationSpeed = 5f;
	FlockingGroup flockGroup;


	Vector3 averageHeading;
	Vector3 averagePosition;
	float speedLimit = 1.5f;
	float speed;
	float speedUpScale;
	// Use this for initialization
	void Start () {
		speed = UnityEngine.Random.Range (lowerSpeed, higherSpeed);

		transform.rotation = UnityEngine.Random.rotation;
		speedUpScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.flockGroup != null && UnityEngine.Random.Range (0, 5) < 1){
			ApplyRules ();
		
			if (flockGroup.GetType () is SimpleFishGroup) {
				Debug.Log ("Current Goal is: " + this.flockGroup.currGoal ().transform.position);
			}
		}
		transform.Translate (0,0,speed*speedUpScale*Time.deltaTime);
	}

	void ApplyRules(){
		GameObject[] gos;

		gos = this.flockGroup.getFlocksInGroup ();

		Vector3 vcenter = Vector3.zero;
		Vector3 vavoid = Vector3.zero;
		float gSpeed = .1f;

		Vector3 goalPos = this.flockGroup.currGoal ().transform.position;

		float groupSize = 0;

		foreach (GameObject go in gos) {
			float dist = Vector3.Distance (go.transform.position, this.transform.position);

			vcenter += go.transform.position;
			groupSize++;

			if (dist < minIntraRepulseDist) {
				vavoid += (this.transform.position - go.transform.position);
			}

			Flock anotherFlock = go.GetComponent <Flock> ();
			gSpeed += anotherFlock.speed;

		}

		GameObject player = simplePlayerControl.player;
		float toPlayerDist = Vector3.Distance (player.transform.position, this.transform.position);

		if (toPlayerDist < minInterRepulseDist) {
			vavoid += 5*(this.transform.position - player.transform.position);
		}

		if (groupSize > 0) {
			vcenter = vcenter / groupSize + (goalPos - this.transform.position);
			speed = Math.Min (speedLimit, gSpeed / groupSize);

			Vector3 direction = (vcenter + vavoid) - this.transform.position;
			if (direction != Vector3.zero) {
				transform.rotation = Quaternion.Slerp (this.transform.rotation,
					Quaternion.LookRotation (direction), 
					rotationSpeed * Time.deltaTime);
				
				speedUpScale = ((float)Math.Tanh (direction.magnitude)+1);
			}
		}
	
	}

	public void setFlockGroup(FlockingGroup flockGroup){
		this.flockGroup = flockGroup; 

	}


	public FlockingGroup getFlockingGroup(){

		return this.flockGroup;
	}



}
