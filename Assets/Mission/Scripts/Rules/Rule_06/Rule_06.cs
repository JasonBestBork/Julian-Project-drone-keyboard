using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Rule_06 : Rule
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
        manager.Initial_Position_And_Rotation();
        IsSccessed = false;
        IsSccessed = false;
        SwitchBool = true;
        NowState = 0;
    }
    public void UpdateData()
    {
        switch (NowState)
        {
            case 0:
                IsClosed = Cube.GetComponent<Rule_06_Cube>().IsClosed;
                break;
            case 1:
                IsClosed = P3.GetComponent<Rule_06_P3>().IsClosed;
                break;
            case 2:
                IsClosed = P1.GetComponent<Rule_06_P1>().IsClosed;
                break;
            case 3:
                IsClosed = P5.GetComponent<Rule_06_P5>().IsClosed;
                break;
            case 4:
                IsClosed = P7.GetComponent<Rule_06_P7>().IsClosed;
                break;
            case 5:
                IsClosed = Cube.GetComponent<Rule_06_Cube>().IsClosed;
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
    void Update()
    {
        Error_Check(); CallChangeTarget(); UpdateData();
        if (NowState == 0 && SwitchBool == true)
        {
            TargetObject = Cube;
            TargetObject.SetActive(true);
            text.text = "機頭朝外，於起降點H穩定高度約1~2公尺，定點懸停5秒（含）以上。 ";
            Cube.GetComponent<Rule_06_Cube>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 1 && SwitchBool == true)
        {   
            TargetObject = P3;
            TargetObject.SetActive(true);
            text.text = "切換至定位模式，以儀表飛行（第一人稱）前往P3點執行任務航線飛行，飛至點上方時須參考影像穩定懸停5秒（含）以上。應考人應隨時注意速度、高度、距離及週圍障礙物。";
            P3.GetComponent<Rule_06_P3>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 2 && SwitchBool == true)
        {
            TargetObject = P1;
            TargetObject.SetActive(true);
            text.text = "切換至定位模式，以儀表飛行（第一人稱）前往P1點執行任務航線飛行，飛至點上方時須參考影像穩定懸停5秒（含）以上。應考人應隨時注意速度、高度、距離及週圍障礙物。";
            P1.GetComponent<Rule_06_P1>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 3 && SwitchBool == true)
        {
            TargetObject = P5;
            TargetObject.SetActive(true);
            text.text = "切換至定位模式，以儀表飛行（第一人稱）前往P5點執行任務航線飛行，飛至點上方時須參考影像穩定懸停5秒（含）以上。應考人應隨時注意速度、高度、距離及週圍障礙物。";
            P5.GetComponent<Rule_06_P5>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 4 && SwitchBool == true)
        {   
            TargetObject = P7;
            TargetObject.SetActive(true);
            text.text = "切換至定位模式，以儀表飛行（第一人稱）前往P7點執行任務航線飛行，飛至點上方時須參考影像穩定懸停5秒（含）以上。應考人應隨時注意速度、高度、距離及週圍障礙物。";
            P7.GetComponent<Rule_06_P7>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 5 && SwitchBool == true)
        {
            TargetObject = Cube;
            TargetObject.SetActive(true);
            text.text = "飛至P7完成儀表飛行後，返航於起降點H降落，起落架不得超過標示範圍。 ";
            Cube.GetComponent<Rule_06_Cube>().Initial();
            SwitchBool = false;
        }
        else if (NowState == 6 && SwitchBool == true)
        {
            IsSccessed = true;
            text.text = "完成";
            SwitchBool = false;
            GameObject.Find("rule_manager").GetComponent<manager>().Rule_06_IsSccessed = IsSccessed;
        }
    }
}
