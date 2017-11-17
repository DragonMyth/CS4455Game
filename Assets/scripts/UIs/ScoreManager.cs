using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreUpdate : MonoBehaviour {
    public static int score;
    Text scoreText;
	// Use this for initialization
	void Start ()
    {
        scoreText = GetComponent<Text>();
        score = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = "Score: " + score;
	}

    int getScore()
    {
        return score;
    }

}
