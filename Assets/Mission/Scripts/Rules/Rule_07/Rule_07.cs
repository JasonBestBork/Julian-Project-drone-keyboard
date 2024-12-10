using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Rule_07 : Rule
{
    public Wrong_v1 All_Boundary;

    public GameObject Cube;
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;
    public GameObject P5;
    public GameObject P6;
    public GameObject P7;
    public GameObject A;
    public GameObject B;
    public GameObject H;

    // Start is called before the first frame update
    void Start()
    {

        manager = GameObject.Find("rule_manager").GetComponent<manager>();
        text = GameObject.Find("mission_text").GetComponent<Text>();
        drove = GameObject.FindWithTag("Drove");
        Debug_text = GameObject.Find("mission_debug_text").GetComponent<Text>();
        Cube = GameObject.Find("07_Cube");
        //Boundary = GameObject.Find("03_Boundary");
        P1 = GameObject.Find("07_P1");
        P2 = GameObject.Find("07_P2");
        P3 = GameObject.Find("07_P3");
        P4 = GameObject.Find("07_P4");
        P5 = GameObject.Find("07_P5");
        P6 = GameObject.Find("07_P6");
        P7 = GameObject.Find("07_P7");
        H = GameObject.Find("07_H");
        A = GameObject.Find("07_A");
        B = GameObject.Find("07_B");
    }
    public void OnEnable()
    {
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
                IsClosed = Cube.GetComponent<Rule_07_Cube>().IsClosed;
                break;
            case 1:
                IsClosed = A.GetComponent<Rule_07_A>().IsClosed;
                break;
            case 2:
                IsClosed = P1.GetComponent<Rule_07_P1>().IsClosed;
                break;
            case 3:
                IsClosed = P4.GetComponent<Rule_07_P4>().IsClosed;
                break;
            case 4:
                IsClosed = P5.GetComponent<Rule_07_P5>().IsClosed;
                break;
            case 5:
                IsClosed = P2.GetComponent<Rule_07_P2>().IsClosed;
                break;
            case 6:
                IsClosed = P1.GetComponent<Rule_07_P1>().IsClosed;
                break;
            case 7:
                IsClosed = P2.GetComponent<Rule_07_P2>().IsClosed;
                break;
            case 8:
                IsClosed = P5.GetComponent<Rule_07_P5>().IsClosed;
                break;
            case 9:
                IsClosed = P4.GetComponent<Rule_07_P4>().IsClosed;
                break;
            case 10:
                IsClosed = P1.GetComponent<Rule_07_P1>().IsClosed;
                break;
            case 11:
                IsClosed = A.GetComponent<Rule_07_A>().IsClosed;
                break;
            case 12:
                IsClosed = B.GetComponent<Rule_07_B>().IsClosed;
                break;
            case 13:
                IsClosed = P5.GetComponent<Rule_07_P5>().IsClosed;
                break;
            case 14:
                IsClosed = P6.GetComponent<Rule_07_P6>().IsClosed;
                break;
            case 15:
                IsClosed = P7.GetComponent<Rule_07_P7>().IsClosed;
                break;
            case 16:
                IsClosed = P4.GetComponent<Rule_07_P4>().IsClosed;
                break;
            case 17:
                IsClosed = P5.GetComponent<Rule_07_P5>().IsClosed;
                break;
            case 18:
                IsClosed = P4.GetComponent<Rule_07_P4>().IsClosed;
                break;
            case 19:
                IsClosed = P7.GetComponent<Rule_07_P7>().IsClosed;
                break;
            case 20:
                IsClosed = P6.GetComponent<Rule_07_P6>().IsClosed;
                break;
            case 21:
                IsClosed = P5.GetComponent<Rule_07_P5>().IsClosed;
                break;
            case 22:
                IsClosed = B.GetComponent<Rule_07_B>().IsClosed;
                break;
            case 23:
                IsClosed = Cube.GetComponent<Rule_07_Cube>().IsClosed;
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
        A.SetActive(false);
        B.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Error_Check(); CallChangeTarget(); UpdateData();
        if (NowState == 0 && SwitchBool == true)
        {
            TargetObject = Cube;
            TargetObject.SetActive(true);
            text.text = "機頭朝外，於起降點H穩定高度約1~2公尺，定點懸停5秒（含）以上。 ";
            Cube.GetComponent<Rule_07_Cube>().Initial();
            SwitchBool = false;
        }
        if (NowState == 1 && SwitchBool == true)
        {
            TargetObject = A;
            TargetObject.SetActive(true);
            text.text = "採FPV（第一人稱）方式先飛往A點（或鄰近明顯目標點）";
            A.GetComponent<Rule_07_A>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 2 && SwitchBool == true)
        {
            TargetObject = P1;
            TargetObject.SetActive(true);
            text.text = "以順時針方向前往P1點位飛行，點位應保持於畫面中間位置";
            P1.GetComponent<Rule_07_P1>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 3 && SwitchBool == true)
        {
            TargetObject = P4;
            TargetObject.SetActive(true);
            text.text = "以順時針方向前往P4點位飛行，點位應保持於畫面中間位置";
            P4.GetComponent<Rule_07_P4>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 4 && SwitchBool == true)
        {
            TargetObject = P5;
            TargetObject.SetActive(true);
            text.text = "以順時針方向前往P5點位飛行，點位應保持於畫面中間位置";
            P5.GetComponent<Rule_07_P5>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 5 && SwitchBool == true)
        {
            TargetObject = P2;
            TargetObject.SetActive(true);
            text.text = "以順時針方向前往P2點位飛行，點位應保持於畫面中間位置";
            P2.GetComponent<Rule_07_P2>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 6 && SwitchBool == true)
        {
            TargetObject = P1;
            TargetObject.SetActive(true);
            text.text = "以順時針方向前往P1點位飛行，點位應保持於畫面中間位置";
            P1.GetComponent<Rule_07_P1>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 7 && SwitchBool == true)
        {
            TargetObject = P2;
            TargetObject.SetActive(true);
            text.text = "以逆時針方向前往P2點位飛行，點位應保持於畫面中間位置";
            P2.GetComponent<Rule_07_P2>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 8 && SwitchBool == true)
        {
            TargetObject = P5;
            TargetObject.SetActive(true);
            text.text = "以逆時針方向前往P5點位飛行，點位應保持於畫面中間位置";
            P5.GetComponent<Rule_07_P5>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 9 && SwitchBool == true)
        {
            TargetObject = P4;
            TargetObject.SetActive(true);
            text.text = "以逆時針方向前往P4點位飛行，點位應保持於畫面中間位置";
            P4.GetComponent<Rule_07_P4>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 10 && SwitchBool == true)
        {
            TargetObject = P1;
            TargetObject.SetActive(true);
            text.text = "以逆時針方向前往P1點位飛行，點位應保持於畫面中間位置";
            P1.GetComponent<Rule_07_P1>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 11 && SwitchBool == true)
        {   
            TargetObject = A;
            TargetObject.SetActive(true);
            text.text = "前往A點位飛行";
            A.GetComponent<Rule_07_A>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 12 && SwitchBool == true)
        {
            TargetObject = B;
            TargetObject.SetActive(true);
            text.text = "再由A點升空飛往B點（或鄰近明顯目標點）";
            B.GetComponent<Rule_07_B>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 13 && SwitchBool == true)
        {
            TargetObject = P5;
            TargetObject.SetActive(true);
            text.text = "以順時針方向前往P5點位飛行，點位應保持於畫面中間位置";
            P5.GetComponent<Rule_07_P5>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 14 && SwitchBool == true)
        {
            TargetObject = P6;
            TargetObject.SetActive(true);
            text.text = "以順時針方向前往P6點位飛行，點位應保持於畫面中間位置";
            P6.GetComponent<Rule_07_P6>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 15 && SwitchBool == true)
        {
            TargetObject = P7;
            TargetObject.SetActive(true);
            text.text = "以順時針方向前往P7點位飛行，點位應保持於畫面中間位置";
            P7.GetComponent<Rule_07_P7>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 16 && SwitchBool == true)
        {
            TargetObject = P4;
            TargetObject.SetActive(true);
            text.text = "以順時針方向前往P4點位飛行，點位應保持於畫面中間位置";
            P4.GetComponent<Rule_07_P4>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 17 && SwitchBool == true)
        {
            TargetObject = P5;
            TargetObject.SetActive(true);
            text.text = "以順時針方向前往P5點位飛行，點位應保持於畫面中間位置";
            P5.GetComponent<Rule_07_P5>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 18 && SwitchBool == true)
        {
            TargetObject = P4;
            TargetObject.SetActive(true);
            text.text = "以逆時針方向前往P4點位飛行，點位應保持於畫面中間位置";
            P4.GetComponent<Rule_07_P4>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 19 && SwitchBool == true)
        {
            TargetObject = P7;
            TargetObject.SetActive(true);
            text.text = "以逆時針方向前往P7點位飛行，點位應保持於畫面中間位置";
            P7.GetComponent<Rule_07_P7>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 20 && SwitchBool == true)
        {
            TargetObject = P6;
            TargetObject.SetActive(true);
            text.text = "以逆時針方向前往P6點位飛行，點位應保持於畫面中間位置";
            P6.GetComponent<Rule_07_P6>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 21 && SwitchBool == true)
        {
            TargetObject = P5;
            TargetObject.SetActive(true);
            text.text = "以逆時針方向前往P5點位飛行，點位應保持於畫面中間位置";
            P5.GetComponent<Rule_07_P5>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 22 && SwitchBool == true)
        {   
            TargetObject = B;
            TargetObject.SetActive(true);
            text.text = "前往B點位飛行";
            B.GetComponent<Rule_07_B>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 23 && SwitchBool == true)
        {
            TargetObject = Cube;
            TargetObject.SetActive(true);
            text.text = " 返航於起降點H降落，機頭朝外，起落架不得超過標示範圍。 ";
            Cube.GetComponent<Rule_07_Cube>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 24 && SwitchBool == true)
        {
            IsSccessed = true;
            text.text = "完成";
            SwitchBool = false;
            GameObject.Find("rule_manager").GetComponent<manager>().Rule_07_IsSccessed = IsSccessed;
        }
    }
}
