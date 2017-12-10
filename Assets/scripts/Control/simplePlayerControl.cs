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
	public GameObject cam;

    private Vector2 currentRotation;
    public float sensitivity = 0.001f;

    public float maxYAngle = 80f;

	private float turnAngle = 10f;
	private float turn = 0f;

	float originalOxyCost;
    float originalSpeed;


    // Use this for initialization

    GameObject playerObj;
    GameObject playerModel;
	public static GameObject player;

	void Start () {
		playerObj = transform.GetChild (0).gameObject;
        playerModel = transform.GetChild(1).gameObject;
        anim = playerModel.GetComponent<Animator>();
		originalOxyCost = GetComponent<PlayerOxygen> ().OxygenCost;
        originalSpeed = speed;
		player  = GameObject.FindWithTag ("Player");
        if (anim == null)
            Debug.Log("Animator could not be found");
    }
	
	// Update is called once per frame
	void Update () {
        canSpeed = !GetComponent<PlayerStamina>().getTired(); // see if player can speed up, which costs stamina


		float lh = Input.GetAxisRaw("Horizontal");
		float lv = Input.GetAxisRaw("Vertical");


        if( (Mathf.Abs(lh) + Mathf.Abs(lv)) > 0 && turn < 2.0f)
        {
            turn += 0.03f * (Mathf.Abs(lh) + Mathf.Abs(lv)) * Time.timeScale;
        }
        else if (turn > 0)
        {
            turn -= 0.12f * Time.timeScale;
        }
        anim.SetFloat("Rate", turn);
		//anim.SetFloat ("Turn", turn);
//		Debug.Log (turn);


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
            speed = originalSpeed*3;
            GetComponent<PlayerStamina>().SpeedUp();
			GetComponent <PlayerOxygen>().OxygenCost = originalOxyCost*2;
        } else
        {
            GetComponent<PlayerStamina>().StaminaRegen();
			GetComponent <PlayerOxygen>().OxygenCost = originalOxyCost;
            speed = originalSpeed;
        }

        //this.transform.Translate(cam.transform.forward * lv * speed * Time.deltaTime);
        this.transform.position += (cam.transform.forward * lv
//              + cam.transform.right * lh
              + up*Vector3.up*2
              +down*Vector3.down*2) *speed* Time.timeScale;
        
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

