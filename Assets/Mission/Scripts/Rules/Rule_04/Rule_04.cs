using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;
public class Rule_04 : Rule
{
    public Wrong_for_04_01 _Boundary;

    public GameObject Cube;
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;
    public GameObject P5;
    public GameObject P6;
    public GameObject P7;
    public GameObject H;


    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("rule_manager").GetComponent<manager>();
        text = GameObject.Find("mission_text").GetComponent<Text>();
        drove = GameObject.FindWithTag("Drove");
        Debug_text = GameObject.Find("mission_debug_text").GetComponent<Text>();
    }
    public void OnEnable()
    {
        Close_All_PPoint();
        manager.Initial_Position_And_Rotation();
        IsSccessed = false;
        SwitchBool = true;
        NowState = 0; 
    }

    public void UpdateData()
    {
        switch (NowState)
        {
            case 0:
                IsClosed = Cube.GetComponent<Rule_04_Cube>().IsClosed;
                break;
            case 1:
                IsClosed = P4.GetComponent<Rule_04_P4>().IsClosed;
                break;
            case 2:
                IsClosed = P1.GetComponent<Rule_04_P1>().IsClosed;
                break;
            case 3:
                IsClosed = P2.GetComponent<Rule_04_P2>().IsClosed;
                break;
            case 4:
                IsClosed = P3.GetComponent<Rule_04_P3>().IsClosed;
                break;
            case 5:
                IsClosed = P4.GetComponent<Rule_04_P4>().IsClosed;
                break;
            case 6:
                IsClosed = P5.GetComponent<Rule_04_P5>().IsClosed;
                break;
            case 7:
                IsClosed = P6.GetComponent<Rule_04_P6>().IsClosed;
                break;
            case 8:
                IsClosed = P7.GetComponent<Rule_04_P7>().IsClosed;
                break;
            case 9:
                IsClosed = P4.GetComponent<Rule_04_P4>().IsClosed;
                break;
            case 10:
                IsClosed = Cube.GetComponent<Rule_04_Cube>().IsClosed;
                break;
            default:
                IsClosed = false;
                break;
        }
        manager.ChangeTouchData(IsClosed, NowInBox);
    }
    public void Close_All_PPoint()
    {
        Cube.SetActive(false);
        P1.SetActive(false);
        P2.SetActive(false);
        P3.SetActive(false);
        P4.SetActive(false);
        P5.SetActive(false);
        P6.SetActive(false);
        P7.SetActive(false);
    }


    public void Error_Check_for04()
    {
        IsOut = _Boundary.IsOut;
        Out_Countdown = (float)_Boundary.OutTimeCountDown;
        if (IsOut&& Out_Countdown<=0)
        {
            Out_Countdown = 0;
            Debug_text.text = "Error.Please retry the level. ";
            Console.WriteLine("Boundary error from " + this.name);
        }
        manager.ChangeOut(IsOut, Out_Countdown);
    }
    // Update is called once per frame
    void Update()
    {
        Error_Check_for04(); CallChangeTarget(); UpdateData();
        if (NowState == 0 && SwitchBool == true)
        {
            TargetObject = Cube;
            TargetObject.SetActive(true);
            Cube.GetComponent<Rule_04_Cube>().OnEnable();
            text.text = "機頭朝外，於起降點H穩定高度約1~2公尺，定點懸停5秒（含）以上。 ";
            SwitchBool = false;
        }
        if (NowState == 1 && SwitchBool == true)
        {
            TargetObject = P4;
            P4.SetActive(true);
            text.text = "機頭一律朝飛行方向，前往P4點";
            SwitchBool = false;
        }
        else if (NowState == 2 && SwitchBool == true)
        {
            TargetObject = P1;
            P1.SetActive(true);
            text.text = "機頭一律朝飛行方向，前往P1點";
            SwitchBool = false;
        }
        else if (NowState == 3 && SwitchBool == true)
        {
            TargetObject = P2;
            P2.SetActive(true);
            text.text = "機頭一律朝飛行方向，前往P2點";
            SwitchBool = false;
        }
        else if (NowState == 4 && SwitchBool == true)
        {
            TargetObject = P3;
            P3.SetActive(true);
            text.text = "機頭一律朝飛行方向，前往P3點";
            SwitchBool = false;
        }
        else if (NowState == 5 && SwitchBool == true)
        {
            TargetObject = P4;
            P4.SetActive(true);
            text.text = "機頭一律朝飛行方向，前往P4點";
            SwitchBool = false;
        }
        else if (NowState == 6 && SwitchBool == true)
        {
            TargetObject = P5;
            P5.SetActive(true);
            text.text = "機頭一律朝飛行方向，前往P5點";
            SwitchBool = false;
        }
        else if (NowState == 7 && SwitchBool == true)
        { 
            TargetObject = P6;
            text.text = "機頭一律朝飛行方向，前往P6點";
            P6.SetActive(true);
            SwitchBool = false;
        }
        else if (NowState == 8 && SwitchBool == true)
        {
            TargetObject = P7;
            text.text = "機頭一律朝飛行方向，前往P7點";
            P7.SetActive(true);
            SwitchBool = false;
        }
        else if (NowState == 9 && SwitchBool == true)
        {
            TargetObject = P4;
            text.text = "機頭一律朝飛行方向，前往P4點";
            P4.SetActive(true);
            SwitchBool = false;
        }
        else if (NowState == 10 && SwitchBool == true)
        {
            TargetObject = Cube;
            TargetObject.SetActive(true);
            text.text = "返航起降點H，機頭朝外並維持等高懸停";
            SwitchBool = false;
        }
        else if (NowState == 11 && SwitchBool == true)
        {
            IsSccessed = true;
            text.text = "完成";
            SwitchBool = false;
            GameObject.Find("rule_manager").GetComponent<manager>().Rule_04_IsSccessed = IsSccessed;
        }
    }
}
