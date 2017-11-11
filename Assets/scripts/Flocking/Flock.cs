//Team MacroHard:
//	  Binchen Hu, bhu77@gatech.edu, bhu77
//    Jiazheng Sun, jsun303 @gatech.edu, jsun303
//    Jingyi Li, jinli647 @gatech.edu, jinli647
//    Yunbo Zhang, yzhang3027 @gatech.edu, yzhang3027
//    Ziming He, zhe66 @gatech.edu, zhe66

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NUnit.Framework;

public class Flock : MonoBehaviour {


	public float speed = 0.1f;
	public float neighbourDistance = 1.0f;
	public int speciesKind = 0;
	public float minRepulseDist = 1.0f;


	FlockingGroup flockGroup;

	float rotationSpeed = 4.0f;
	Vector3 averageHeading;
	Vector3 averagePosition;
	float speedLimit = 6f;

	// Use this for initialization
	void Start () {
		speed = UnityEngine.Random.Range (0.5f, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.flockGroup != null && UnityEngine.Random.Range (0, 4) < 1)
			ApplyRules ();
		transform.Translate (0,0,Time.deltaTime*speed);
	}

	void ApplyRules(){
		GameObject[] gos;

		gos = this.flockGroup.getFlocksInGroup ();
//		Debug.Log (gos.Length);

		Vector3 vcenter = Vector3.zero;
		Vector3 vavoid = Vector3.zero;
		float gSpeed = .1f;


		Vector3 goalPos = this.flockGroup.currGoal ();


		float dist;
		int groupSize = 0;

		foreach (GameObject go in gos) {
			dist = Vector3.Distance (go.transform.position, this.transform.position);

			vcenter += go.transform.position;
			groupSize++;

			if (dist < minRepulseDist) {
				vavoid += (this.transform.position - go.transform.transform.position);
			}

			Flock anotherFlock = go.GetComponent <Flock> ();
			gSpeed += anotherFlock.speed;

		}

		if (groupSize > 0) {
			vcenter = vcenter / groupSize + (goalPos - this.transform.position);
			speed = Math.Min (speedLimit, gSpeed / groupSize);

			Vector3 direction = (vcenter + vavoid) - this.transform.position;
			if (direction != Vector3.zero) {
				transform.rotation = Quaternion.Slerp (this.transform.rotation,
					Quaternion.LookRotation (direction), 
					rotationSpeed * Time.deltaTime);
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
