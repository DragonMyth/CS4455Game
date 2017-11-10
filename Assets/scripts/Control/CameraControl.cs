using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public float sensitivity = 0.001f;
	public float maxYAngle = 80f;
	private Vector2 currentRotation;
	public GameObject player;



	void Update()
	{
		currentRotation.x = Input.GetAxis("Mouse X") * sensitivity;
		currentRotation.y = Input.GetAxis("Mouse Y") * sensitivity;
		currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
		currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);

        

        if(!player.GetComponentsInParent<simplePlayerControl>()[0].isPaused)
        {
            this.transform.RotateAround(player.transform.position, -this.transform.right, currentRotation.y);
            this.transform.RotateAround(player.transform.position, Vector3.up, currentRotation.x);
			Cursor.lockState = CursorLockMode.Locked;
        }


			
	}

}
