using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbButton : MonoBehaviour {

    public vbButtonReset vbButtonReset;

    public GameObject vbBtnObj;
    private TextMesh tm;
    public GameObject sidePanel;

    public GameObject butter;
    public GameObject bread;
    public GameObject cheese;
    public GameObject tomato;


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
        counter = 0;
        SetPanelInactive();
    }

    public void SetPanelActive()
    {
        sidePanel.SetActive(true);
    }

    public void SetPanelInactive()
    {
        sidePanel.SetActive(false);
    }

    public void SetPanelText(String text)
    {
        tm = (TextMesh)GameObject.FindGameObjectWithTag("InstructionText").GetComponent<TextMesh>();
        Debug.Log("Found");
        tm.text = text;
    }

    public void CasesForInstructions(int imageTargetNumber)

    {
        switch (imageTargetNumber)
        {
            case 0:
                SetPanelActive();
                SetPanelText("1. Bre smöret på mackan med hjälp av kniven");
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
            
        }

        if(imageTargetNumber == 6)
        {
            vbButtonReset.SetPanelActive();
            vbButtonReset.SetPanelText(true);
            tomato.SetActive(false);
            cheese.SetActive(false);
            counter = 0;
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        CasesForInstructions(counter);
        counter++;
        Debug.Log("Button pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
        Debug.Log("Button released");
    }
}