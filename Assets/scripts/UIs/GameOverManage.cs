using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManage : MonoBehaviour {

    private float playerOxygen;
    public float restartDelay = 5f;         // Time to wait before restarting the level


    Animator anim;                          // Reference to the animator component.
    float restartTimer;                     // Timer to count up to restarting the level


    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }

    public void Die() {

        StartCoroutine(delayedDeath());
    }

    IEnumerator delayedDeath() {
        anim.SetTrigger("Dead");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
