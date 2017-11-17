/**
 * Imported from Unity Standard Assets
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
//using UnityEditor;

public class simplePlayerControl : MonoBehaviour {


	public float speed  = 0.1f;
    public bool canSpeed; // if player can speed up
    public bool isPaused;
    public GameObject inGameMenu;
	// Use this for initialization

	GameObject playerObj;

	void Start () {
		playerObj = transform.GetChild (0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        canSpeed = !GetComponent<PlayerStamina>().getTired(); // see if player can speed up, which costs stamina

        Camera cam = GetComponentInChildren<Camera>();

		float lh = Input.GetAxisRaw("Horizontal");
		float lv = Input.GetAxisRaw("Vertical");

        if (Input.GetButton("Fire1") && canSpeed) // press fire1 to speed up
        {
            speed = 0.4f;
            GetComponent<PlayerStamina>().SpeedUp();
        } else
        {
            GetComponent<PlayerStamina>().StaminaRegen();
            speed = 0.1f;
        }
        print(speed);
        this.transform.position += (cam.transform.forward * lv * speed + cam.transform.right * lh * speed) * Time.timeScale;

        //this.transform.Translate(cam.transform.forward * lv * speed * Time.deltaTime);

        

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            inGameMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            inGameMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
        }

	}
    public void Pause()
    {
        inGameMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        inGameMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

}
