using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldier : MonoBehaviour {
    private NavMeshAgent agent;
    public Transform target;
    public int coins = 0;
    public int life = 50;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
