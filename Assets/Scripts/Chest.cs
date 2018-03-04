using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public GameObject chestA;
    public AudioClip coinSound;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            
            chestA.SetActive(true);
            StartCoroutine(WaitGetCoin());
            other.gameObject.GetComponent<Motor>().coins += 1;
        }
    }

    IEnumerator WaitGetCoin()
    {
        source.PlayOneShot(coinSound, 1f);
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}
