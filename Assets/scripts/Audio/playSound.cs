using UnityEngine;
using System.Collections;

public class playSound : MonoBehaviour
{

    public AudioSource mySound;
	private float currSatmina;
    //public AudioClip myClip;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown ("Fire1")) {
			currSatmina = GetComponent<PlayerStamina> ().currentStamina;
		}

		if (Input.GetButton ("Fire1") && currSatmina >= 50)
        {
            mySound.enabled = true;
            mySound.loop = true;
        }
        else
        {
            mySound.enabled = false;
            mySound.loop = false;
        }
    }
}