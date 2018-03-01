using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public GameObject chestA;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        chestA.SetActive(true);
        gameObject.SetActive(false);
        other.gameObject.GetComponent<Soldier>().coins += 1;
        Debug.Log(other.gameObject.GetComponent<Soldier>().coins);
    }
}
