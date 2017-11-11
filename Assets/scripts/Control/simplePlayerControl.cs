//Team MacroHard:
//	  Binchen Hu, bhu77@gatech.edu, bhu77
//    Jiazheng Sun, jsun303 @gatech.edu, jsun303
//    Jingyi Li, jinli647 @gatech.edu, jinli647
//    Yunbo Zhang, yzhang3027 @gatech.edu, yzhang3027
//    Ziming He, zhe66 @gatech.edu, zhe66

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
