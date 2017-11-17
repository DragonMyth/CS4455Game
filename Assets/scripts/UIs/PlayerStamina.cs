﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStamina : MonoBehaviour
{
    public float startingStamina = 100f;                            // The amount of Stamina the player starts the game with.
    public float currentStamina;                                   // The current Stamina the player has.
    public Slider staminaSlider;                                 // Reference to the UI's Stamina bar.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    public float speedCost = 1f;
    public float speedRecover = 0.5f;
    //public AudioClip speedClip;

    Animator anim;                                              // Reference to the Animator component.
    //AudioSource playerAudio;                                    // Reference to the AudioSource component.
    bool isSpeeding;                                            // For UI update
    public bool isTired;                                        // To see if character can speed up

	simplePlayerControl control;
    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        //playerAudio = GetComponent<AudioSource>();
        // Set the initial health of the player.
        currentStamina = startingStamina;
		control = GetComponent <simplePlayerControl> ();
    }


    void Update()
    {
			staminaSlider.value = currentStamina;
			// If the player has just been damaged...
			if (isSpeeding) {
				// ... set the colour of the damageImage to the flash colour.
            
			}
        // Otherwise...
        else {
				// ... transition the colour back to clear.
            
            
			}
			// Reset the damaged flag.
			isSpeeding = false;
			if (isTired == true) {
				if (currentStamina > 50) {
					isTired = false;
				}
			}

    }

    // Need to call SpeedUp in character control
    public void SpeedUp()
    {
        // Set the damaged flag so the screen will flash.
        isSpeeding = true;

        // Reduce the current health by the damage amount.
        currentStamina -= speedCost;

        // Set the health bar's value to the current health.
        staminaSlider.value = currentStamina;

        // Play the hurt sound effect.
        //playerAudio.Play();
        //AudioSource.PlayClipAtPoint(speedClip, this.transform.position);

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentStamina <= 0)
        {
            isTired = true;
        }
    }
    public bool getTired()
    {
        return isTired;
    }
    public void StaminaRegen()
    {
		if (!control.isPaused) {
			if (currentStamina < 100) {
				currentStamina += speedRecover;
				staminaSlider.value = currentStamina;
			}
		}
    }
    public void StaminaRecharge(float amount) // for stamina recharge packs
    {
        if (currentStamina < 100)
        {
            currentStamina += amount;
        }
        staminaSlider.value = currentStamina;

    }
}