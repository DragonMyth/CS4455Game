using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplePlayerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		Vector3 randDir = new Vector3 (Random.Range (-1, 1), Random.Range (-1, 1), Random.Range (-1, 1));

		this.transform.position += randDir * Time.deltaTime;
	}
}
