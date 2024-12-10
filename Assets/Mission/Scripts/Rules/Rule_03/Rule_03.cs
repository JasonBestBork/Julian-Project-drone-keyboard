using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Rule_03 : Rule
{
    public GameObject Cube;
    public GameObject P1;
    public GameObject P3;
    public GameObject P5;
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
                IsClosed = Cube.GetComponent<Rule_03_Cube>().IsClosed;
                break;
            case 1:
                IsClosed = P3.GetComponent<Rule_03_P3>().IsClosed;
                break;
            case 2:
                IsClosed = P1.GetComponent<Rule_03_P1>().IsClosed;
                break;
            case 3:
                IsClosed = P5.GetComponent<Rule_03_P5>().IsClosed;
                break;
            case 4:
                IsClosed = P7.GetComponent<Rule_03_P7>().IsClosed;
                break;
            case 5:
                IsClosed = Cube.GetComponent<Rule_03_Cube>().IsClosed;
                break;
            case 6:
                IsClosed = P7.GetComponent<Rule_03_P7>().IsClosed;
                break;
            case 7:
                IsClosed = P5.GetComponent<Rule_03_P5>().IsClosed;
                break;
            case 8:
                IsClosed = P1.GetComponent<Rule_03_P1>().IsClosed;
                break;
            case 9:
                IsClosed = P3.GetComponent<Rule_03_P3>().IsClosed;
                break;
            case 10:
                IsClosed = Cube.GetComponent<Rule_03_Cube>().IsClosed;
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
        P3.SetActive(false);
        P5.SetActive(false);
        P7.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Error_Check(); CallChangeTarget(); UpdateData();
        if (NowState == 0 && SwitchBool == true)
        {
            TargetObject = Cube;
            text.text = "機頭朝外，於起降點H穩定高度約1~2公尺，定點懸停5秒（含）以上。 ";
            Cube.SetActive(true);
            SwitchBool = false;
        }
        else if (NowState == 1 && SwitchBool == true)
        {
            TargetObject = P3;
            text.text = "機頭一律朝飛行方向，往左前往P3點，過程中應維持穩定航高，並於每3點懸停5秒（含）以上。 ";
            P3.SetActive(true);
            SwitchBool = false;
        }
        else if (NowState == 2 && SwitchBool == true)
        {
            TargetObject = P1;
            text.text = "機頭一律朝飛行方向，往左前往P1點，過程中應維持穩定航高，並於每3點懸停5秒（含）以上。 ";
            P1.SetActive(true);
            SwitchBool = false;
        }
        else if (NowState == 3 && SwitchBool == true)
        {
            TargetObject = P5;
            text.text = "機頭一律朝飛行方向，往左前往P5點，過程中應維持穩定航高，並於每3點懸停5秒（含）以上。 ";
            P5.SetActive(true);
            SwitchBool = false;
        }
        else if (NowState == 4 && SwitchBool == true)
        {
            TargetObject = P7;
            text.text = "機頭一律朝飛行方向，往左前往P7點，過程中應維持穩定航高，並於每3點懸停5秒（含）以上。 ";
            P7.SetActive(true);
            SwitchBool = false;
        }
        else if (NowState == 5 && SwitchBool == true)
        {
            TargetObject = Cube;
            Cube.SetActive(true);
            text.text = "機頭一律朝飛行方向，飛回至起降點H，過程中應維持穩定航高，並於每3點懸停5秒（含）以上。 ";
            SwitchBool = false;
        }
        else if (NowState == 6 && SwitchBool == true)
        {
            TargetObject = P7;
            text.text = "機頭一律朝飛行方向，往左前往P7點，過程中應維持穩定航高，並於每3點懸停5秒（含）以上。 ";
            P7.SetActive(true);
            SwitchBool = false;
        }
        else if (NowState == 7 && SwitchBool == true)
        {
            TargetObject = P5;
            text.text = "機頭一律朝飛行方向，往左前往P5點，過程中應維持穩定航高，並於每3點懸停5秒（含）以上。 ";
            P5.SetActive(true);
            SwitchBool = false;
        }
        else if (NowState == 8 && SwitchBool == true)
        {
            TargetObject = P1;
            text.text = "機頭一律朝飛行方向，往左前往P1點，過程中應維持穩定航高，並於每3點懸停5秒（含）以上。 ";
            P1.SetActive(true);
            SwitchBool = false;
        }
        else if (NowState == 9 && SwitchBool == true)
        {
            TargetObject = P3;
            text.text = "機頭一律朝飛行方向，往左前往P3點，過程中應維持穩定航高，並於每3點懸停5秒（含）以上。 ";
            P3.SetActive(true);
            SwitchBool = false;
        }
        else if (NowState == 10 && SwitchBool == true)
        {
            TargetObject = Cube;
            text.text = "機頭一律朝飛行方向，飛回至起降點H，過程中應維持穩定航高，並於每3點懸停5秒（含）以上。 ";
            Cube.SetActive(true);
            SwitchBool = false;
        }
        else if (NowState == 11 && SwitchBool == true)
        {
            IsSccessed = true;
            text.text = "完成";
            SwitchBool = false;
            GameObject.Find("rule_manager").GetComponent<manager>().Rule_03_IsSccessed = IsSccessed;
        }
    }
}
