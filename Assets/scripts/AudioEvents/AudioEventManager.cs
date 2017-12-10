using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEventManager : MonoBehaviour
{

    public AudioClip oxygenAudio;
	public AudioClip fishAudio;
	public AudioClip swimAudio;
    public AudioClip eelAudio;
    public AudioClip simpleFishAudio;
    public AudioClip loseScoreAudio;

	private UnityAction<Vector3, string> oxygenCollisionEventListener;
	private UnityAction<Vector3, string> fishCollisionEventListener;
	private UnityAction<Vector3> playerThreadWaterEventListener;
    private UnityAction<Vector3, string> simpleFishCollisionEventListener;
    private UnityAction<Vector3, string> eelCollisionEventListener;
    private UnityAction<Vector3, string> loseScoreEventListener;


    void Awake()
    {

		oxygenCollisionEventListener = new UnityAction<Vector3, string> (oxygenCollisionEventHandler);
		fishCollisionEventListener = new UnityAction<Vector3, string> (fishCollisionEventHandler);
		playerThreadWaterEventListener = new UnityAction<Vector3> (playerThreadWaterEventHandler);
        simpleFishCollisionEventListener = new UnityAction<Vector3, string> (simpleFishCollisionEventHandler);
        eelCollisionEventListener = new UnityAction<Vector3, string>(eelCollisionEventHandler);
        loseScoreEventListener = new UnityAction<Vector3, string>(loseScoreEventHandler);

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
        EventManager.StartListening<SimpleFishCollisionEvent, Vector3, string>(simpleFishCollisionEventListener);
        EventManager.StartListening<EelCollisionEvent, Vector3, string>(eelCollisionEventListener);
        EventManager.StartListening<LoseScoreEvent, Vector3, string>(loseScoreEventListener);

    }

    void OnDisable()
	{

		EventManager.StopListening<OxygenCollisionEvent, Vector3, string> (oxygenCollisionEventListener);
		EventManager.StopListening<FishCollisionEvent, Vector3, string> (fishCollisionEventListener);
		EventManager.StopListening<PlayerThreadWaterEvent, Vector3> (playerThreadWaterEventListener);
        EventManager.StopListening<SimpleFishCollisionEvent, Vector3, string>(simpleFishCollisionEventListener);
        EventManager.StopListening<EelCollisionEvent, Vector3, string>(eelCollisionEventListener);
        EventManager.StopListening<LoseScoreEvent, Vector3, string>(loseScoreEventListener);

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

    void simpleFishCollisionEventHandler(Vector3 worldPos, string surface)
    {
        AudioSource.PlayClipAtPoint(this.simpleFishAudio, worldPos);
    }

    void eelCollisionEventHandler(Vector3 worldPos, string surface)
    {
        AudioSource.PlayClipAtPoint(this.eelAudio, worldPos);
    }

    void loseScoreEventHandler(Vector3 worldPos, string surface)
    {
        AudioSource.PlayClipAtPoint(this.loseScoreAudio, worldPos);
    }
}
