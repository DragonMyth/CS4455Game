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

    private Animator anim;

	public float speed  = 0.1f;
    public bool canSpeed; // if player can speed up
    public bool isPaused;
    public GameObject inGameMenu;

    private Vector2 currentRotation;
    public float sensitivity = 0.001f;

    public float maxYAngle = 80f;

	private float turnAngle = 10f;
	private float turn = 0f;

    // Use this for initialization

    GameObject playerObj;
    GameObject playerModel;

	void Start () {
		playerObj = transform.GetChild (0).gameObject;
        playerModel = transform.GetChild(1).gameObject;
        anim = playerModel.GetComponent<Animator>();
        if (anim == null)
            Debug.Log("Animator could not be found");
    }
	
	// Update is called once per frame
	void Update () {
        canSpeed = !GetComponent<PlayerStamina>().getTired(); // see if player can speed up, which costs stamina

        Camera cam = GetComponentInChildren<Camera>();

		float lh = Input.GetAxisRaw("Horizontal");
		float lv = Input.GetAxisRaw("Vertical");

//		Vector2 vec = Vector2.ClampMagnitude(new Vector2(lh, lv), 1.0f);
//
//		lh = vec.x;
//		lv = vec.y;

//		turn = Mathf.Lerp (turn, lh, Time.deltaTime * 5f);
//		turnAngle += Time.deltaTime * 10f;

        anim.SetFloat("Rate", Mathf.Abs(lh) + Mathf.Abs(lv));
		anim.SetFloat ("Turn", turn);
		Debug.Log (turn);


        if (lh == 0 && lv == 0)
        {
            anim.SetBool("Stop", true);
        }
        else
        {
            anim.SetBool("Stop", false);
		}
		int up = Input.GetButton ("Jump") == true ? 1 : 0 ;
		int down = Input.GetButton ("Descend") == true ? 1 : 0 ;

        if (Input.GetButton("Fire1") && canSpeed) // press fire1 to speed up
        {
            speed = 0.4f;
            GetComponent<PlayerStamina>().SpeedUp();
			GetComponent <PlayerOxygen>().OxygenCost = 1;
        } else
        {
            GetComponent<PlayerStamina>().StaminaRegen();
			GetComponent <PlayerOxygen>().OxygenCost = 0.3f;

            speed = 0.1f;
        }

        //this.transform.Translate(cam.transform.forward * lv * speed * Time.deltaTime);
        this.transform.position += (cam.transform.forward * lv
              + cam.transform.right * lh
              + up*Vector3.up
              +down*Vector3.down) *speed* Time.timeScale;
        
		this.transform.RotateAround (transform.position,Vector3.up,  4 * lh);

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
        currentRotation.x = Input.GetAxis("Mouse X") * sensitivity;
        currentRotation.y = Input.GetAxis("Mouse Y") * sensitivity;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
        //		this.transform.Translate (cam.transform.forward*lv*speed*Time.deltaTime);
        playerModel.transform.Rotate(currentRotation.x, currentRotation.y, Vector3.up.z);
        Cursor.lockState = CursorLockMode.Locked;

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

