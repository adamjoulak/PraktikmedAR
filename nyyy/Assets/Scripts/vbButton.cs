using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using TMPro;
using System;

public class vbButton : MonoBehaviour {
    public vbButtonReset vbButtonReset;
    public GameObject vbDoneBtnObj;
    public GameObject sidePanel;
    public GameObject butter;
    public GameObject bread;
    public GameObject knife;
    public GameObject tomato;
    public Text textObject;

    int counter;

    // Use this for initialization
    void Start () {
        tomato = GameObject.FindGameObjectWithTag("Tomato");
        knife = GameObject.FindGameObjectWithTag("Knife");
        knife.SetActive(false);
        tomato.SetActive(false);
        vbButtonReset = GetComponent<vbButtonReset>();

        vbDoneBtnObj = GameObject.Find("DoneBtnObject");
        vbDoneBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbDoneBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
        SetPanelInactive();
        counter = 0;
    }

    public void SetPanelActive() {
        sidePanel.SetActive(true);
    }

    public void SetPanelInactive() {
        sidePanel.SetActive(false);
        /*
        SetPanelActive();
        SetPanelText("Panel is inactive");
        Debug.Log("FUCK");
        */
    }

    public void SetPanelText(String input) {
        textObject = (Text)GameObject.FindGameObjectWithTag("InstructionText").GetComponent<Text>();
        textObject.text = input;
    }

    public void CasesForInstructions(int imageTargetNumber) {
        switch (imageTargetNumber) {
            case 0:
                Debug.Log("CASE 00");
                SetPanelActive();
                SetPanelText("Step 1:\n1. Find butter and bread\n2. Spread butter on bread\n3. Push done when completed");
                vbButtonReset.SetPanelText(false);
                break;
            case 1:
                Debug.Log("CASE 01");
                SetPanelText("Step 2:\n1. Find knife and tomato\n2. Use the knife to slice tomato into smaller pieces and place them on bread\n3. Push done when completed");
                //bread.SetActive(false);
                //butter.SetActive(false);
                tomato.SetActive(true);
                knife.SetActive(true);
                break;
            case 2:
                Debug.Log("CASE 02");
                SetPanelText("The sandwich is done\nPush done to complete the process");
                /*
                bread.SetActive(false);
                butter.SetActive(false);
                tomato.SetActive(false);
                knife.SetActive(false);
                */
                break;
            case 3:
                Debug.Log("CASE 03");
                resetInstructions();
                break;
        }
    }

    public void resetInstructions() {
        vbButtonReset.SetPanelActive();
        vbButtonReset.SetPanelText(true);
        tomato.SetActive(false);
        knife.SetActive(false);
        counter = 0;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        CasesForInstructions(counter++);
        //counter++;
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        Debug.Log("Button released");
    }
}