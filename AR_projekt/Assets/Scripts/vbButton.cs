using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using TMPro;
using System;

public class vbButton : MonoBehaviour {
    private vbButtonReset vbButtonReset;
    public GameObject vbDoneBtnObj;
    public GameObject sidePanel;
    public GameObject butter;
    public GameObject bread;
    public GameObject knife;
    public GameObject tomato;
    public Text textObject;
    int counter;
    public AnimationIdleAndPlay animIdleAndPlayBread;
    public AnimationIdleAndPlay animIdleAndPlayButter;
    public AnimationIdleAndPlay animIdleAndPlayKnife;
    public AnimationIdleAndPlay animIdleAndPlayTomato;

    // Use this for initialization
    void Start () {
        vbButtonReset = GetComponent<vbButtonReset>();
        vbButtonReset.SetTopPanelText(true);
        //vbButtonReset.topPanel.SetActive(false);
        vbDoneBtnObj = GameObject.Find("DoneBtnObject");
        vbDoneBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbDoneBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
        SetPanelInactive();
        counter = 0;
        animIdleAndPlayBread.anim.SetBool("Play", true);
        animIdleAndPlayButter.anim.SetBool("Play", true);
        animIdleAndPlayKnife.anim.SetBool("Play", true);
        animIdleAndPlayTomato.anim.SetBool("Play", true);
    }

    public void SetPanelActive() {
        sidePanel.SetActive(true);
    }

    public void SetPanelInactive() {
        sidePanel.SetActive(false);
    }

    public void SetPanelText(String input) {
        textObject = (Text)GameObject.FindGameObjectWithTag("InstructionText").GetComponent<Text>();
        textObject.text = input;
    }

    public void CasesForInstructions(int imageTargetNumber) {
        switch (imageTargetNumber) {
            case 0:
                StartCoroutine(ExampleCoroutine());

                Debug.Log("Case 0");
                SetPanelActive();
                vbButtonReset.SetTopPanelText(true);
                SetPanelText("Step 1:\n1. Find butter and bread\n2. Spread butter on bread\n3. Push done when completed");

                bread.SetActive(true);
                butter.SetActive(true);
                knife.SetActive(false);
                tomato.SetActive(false);
                animIdleAndPlayBread.anim.SetBool("Play", true);
                animIdleAndPlayButter.anim.SetBool("Play", true);
                //StartCoroutine(ExampleCoroutine());
                break;
            case 1:
                StartCoroutine(ExampleCoroutine());

                vbButtonReset.SetTopPanelText(true);
                SetPanelText("Step 2:\n1. Find knife and tomato\n2. Use the knife to slice tomato into smaller pieces and place them on bread\n3. Push done when completed");
                bread.SetActive(true);
                butter.SetActive(false);
                tomato.SetActive(true);
                knife.SetActive(true);
                //vbButtonReset.topPanel.SetActive(true);
                animIdleAndPlayBread.anim.SetBool("Play", true);
                animIdleAndPlayKnife.anim.SetBool("Play", true);
                animIdleAndPlayTomato.anim.SetBool("Play", true);
                
                //StartCoroutine(ExampleCoroutine());
                break;  
            case 2:
                StartCoroutine(ExampleCoroutine());

                //vbButtonReset.topPanel.SetActive(true);
                SetPanelText("The sandwich is done\nPush done to complete the process");
                vbButtonReset.SetTopPanelText(false);
                bread.SetActive(false);
                butter.SetActive(false);
                tomato.SetActive(false);
                knife.SetActive(false);

                //StartCoroutine(ExampleCoroutine());
                break;
            case 3:
                resetInstructions();
                break;
        }
    }
    
    IEnumerator ExampleCoroutine() {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        vbDoneBtnObj = GameObject.Find("DoneBtnObject");
        vbDoneBtnObj.GetComponent<VirtualButtonBehaviour>().enabled = false;
        //yield on a new YieldInstruction that waits for 3 seconds.
        yield return new WaitForSeconds(4);
        vbDoneBtnObj.GetComponent<VirtualButtonBehaviour>().enabled = true;

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    public void activateArror() {

    }

    public void activateErrorText() {

    }

    public void resetInstructions() {
        counter = 0;
        CasesForInstructions(counter);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        CasesForInstructions(counter++);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        Debug.Log("Button released");
    }
}