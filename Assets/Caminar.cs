using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminar : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<PlayerController>().SetArsenal("Sniper Rifle");
	}
	
	// Update is called once per frame
	void Update () {
        //GetComponent<Actions>().Walk();

        GetComponent<Actions>().Death();
	}
}
