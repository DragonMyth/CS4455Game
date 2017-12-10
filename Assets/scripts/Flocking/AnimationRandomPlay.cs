using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRandomPlay : MonoBehaviour {

	// Use this for initialization
	Animator anim;
	void Start () {
		anim = GetComponent <Animator> ();

		anim.Play (anim.GetCurrentAnimatorStateInfo (0).shortNameHash,0,Random.Range (0.0f,1.0f));
	}

}
