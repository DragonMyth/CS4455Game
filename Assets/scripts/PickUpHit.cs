using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class PickUpHit : MonoBehaviour
{
    private Rigidbody rb;
    private bool hited = false;
	public float oxygenRegenVal;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && hited == false)
        {
            hited = true;

//			Color cur

			Material mat = gameObject.GetComponent<Renderer>().material;
			 
			Color currCol = mat.color;
			currCol.r *= 0.2f;
			currCol.g *= 0.2f;
			currCol.b *= 0.2f;

			mat.SetColor("_Color",currCol);
            
			PlayerOxygen oxygen = collision.gameObject.GetComponent<PlayerOxygen> ();

			oxygen.OxygenRecharge(oxygenRegenVal);

			ScoreManager.score += 1;

//			Debug.Log (ScoreManager.score);


        }
    }

}