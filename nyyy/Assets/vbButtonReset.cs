using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbButtonReset : MonoBehaviour
{
    
    public GameObject vbBtnObjReset;
    public TextMesh tmm;

    // Use this for initialization
    void Start()
    {
        vbBtnObjReset = GameObject.Find("vbBtnObjReset");
        Debug.Log("found reset button");
        vbBtnObjReset.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbBtnObjReset.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        tmm = (TextMesh)GameObject.FindGameObjectWithTag("PickupButterAndSmear").GetComponent<TextMesh>();
        Debug.Log("Test Found");

        tmm.text="Ta smöret och bre mackan / pappret";


        Debug.Log("Button pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

        Debug.Log("Button released");
    }
}