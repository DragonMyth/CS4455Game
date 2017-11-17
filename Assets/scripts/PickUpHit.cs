using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
            collision.gameObject.GetComponent<PlayerOxygen>().OxygenRecharge(10f);
        }
    }

}