using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using System;

public class vbSmoothieButton : MonoBehaviour
{
    private vbButtonReset vbButtonReset;
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
    void Start()
    {
        Mixer = GameObject.FindGameObjectWithTag("Mixer");
        Glas = GameObject.FindGameObjectWithTag("Glas");
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
        animIdleAndPlayVanillaYoghurt.anim.SetBool("Play", true);
        animIdleAndPlayStrawberry.anim.SetBool("Play", true);
        animIdleAndPlayGlas.anim.SetBool("Play", true);
        animIdleAndPlayMixer.anim.SetBool("Play", true);
        animIdleAndPlayBanana.anim.SetBool("Play", true);
    }

    public void SetPanelActive()
    {
        sidePanel.SetActive(true);
    }

    public void SetPanelInactive()
    {
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

    public void CasesForInstructions(int imageTargetNumber)
    {
        switch (imageTargetNumber)
        {
            case 0:
                //vbButtonReset.topPanel.SetActive(true);
                animIdleAndPlayVanillaYoghurt.anim.SetBool("Play", true);
                animIdleAndPlayStrawberry.anim.SetBool("Play", true);
                animIdleAndPlayBanana.anim.SetBool("Play", true);
                SetPanelActive();
                SetPanelText("Step 1:\n1. Find Strawberry, Banana And Vanilla Yoghurt bread\n2. Add them to the Mixer\n3. Push done when completed");
                vbButtonReset.SetTopPanelText(true);
                StartCoroutine(ExampleCoroutine());
                Strawberry.SetActive(true);
                VanillaYoghurt.SetActive(true);
                Banana.SetActive(true);
                Mixer.SetActive(true);
                Glas.SetActive(false);

                break;
            case 1:
                vbButtonReset.SetTopPanelText(true);
                //vbButtonReset.topPanel.SetActive(true);
                //animIdleAndPlayVanillaYoghurt.anim.SetBool("Play", true);
                //animIdleAndPlayGlas.anim.SetBool("Play", true);
                animIdleAndPlayMixer.anim.SetBool("Play", true);
                SetPanelText("Step 2:\n1. Mix the fruits in the mixer\n2. Push done when completed");
                Glas.SetActive(false);
                Strawberry.SetActive(false);
                VanillaYoghurt.SetActive(false);
                Banana.SetActive(false);
                Mixer.SetActive(true);
                StartCoroutine(ExampleCoroutine());
                break;
            case 2:
                //vbButtonReset.topPanel.SetActive(true);
                SetPanelText("Pour the drink into the glas\nPush done to complete the process");
                vbButtonReset.SetTopPanelText(false);
                Strawberry.SetActive(false);
                VanillaYoghurt.SetActive(false);
                Banana.SetActive(false);
                Mixer.SetActive(true);
                Glas.SetActive(true);
                animIdleAndPlayMixer.anim.SetBool("Play", true);
                animIdleAndPlayGlas.anim.SetBool("Play", true);
                StartCoroutine(ExampleCoroutine());
                break;
            case 3:
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
        yield return new WaitForSeconds(3);
        vbDoneBtnObj.GetComponent<VirtualButtonBehaviour>().enabled = true;

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }


    public void resetInstructions()
    {
        vbButtonReset.SetPanelActive();
        vbButtonReset.SetTopPanelText(false);
        Strawberry.SetActive(true);
        VanillaYoghurt.SetActive(true);
        Banana.SetActive(true);
        Mixer.SetActive(true);
        Glas.SetActive(false);
        counter = 0;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        CasesForInstructions(counter++);
        //counter++;
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button released");
    }
}
