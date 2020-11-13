using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class vbSmoothieResetButton : MonoBehaviour
{
    public GameObject vbBtnObjReset;
    public GameObject topPanel;
    private bool isReset;
    public Text textObject;

    // Use this for initialization
    void Start()
    {
        topPanel = GameObject.FindGameObjectWithTag("PanelFindTargetTMP");
        vbBtnObjReset = GameObject.FindGameObjectWithTag("vbBtnObjReset");
        Debug.Log("found reset button");
        vbBtnObjReset.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbBtnObjReset.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
    }

    public void SetPanelActive()
    {
        topPanel.SetActive(true);
    }
    /*
    public void SetPanelInactive()
    {
        topPanel.SetActive(false);
    }
    */

    public void SetTopPanelText(bool isReset)
    {
        //   textObject = (Text)GameObject.FindGameObjectWithTag("InstructionText").GetComponent<Text>();

        textObject = (Text)GameObject.FindGameObjectWithTag("topPanelText").GetComponent<Text>();
        if (isReset)
        {
            textObject.text = "Find all the cutlery & ingredients";
        }
        else
        {
            textObject.text = "Enjoy your meal :)";
        }

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        SetPanelActive();
        SetTopPanelText(true);
        Debug.Log("Button RESET pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

        Debug.Log("Button released");
    }
}
