using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Vuforia;

public class vbButtonReset : MonoBehaviour {
    
    public GameObject vbBtnObjReset;
    public TextMeshPro tmm;
    public GameObject topPanel;
    private bool isReset;

    // Use this for initialization
    void Start()
    {
        topPanel = GameObject.FindGameObjectWithTag("PanelFindTargetTMP");
        vbBtnObjReset = GameObject.FindGameObjectWithTag("vbBtnObjReset");
        Debug.Log("found reset button");
        vbBtnObjReset.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbBtnObjReset.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
    }

    public void SetPanelActive() {
        topPanel.SetActive(true);
    }
    /*
    public void SetPanelInactive()
    {
        topPanel.SetActive(false);
    }
    */

    public void SetPanelText(bool isReset)
    {
        tmm = (TextMeshPro)GameObject.FindGameObjectWithTag("FindTargetTMP").GetComponent<TextMeshPro>();
        if (isReset) {
            tmm.text = "Hitta Alla Bestick & Ingredienser";
        }
        else {
            tmm.text = "Tryck 'Done' Efter Avklarat del moment";

        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        SetPanelActive();
        SetPanelText(true);
        Debug.Log("Button RESET pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

        Debug.Log("Button released");
    }
}