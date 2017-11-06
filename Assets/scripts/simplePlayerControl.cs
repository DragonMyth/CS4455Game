using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class simplePlayerControl : MonoBehaviour {


	public float speed  = 10f;

    public bool isPaused;
    public GameObject inGameMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Camera cam = GetComponentInChildren<Camera>();

		float lh = Input.GetAxisRaw("Horizontal");
		float lv = Input.GetAxisRaw("Vertical");

        this.transform.Translate(cam.transform.forward * lv * speed * Time.deltaTime);

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
