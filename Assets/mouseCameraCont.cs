using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCameraCont : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public float sensitivity = 0.001f;
	public float maxYAngle = 80f;
	private Vector2 currentRotation;
	public GameObject player;

//	public Transform camPos;



	void Update()
	{

		currentRotation.x = Input.GetAxis("Mouse X") * sensitivity;
		currentRotation.y = Input.GetAxis("Mouse Y") * sensitivity;
		currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
		currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);



		if(!player.GetComponent<simplePlayerControl>().isPaused)
		{
			this.transform.RotateAround(player.transform.position, -this.transform.right, currentRotation.y);
			this.transform.RotateAround(player.transform.position, Vector3.up, currentRotation.x);

			Cursor.lockState = CursorLockMode.Locked;
		}

//		this.transform.position = Vector3.Slerp (transform.position, camPos.position, 1);
//		this.transform.forward = Vector3.Slerp (transform.forward, player.transform.forward, 1);
//


	}
}
