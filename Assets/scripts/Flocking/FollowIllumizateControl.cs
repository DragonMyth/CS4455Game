using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowIllumizateControl: MonoBehaviour {

	// Use this for initialization
	ParticleSystem particle;
	void Start () {
		particle = GetComponentInChildren <ParticleSystem>();
		particle.enableEmission = false ;
	}
	

	public void emmisionOn(){
		
		particle.enableEmission = true;
	}
}
