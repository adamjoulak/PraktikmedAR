using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using TMPro;
using System;

public class vbButton : MonoBehaviour {

    public vbButtonReset vbButtonReset;
    public GameObject vbBtnObj;
    public GameObject sidePanel;
    public GameObject butter;
    public GameObject bread;
    public GameObject cheese;
    public GameObject tomato;
    public Text textObject;


    int counter;

    // Use this for initialization
    void Start () {
        tomato = GameObject.FindGameObjectWithTag("Tomato");
        cheese = GameObject.FindGameObjectWithTag("Cheese");
        cheese.SetActive(false);
        tomato.SetActive(false);
        vbButtonReset = GetComponent<vbButtonReset>();
        vbBtnObj = GameObject.Find("FinishedWithTaskButton");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
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

    public void SetPanelText(String input)
    {
        textObject = (Text)GameObject.FindGameObjectWithTag("InstructionText").GetComponent<Text>();
        textObject.text = input;
    }

    public void CasesForInstructions(int imageTargetNumber) {
        switch (imageTargetNumber) {
            case 0:
                SetPanelActive();
                SetPanelText("1. Find butter and bread\n2. Spread butter on bread\n3. ");
                vbButtonReset.SetPanelText(false);
                break;
            case 1:
                tomato.SetActive(true);
                cheese.SetActive(true);
                SetPanelText("2. Lokalisera pålägg");
                break;
            case 2:
                SetPanelText("3. Lägg pålägg på mackan");
                break;
            case 3:
                SetPanelText("4. Häll dricka i koppen");
                break;
            case 4:
                SetPanelText("5. Du är nu färdig, Smaklig måltid");
                break;
            case 5:
                resetInstructions();
                break;

        }
    }

    public void resetInstructions() {
        vbButtonReset.SetPanelActive();
        vbButtonReset.SetPanelText(true);
        tomato.SetActive(false);
        cheese.SetActive(false);
        counter = 0;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        CasesForInstructions(counter++);
        //counter++;
        Debug.Log("Button pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
        Debug.Log("Button released");
    }
}