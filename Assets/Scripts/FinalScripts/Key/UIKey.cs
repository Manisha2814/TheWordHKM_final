using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class UIKey : MonoBehaviour
{
    RawImage myImage;
    public Color myColor;
    public Color myColorUnselected;
    public bool isCollected=false;

    void Start()
    {
        myImage = GetComponent<RawImage>();
        myColor = Color.yellow;
        myImage.color = myColorUnselected;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollected == true)
        {
            myImage.color = myColor;
        }
    }
}