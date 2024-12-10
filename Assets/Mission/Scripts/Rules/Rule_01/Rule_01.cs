using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Rule_01 : Rule
{

    public GameObject Cube;

    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("rule_manager").GetComponent<manager>();
        text = GameObject.Find("mission_text").GetComponent<Text>();
        drove = GameObject.FindWithTag("Drove");
        Debug_text = GameObject.Find("mission_debug_text").GetComponent<Text>();
        Cube = GameObject.Find("01_Cube");
        P1 = GameObject.Find("01_P1");
        P2 = GameObject.Find("01_P2");
        P3 = GameObject.Find("01_P3");
        P4 = GameObject.Find("01_P4");
        Debug.Log("Ready " + this.name);
    }
    public void OnEnable()
    {
        manager.Initial_Position_And_Rotation();
        IsSccessed = false;
        NowState = 0;
        SwitchBool = true;

    }
    // Update is called once per frame

    public void UpdateData()
    {
        switch(NowState)
        {
            case 0:
                IsClosed = Cube.GetComponent<Rule_01_Cube>().IsClosed;
                break;
            case 1:
                IsClosed = P1.GetComponent<Rule_01_P1>().IsClosed;
                break;
            case 2:
                IsClosed = P2.GetComponent<Rule_01_P2>().IsClosed;
                break;
            case 3:
                IsClosed = P3.GetComponent<Rule_01_P3>().IsClosed;
                break;
            case 4:
                IsClosed = P4.GetComponent<Rule_01_P4>().IsClosed;
                break;
            case 5:
                IsClosed = Cube.GetComponent<Rule_01_Cube>().IsClosed;
                break;
            default:
                IsClosed = false;
                break;
        }
        manager.ChangeTouchData(IsClosed,NowInBox);
    }

    public void Close_All_PPoint()
    {
        Cube.SetActive(false);
        P1.SetActive(false);
        P2.SetActive(false);
        P3.SetActive(false);
        P4.SetActive(false);
    }
    void Update()
    {
        UpdateData();
        Error_Check(); CallChangeTarget();
        if (NowState == 0 && SwitchBool == true)
        {
            TargetObject = Cube;
            TargetObject.SetActive(true);
            text.text = "機頭朝外，於起降點H穩定高度約1~2公尺，定點懸停5秒（含）以上。 ";
            Cube.GetComponent<Rule_01_Cube>().Initial();
            Console.WriteLine("Rule 01 initial");
            SwitchBool = false;
        }
        else if (NowState == 1 && SwitchBool == true)
        {
            TargetObject = P1;
            TargetObject.SetActive(true);
            text.text = "旋轉機頭朝頂風方向飛行，過程中機頭一律朝飛行方向並應穩定航高，執行高度保持五邊航線飛行，前往P1點";
            P1.GetComponent<Rule_01_P1>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 2 && SwitchBool == true)
        {
            TargetObject = P2;
            TargetObject.SetActive(true);
            text.text = "旋轉機頭朝頂風方向飛行，過程中機頭一律朝飛行方向並應穩定航高，執行高度保持五邊航線飛行，前往P2點";
            P2.GetComponent<Rule_01_P2>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 3 && SwitchBool == true)
        {
            TargetObject = P3;
            TargetObject.SetActive(true);
            text.text = "旋轉機頭朝頂風方向飛行，過程中機頭一律朝飛行方向並應穩定航高，執行高度保持五邊航線飛行，前往P3點";
            P3.GetComponent<Rule_01_P3>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 4 && SwitchBool == true)
        {
            TargetObject = P4;
            TargetObject.SetActive(true);
            text.text = "旋轉機頭朝頂風方向飛行，過程中機頭一律朝飛行方向並應穩定航高，執行高度保持五邊航線飛行，前往P4點";
            P4.GetComponent<Rule_01_P4>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 5 && SwitchBool == true)
        {
            TargetObject = Cube;
            TargetObject.SetActive(true);
            text.text = "完成飛行1圈後，飛回起降點H上方，維持高度約1~2公尺懸停";
            Cube.GetComponent<Rule_01_Cube>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 6 && SwitchBool == true)
        {
            TargetObject = null;
            IsSccessed = true;
            manager.Rule_01_IsSccessed = IsSccessed;
            text.text = "完成";
            SwitchBool = false;
        }
    }
}
