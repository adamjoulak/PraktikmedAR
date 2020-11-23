using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using TMPro;
using System;

public class vbSmoothieButton : MonoBehaviour {
    private vbSmoothieResetButton vbButtonReset;
    public GameObject vbDoneBtnObj;
    public GameObject sidePanel;
    public GameObject VanillaYoghurt;
    public GameObject Strawberry;
    public GameObject Glas;
    public GameObject Mixer;
    public GameObject Banana;
    public Text textObject;
    int counter;
    public AnimationIdleAndPlay animIdleAndPlayVanillaYoghurt;
    public AnimationIdleAndPlay animIdleAndPlayStrawberry;
    public AnimationIdleAndPlay animIdleAndPlayGlas;
    public AnimationIdleAndPlay animIdleAndPlayMixer;
    public AnimationIdleAndPlay animIdleAndPlayBanana;

    // Use this for initialization
    void Start() {
        vbButtonReset = GetComponent<vbSmoothieResetButton>();
        vbButtonReset.SetTopPanelText(true);

        //vbButtonReset.topPanel.SetActive(false);
        vbDoneBtnObj = GameObject.Find("DoneBtnObject");
        vbDoneBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbDoneBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
        SetPanelInactive();
        counter = 0;

        animIdleAndPlayVanillaYoghurt.anim.SetBool("Play", true);
        animIdleAndPlayStrawberry.anim.SetBool("Play", true);
        animIdleAndPlayGlas.anim.SetBool("Play", true);
        animIdleAndPlayMixer.anim.SetBool("Play", true);
        animIdleAndPlayBanana.anim.SetBool("Play", true);
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
                vbButtonReset.SetTopPanelText(true);
                SetPanelActive();
                SetPanelText("Step 1:\n1. Find Strawberry, Banana And Vanilla Yoghurt\n2. Add them to the Mixer\n3. Push done when completed");
                Strawberry.SetActive(true);
                VanillaYoghurt.SetActive(true);
                Banana.SetActive(true);
                Mixer.SetActive(true);
                Glas.SetActive(false);
                animIdleAndPlayVanillaYoghurt.anim.SetBool("Play", true);
                animIdleAndPlayStrawberry.anim.SetBool("Play", true);
                animIdleAndPlayBanana.anim.SetBool("Play", true);
                //StartCoroutine(ExampleCoroutine());
                break;
            case 1:
                StartCoroutine(ExampleCoroutine());

                SetPanelText("Step 2:\n1. Mix the fruits in the mixer\n2. Push done when completed");
                Glas.SetActive(false);
                Strawberry.SetActive(false);
                VanillaYoghurt.SetActive(false);
                Banana.SetActive(false);
                Mixer.SetActive(true);
                animIdleAndPlayMixer.anim.SetBool("Play", true);
                //animIdleAndPlayVanillaYoghurt.anim.SetBool("Play", true);
                //animIdleAndPlayGlas.anim.SetBool("Play", true);
                
                //StartCoroutine(ExampleCoroutine());
                break;
            case 2:
                //vbButtonReset.SetTopPanelText(true);
                StartCoroutine(ExampleCoroutine());

                SetPanelText("Step 3:\nPour the drink into the glas\nPush done when completed");
                Strawberry.SetActive(false);
                VanillaYoghurt.SetActive(false);
                Banana.SetActive(false);
                Mixer.SetActive(true);
                Glas.SetActive(true);
                animIdleAndPlayMixer.anim.SetBool("Play", true);
                animIdleAndPlayGlas.anim.SetBool("Play", true);
                //vbButtonReset.topPanel.SetActive(true);
                //StartCoroutine(ExampleCoroutine());
                break;
            case 3:
                StartCoroutine(ExampleCoroutine());

                vbButtonReset.SetTopPanelText(false);
                SetPanelText("The smoothie is done\nPush done to complete the process");
                Strawberry.SetActive(false);
                VanillaYoghurt.SetActive(false);
                Banana.SetActive(false);
                Mixer.SetActive(false);
                Glas.SetActive(false);
                //StartCoroutine(ExampleCoroutine());
                break;
            case 4:
                resetInstructions();
                break;
        }
    }


    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        vbDoneBtnObj = GameObject.Find("DoneBtnObject");
        vbDoneBtnObj.GetComponent<VirtualButtonBehaviour>().enabled = false;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(4);
        vbDoneBtnObj.GetComponent<VirtualButtonBehaviour>().enabled = true;

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }


    public void resetInstructions() {
        counter = 0;
        CasesForInstructions(counter);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        CasesForInstructions(counter++);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button released");
    }
}
