//Team MacroHard:
//	  Binchen Hu, bhu77@gatech.edu, bhu77
//    Jiazheng Sun, jsun303 @gatech.edu, jsun303
//    Jingyi Li, jinli647 @gatech.edu, jinli647
//    Yunbo Zhang, yzhang3027 @gatech.edu, yzhang3027
//    Ziming He, zhe66 @gatech.edu, zhe66

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SimpleFishLocomotionControl : MonoBehaviour {

	// Use this for initialization

//	GameObject[] bodyParts;
	public float maxRotAngle = 45;
	public float rotFreq = 10;
	public float phaseOff = 0;
	int childCount;

	void Start () {
		childCount = this.transform.childCount;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		applyRotToChild (transform.GetChild (0).GetChild (0));

	}



	void applyRotToChild(Transform curr){
	
		Vector3 extend = curr.GetComponent <Collider> ().bounds.extents;

		Vector3 WorldMidpoint = curr.position + curr.forward * extend.z;


		float rotAngle = getTargetRot (Time.time);

		curr.RotateAround (WorldMidpoint,curr.up,rotAngle);

		if (curr.childCount > 0) {
		
			applyRotToChild (curr.GetChild (0));
		}
	
	}



	float getTargetRot(float time){

		return rotFreq * Mathf.Deg2Rad * maxRotAngle * Mathf.Cos (time * rotFreq);
	}

}
