using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class simplePlayerControl : MonoBehaviour {


	public float speed  = 10f; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Camera cam = GetComponentInChildren<Camera>();

		float lh = Input.GetAxisRaw("Horizontal");
		float lv = Input.GetAxisRaw("Vertical");



		this.transform.position += (cam.transform.forward * lv * speed + cam.transform.right*lh*speed);

		Debug.Log (this.transform.position);
//		this.transform.Translate (cam.transform.forward*lv*speed*Time.deltaTime);


	}
}
