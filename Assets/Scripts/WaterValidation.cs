using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterValidation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Equals("Player"))
        {
            other.GetComponent<Motor>().ResetPosition();
        }
    }
}
