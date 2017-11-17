using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class PickUpHit : MonoBehaviour
{
    private Rigidbody rb;
    private bool hited = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && hited == false)
        {
            hited = true;

            gameObject.GetComponent<Renderer>().material.SetColor("Color",Color.blue);
            
			PlayerOxygen oxygen = collision.gameObject.GetComponent<PlayerOxygen> ();

			oxygen.OxygenRecharge(10f);

			ScoreManager.score += 1;

			Debug.Log (ScoreManager.score);


        }
    }

}