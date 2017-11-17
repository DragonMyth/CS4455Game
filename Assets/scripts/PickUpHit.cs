using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PickUpHit : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("AAAAAAAAAAAAAAAAAAAAa");
            collision.gameObject.GetComponent<PlayerOxygen>().OxygenRecharge(10f);
        }
    }

}