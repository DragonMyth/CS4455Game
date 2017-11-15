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

public class clearPhysicsOnPlayer : MonoBehaviour {

	// Use this for initialization
	Rigidbody rbody;
	void Start () {
		rbody = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {


		rbody.AddForce (Vector3.zero,ForceMode.VelocityChange);
		rbody.AddTorque (Vector3.zero,ForceMode.VelocityChange);
		rbody.velocity = Vector3.zero;
		rbody.angularVelocity = Vector3.zero;
		transform.rotation = Quaternion.identity;

	}
}
