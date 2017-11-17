using UnityEngine;
using System.Collections;

public class playSound : MonoBehaviour
{

    public AudioSource mySound;
    //public AudioClip myClip;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            mySound.enabled = true;
            mySound.loop = true;
        }
        else
        {
            mySound.enabled = false;
            mySound.loop = false;
        }
    }
}