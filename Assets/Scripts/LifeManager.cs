using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

    public Sprite lifeEmpty;
    private Image img;

	// Use this for initialization
	void Start () {
        img = GetComponent<Image>();
    }
	
	public void UpdateLife()
    {
        img.sprite = lifeEmpty;
    }
}
