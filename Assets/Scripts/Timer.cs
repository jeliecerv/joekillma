using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float timeLeft = 120.0f;
    public Text timer;
    public bool stopTimer = false;
    public Motor motor;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!stopTimer)
        {
            timeLeft -= Time.deltaTime;
            timer.text = Math.Round(timeLeft).ToString();
            if (timeLeft < 0)
            {
                stopTimer = !stopTimer;
                motor.ScoreCalculation();
            }
        }
    }

    public void StopTimer()
    {
        stopTimer = !stopTimer;
    }
}
