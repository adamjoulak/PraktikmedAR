using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbButton : MonoBehaviour {

    public GameObject vbBtnObj;
    public TextMesh tm;

 // Use this for initialization
 void Start () {
        vbBtnObj = GameObject.Find("FinishedWithTaskButton");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
        
 }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        tm = (TextMesh)GameObject.FindGameObjectWithTag("PickupButterAndSmear").GetComponent<TextMesh>();
        Debug.Log("Found");
        tm.text = "Ta pålägg och lägg på mackan/pappret";
        
        

        Debug.Log("Button pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
        Debug.Log("Button released");
    }
}