using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventCallBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ThreadWater()
    {
        EventManager.TriggerEvent<PlayerThreadWaterEvent, Vector3> (this.transform.position);
        // if (Time.timeSinceLevelLoad - lastThreadWater > minSwimSeparation) {
        //     lastThreadWater = Time.timeSinceLevelLoad;
        //     Debug.Log ("threading water");
        //     EventManager.TriggerEvent<PlayerThreadWaterEvent, Vector3> (this.transform.position);
        // }
    }
}
