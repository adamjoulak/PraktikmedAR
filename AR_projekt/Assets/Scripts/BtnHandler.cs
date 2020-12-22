using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnHandler : MonoBehaviour {

    public void SetTextViaInput(string input) {
        
        Text txt = transform.Find("SmoothieText").GetComponent<Text>();
        txt.text = input;
        
        //Debug.Log("Input: " + input);
    }

}
