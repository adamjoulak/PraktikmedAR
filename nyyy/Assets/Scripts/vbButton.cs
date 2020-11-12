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
        tomato = GameObject.FindGameObjectWithTag("Tomato");
        knife = GameObject.FindGameObjectWithTag("Knife");
        /*
        knife.SetActive(false);
        tomato.SetActive(false);
        */
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
                //vbButtonReset.topPanel.SetActive(true);
                animIdleAndPlayBread.anim.SetBool("Play", true);
                animIdleAndPlayButter.anim.SetBool("Play", true);
                SetPanelActive();
                SetPanelText("Step 1:\n1. Find butter and bread\n2. Spread butter on bread\n3. Push done when completed");
                vbButtonReset.SetTopPanelText(true);
                StartCoroutine(ExampleCoroutine());
                knife.SetActive(false);
                tomato.SetActive(false);
                break;
            case 1:
                vbButtonReset.SetTopPanelText(true);
                //vbButtonReset.topPanel.SetActive(true);
                animIdleAndPlayBread.anim.SetBool("Play", true);
                animIdleAndPlayKnife.anim.SetBool("Play", true);
                animIdleAndPlayTomato.anim.SetBool("Play", true);
                SetPanelText("Step 2:\n1. Find knife and tomato\n2. Use the knife to slice tomato into smaller pieces and place them on bread\n3. Push done when completed");
                bread.SetActive(true);
                butter.SetActive(false);
                tomato.SetActive(true);
                knife.SetActive(true);
                StartCoroutine(ExampleCoroutine());
                break;  
            case 2:
                //vbButtonReset.topPanel.SetActive(true);
                SetPanelText("The sandwich is done\nPush done to complete the process");
                vbButtonReset.SetTopPanelText(false);
                bread.SetActive(false);
                butter.SetActive(false);
                tomato.SetActive(false);
                knife.SetActive(false);
                StartCoroutine(ExampleCoroutine());
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
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        vbDoneBtnObj.GetComponent<VirtualButtonBehaviour>().enabled = true;

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }


    public void resetInstructions() {
        vbButtonReset.SetPanelActive();
        vbButtonReset.SetTopPanelText(false);
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