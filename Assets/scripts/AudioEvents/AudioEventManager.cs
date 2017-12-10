using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEventManager : MonoBehaviour
{

    public AudioClip oxygenAudio;
	public AudioClip fishAudio;
	public AudioClip swimAudio;

	private UnityAction<Vector3, string> oxygenCollisionEventListener;
	private UnityAction<Vector3, string> fishCollisionEventListener;
	private UnityAction<Vector3> playerThreadWaterEventListener;


    void Awake()
    {

		oxygenCollisionEventListener = new UnityAction<Vector3, string> (oxygenCollisionEventHandler);
		fishCollisionEventListener = new UnityAction<Vector3, string> (fishCollisionEventHandler);
		playerThreadWaterEventListener = new UnityAction<Vector3> (playerThreadWaterEventHandler);

    }


    // Use this for initialization
    void Start()
    {


        			
    }


    void OnEnable()
    {

		EventManager.StartListening<OxygenCollisionEvent, Vector3, string> (oxygenCollisionEventListener);
		EventManager.StartListening<FishCollisionEvent, Vector3, string> (fishCollisionEventListener);
		EventManager.StartListening<PlayerThreadWaterEvent, Vector3> (playerThreadWaterEventListener);

    }

    void OnDisable()
	{

		EventManager.StopListening<OxygenCollisionEvent, Vector3, string> (oxygenCollisionEventListener);
		EventManager.StopListening<FishCollisionEvent, Vector3, string> (fishCollisionEventListener);
		EventManager.StopListening<PlayerThreadWaterEvent, Vector3> (playerThreadWaterEventListener);

	}



    // Update is called once per frame
    void Update()
    {
    }



	void oxygenCollisionEventHandler(Vector3 worldPos, string surface)
	{
		if (surface == "Player") {
			AudioSource.PlayClipAtPoint (this.oxygenAudio, worldPos);
		}

	}

	void fishCollisionEventHandler(Vector3 worldPos, string surface)
	{
		if (surface == "Player") {
			AudioSource.PlayClipAtPoint (this.fishAudio, worldPos);
		}
	}

	void playerThreadWaterEventHandler(Vector3 worldPos)
	{
		AudioSource.PlayClipAtPoint (this.swimAudio, worldPos);
	}

}
