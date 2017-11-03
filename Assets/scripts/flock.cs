using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class flock : MonoBehaviour {


	public float speed = 0.001f;
	float rotationSpeed = 4.0f;
	Vector3 averageHeading;
	Vector3 averagePosition;
	float neighbourDistance = 3.0f;
	float speedLimit = 3f;
	// Use this for initialization
	void Start () {
		speed = UnityEngine.Random.Range (0.5f, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (UnityEngine.Random.Range (0, 5) < 1)
			ApplyRules ();
		transform.Translate (0,0,Time.deltaTime*speed);
	}

	void ApplyRules(){
		GameObject[] gos;
		gos = GlobalFlockingManager.allFish;

		Vector3 vcenter = Vector3.zero;
		Vector3 vavoid = Vector3.zero;
		float gSpeed = 0.1f;

		Vector3 goalPos = GlobalFlockingManager.goalPos;

		float dist;
		int groupSize = 0;

		foreach (GameObject go in gos) {
			dist = Vector3.Distance (go.transform.position, this.transform.position);
			if (dist <= neighbourDistance) {
				vcenter += go.transform.position;
				groupSize++;

				if (dist < 1.0f) {
					vavoid += (this.transform.position - go.transform.transform.position);
				}

				flock anotherFlock = go.GetComponent <flock> ();
				gSpeed += anotherFlock.speed;
			}
			
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

}
