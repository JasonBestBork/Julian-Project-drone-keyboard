using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;

public class Rule_05 : Rule
{

    public GameObject Cube;
    public GameObject P3;
    public GameObject P7;



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
        manager.Initial_Position_And_Rotation();
        NowState = 0;
        IsSccessed = false;
        SwitchBool = true;
    }
    public void UpdateData()
    {
        switch (NowState)
        {
            case 0:
                IsClosed = Cube.GetComponent<Rule_05_Cube>().IsClosed;
                break;
            case 1:
                IsClosed = P3.GetComponent<Rule_05_P3>().IsClosed;
                break;
            case 2:
                IsClosed = P7.GetComponent<Rule_05_P7>().IsClosed;
                break;
            case 3:
                IsClosed = Cube.GetComponent<Rule_05_Cube>().IsClosed;
                break;
            case 4:
                IsClosed = Cube.GetComponent<Rule_05_Cube>().IsClosed;
                break;
            case 5:
                IsClosed = P7.GetComponent<Rule_05_P7>().IsClosed;
                break;
            case 6:
                IsClosed = P3.GetComponent<Rule_05_P3>().IsClosed;
                break;
            case 7:
                IsClosed = Cube.GetComponent<Rule_05_Cube>().IsClosed;
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
        P3.SetActive(false);
        P7.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Error_Check(); CallChangeTarget(); UpdateData();
        if (NowState == 0 && SwitchBool == true)
        {
            Debug.Log("123");
            TargetObject = Cube;
            TargetObject.SetActive(true);
            text.text = "機頭朝外，於起降點H穩定高度約1~2公尺，旋轉機頭朝左，側面定點懸停5秒（含）以上。 ";
            Cube.GetComponent<Rule_05_Cube>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 1 && SwitchBool == true)
        {
            TargetObject = P3;
            TargetObject.SetActive(true);
            text.text = "前進飛行至P3角錐上方，定點側面懸停5秒（含）以上 ";
            P3.GetComponent<Rule_05_P3>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 2 && SwitchBool == true)
        {   
            TargetObject = P7;
            TargetObject.SetActive(true);
            text.text = "後退飛行至P7角錐上方，定點側面懸停5秒（含）以上；";
            P7.GetComponent<Rule_05_P7>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 3 && SwitchBool == true)
        {
            TargetObject =Cube;
            TargetObject.SetActive(true);
            text.text = "前進飛行至起降點H上方，定點側面懸停5秒（含）以上。";
            Cube.GetComponent<Rule_05_Cube>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 4 && SwitchBool == true)
        {
            TargetObject = Cube;
            TargetObject.SetActive(true);
            text.text = "定點等高旋轉至機頭朝右，定點側面懸停5秒（含）以上。";
            Cube.GetComponent<Rule_05_Cube>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 5 && SwitchBool == true)
        {
            TargetObject = P7;
            TargetObject.SetActive(true);
            text.text = "前進飛行至P7角椎上方，定點側面懸停5秒（含）以上；";
            P7.GetComponent<Rule_05_P7>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 6 && SwitchBool == true)
        {
            TargetObject = P3;
            TargetObject.SetActive(true);
            text.text = "後退飛行至P3角錐上方，定點側面懸停5秒（含）以上；";
            P3.GetComponent<Rule_05_P3>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 7 && SwitchBool == true)
        {
            TargetObject = Cube;
            TargetObject.SetActive(true);
            text.text = "前進飛行至起降點H上方，定點側面懸停5秒（含）以上。";
            Cube.GetComponent<Rule_05_Cube>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 8 && SwitchBool == true)
        {
            IsSccessed = true;
            text.text = "完成";
            SwitchBool = false;
            GameObject.Find("rule_manager").GetComponent<manager>().Rule_05_IsSccessed = IsSccessed;
        }
    }
}
