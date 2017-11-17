using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEventManager : MonoBehaviour
{

    public AudioClip oxygenAudio;

	private UnityAction<Vector3, string> oxygenCollisionEventListener;

    void Awake()
    {

		oxygenCollisionEventListener = new UnityAction<Vector3, string> (oxygenCollisionEventHandler);

    }


    // Use this for initialization
    void Start()
    {


        			
    }


    void OnEnable()
    {

		EventManager.StartListening<OxygenCollisionEvent, Vector3, string> (oxygenCollisionEventListener);


    }

    void OnDisable()
	{

		EventManager.StopListening<OxygenCollisionEvent, Vector3, string> (oxygenCollisionEventListener);

	}



    // Update is called once per frame
    void Update()
    {
    }



	void oxygenCollisionEventHandler(Vector3 worldPos, string surface)
	{
		if (surface == "Player") {
			Debug.Log ("Event!!!!!");
			AudioSource.PlayClipAtPoint (this.oxygenAudio, worldPos);
		}

	}

}
