using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOxygen : MonoBehaviour {

    public float startingOxygen = 100f;                            // The amount of Stamina the player starts the game with.
    public float currentOxygen;                                   // The current Stamina the player has.
    public Slider OxygenSlider;                                 // Reference to the UI's Stamina bar.
    public float OxygenCost = 0.25f;
    public GameObject UIObj;
    //public AudioClip speedClip;

    Animator anim;                                              // Reference to the Animator component.
    //AudioSource playerAudio;                                    // Reference to the AudioSource component.

    GameOverManage gameoverManage;
    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        //playerAudio = GetComponent<AudioSource>();
        // Set the initial health of the player.
        currentOxygen = startingOxygen;

        gameoverManage = UIObj.GetComponent<GameOverManage>();
    }

    void Update()
    {
        if (currentOxygen >= 0)
        {
            currentOxygen -= OxygenCost;
        }
        else
        {
            gameoverManage.Die();

        }
        OxygenSlider.value = currentOxygen;
        // If the player has just been damaged...
        // Reset the damaged flag.
    }

    public void OxygenRecharge(float amount)
    {
        if (currentOxygen < 100)
        {
            currentOxygen += amount;
        }
        OxygenSlider.value = currentOxygen;
    }

    public float GetOxygen()
    {
        return currentOxygen;
    }

}
