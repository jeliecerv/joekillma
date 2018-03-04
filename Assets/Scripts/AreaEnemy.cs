using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnemy : MonoBehaviour {
    
    public GameObject patrullero;

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
            patrullero.GetComponent<Patrulla>().followToJoe();
            //patrullero.GetComponent<Patrulla>().changeToMainTarget();
            //patrullero.GetComponent<Patrulla>().Attack();
        }
            
    }


    private void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.tag.Equals("Player"))
        {
            patrullero.GetComponent<Patrulla>().changeToPatrol();
            patrullero.GetComponent<Patrulla>().Walk();
        }
            
    }
}
