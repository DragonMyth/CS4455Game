using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleFishLocomotionControl : MonoBehaviour {

	// Use this for initialization

//	GameObject[] bodyParts;

	int childCount;
	void Start () {
		childCount = this.transform.childCount;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		for (int i = 1; i < childCount; i++) {
			GameObject bodyPart = transform.GetChild (i).gameObject;

			Vector3 bodyPartSize = bodyPart.GetComponent <Collider> ().bounds.size;

			//Debug.Log (bodyPartSize);
		}


	}
}
