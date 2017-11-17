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


	public float speed  = 10f;

    public bool isPaused;
    public GameObject inGameMenu;
	// Use this for initialization

	GameObject playerObj;

	void Start () {
		playerObj = transform.GetChild (0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {


		Camera cam = GetComponentInChildren<Camera>();

		float lh = Input.GetAxisRaw("Horizontal");
		float lv = Input.GetAxisRaw("Vertical");

		int up = Input.GetButton ("Jump") == true ? 1 : 0 ;
		int down = Input.GetButton ("Descend") == true ? 1 : 0 ;

		this.transform.position += (cam.transform.forward * lv 
			+ cam.transform.right * lh  
			+ up*Vector3.up
			+down*Vector3.down) *speed* Time.timeScale;

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
//		this.transform.Translate (cam.transform.forward*lv*speed*Time.deltaTime);

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
