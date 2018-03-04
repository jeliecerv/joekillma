using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final : MonoBehaviour {

    public Sprite win;
    public Sprite lost;
    private Image img;

    // Use this for initialization
    void Start () {
        img = GetComponent<Image>();
    }

    public void WinImage()
    {
        img.sprite = win;
    }

    public void LostImage()
    {
        img.sprite = lost;
    }
}
