using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Patrulla patrulla = other.gameObject.GetComponent<Patrulla>();
        if(patrulla != null)
            patrulla.changeTarget();
    }

}
