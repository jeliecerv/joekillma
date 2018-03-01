using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    private float timeLeft = 120.0f;
    public Text timer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timer.text = Math.Round(timeLeft).ToString();
        Debug.Log(timeLeft);
        if (timeLeft < 0)
        {
            Debug.Log("game Over");
        }
    }
}
