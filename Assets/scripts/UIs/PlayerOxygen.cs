using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NUnit.Compatibility;

public class PlayerOxygen : MonoBehaviour {

    public float startingOxygen = 100f;                            // The amount of Stamina the player starts the game with.
    public float currentOxygen;                                   // The current Stamina the player has.
    public Slider OxygenSlider;                                 // Reference to the UI's Stamina bar.
    public float OxygenCost = 0.25f;
    public GameObject UIObj;

	simplePlayerControl control;
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
		control = GetComponent<simplePlayerControl> ();
    }

    void Update()
    {
		if (!control.isPaused)
        {
            currentOxygen -= OxygenCost;
        }
		if (currentOxygen<=0)
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
			currentOxygen = Mathf.Min (100, currentOxygen);
        }
        OxygenSlider.value = currentOxygen;
    }

    public float GetOxygen()
    {
        return currentOxygen;
    }

}
