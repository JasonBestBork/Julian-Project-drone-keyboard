using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;


public class manager : Rule_Record_Data
{
    const string Rule_00_Name = "0.檢查";
    const string Rule_01_Name = "1.高度保持五邊飛行";
    const string Rule_02_Name = "2.定點起降及四面停懸";
    const string Rule_03_Name = "3.矩形航線";
    const string Rule_04_Name = "4.八字水平圓";
    const string Rule_05_Name = "5.側面懸停及前進後退";
    const string Rule_06_Name = "6.任務模式飛行";
    const string Rule_07_Name = "7.興趣點飛行";
    const string Rule_08_Name = "8.緊急程序處置";

    const string Level_00_Name = "基本級<2KG";
    const string Level_01_Name = "基本級";
    const string Level_02_Name = "高級第一組";
    const string Level_03_Name = "高級第二組";
    const string Level_04_Name = "高級第三組";

    public bool switchlevel;
    public int NowRule;
    public int NowLevel;

    public GameObject Ground;
    public bool DroneIsFly;
    public Text Error_text;

    [HeaderAttribute("Rule_Objects")]
    public GameObject Rule_01;
    public GameObject Rule_02;
    public GameObject Rule_03;
    public GameObject Rule_04;
    public GameObject Rule_05;
    public GameObject Rule_06;
    public GameObject Rule_07;
    [HeaderAttribute("Rule_Successed")]
    public bool Rule_01_IsSccessed;
    public bool Rule_02_IsSccessed;
    public bool Rule_03_IsSccessed;
    public bool Rule_04_IsSccessed;
    public bool Rule_05_IsSccessed;
    public bool Rule_06_IsSccessed;
    public bool Rule_07_IsSccessed;

    public output output;
    public Eventmanager_test eventmanager;

    // Start is called before the first frame update
    void OnEnable()
    {
        Error_text = GameObject.Find("Error_text").GetComponent<Text>();
        Drone = GameObject.FindGameObjectWithTag("Drove");
        Initial_Position_And_Rotation();
        ClosedAllSccessed();
        Initial_Record_Data();
        CloseAllRule();
        if (Setting.Complete == true)
        {
            NowLevel = Setting.Level;
        }
        else if (Setting.Complete == false)//單關
        {
            NowRule = Setting.Stage;
            switchlevel = true;
        }
    }

    void CountTime()
    {
        count_time += Time.deltaTime;
        total_count_time += Time.deltaTime;
    }
    void DetectDroneFly()
    {
        /*
         * if(無人機可以飛)
         *  DroneIsFly=True;
         * else
         *  DroneIsFly=false;
         */
    }

    string GetLevelName(int lv)//回傳等級字串
    {
        if(lv ==0)
        {
            return Level_00_Name;
        }
        else if (lv == 1)
        {
            return Level_01_Name;
        }
        else if (lv == 2)
        {
            return Level_02_Name;
        }
        else if (lv == 3)
        {
            return Level_03_Name;
        }
        else //(lv == 4)
        {
            return Level_04_Name;
        }
    }
    string GetRuleName(int ru)//回傳關卡字串
    {
        if (ru == 0)
        {
            return Rule_00_Name;
        }
        else if (ru == 1)
        {
            return Rule_01_Name;
        }
        else if (ru == 2)
        {
            return Rule_02_Name;
        }
        else if (ru == 3)
        {
            return Rule_03_Name;
        }
        else if (ru == 4)
        {
            return Rule_04_Name;
        }
        else if (ru == 5)
        {
            return Rule_05_Name;
        }
        else if (ru == 6)
        {
            return Rule_06_Name;
        }
        else if (ru == 7)
        {
            return Rule_07_Name;
        }
        else //(ru == 8)
        {
            return Rule_08_Name;
        }
    }
    void SuccessLevelCheck()
    {
        if (NowRule == 100)
        {
            eventmanager.settle("< " + GetLevelName(NowLevel) + " 通關>"); //完整流程通關
            NowRule = -1;
            NowLevel = -1;
            ClosedAllSccessed();
        }
        if(NowLevel== -1 &&
            (Rule_01_IsSccessed|| 
            Rule_02_IsSccessed ||
            Rule_03_IsSccessed ||
            Rule_04_IsSccessed ||
            Rule_05_IsSccessed ||
            Rule_06_IsSccessed ||
            Rule_07_IsSccessed))
        {
            eventmanager.settle("< " + GetRuleName(NowRule) + " 通關>");//單關通關
            output.RecordData(NowRule.ToString(), true);
            NowRule = -1;
            ClosedAllSccessed();
            ChangeRule();
            Debug.Log("Successed!");
        }
    }
    public void ClosedAllSccessed()
    {
        Rule_01_IsSccessed = false;
        Rule_02_IsSccessed = false;
        Rule_03_IsSccessed = false;
        Rule_04_IsSccessed = false;
        Rule_05_IsSccessed = false;
        Rule_06_IsSccessed = false;
        Rule_07_IsSccessed = false;
    }
    void FailCheck()
    {
        if(IsOut&&Out_Countdown<=0)
        {
            Error_text.text = "Fail because Out of Boundary";
            Debug.Log("Fail!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            IsOut = false; Out_Countdown = 0;
            eventmanager.settle("< 失敗(超出範圍) >");//開啟失敗結算畫面(超出範圍)
            output.RecordData(NowRule.ToString(), false);
            CloseAllRule();
        }
        else if (Ground.GetComponent<Wrong_Ground>().IsFail ==true)
        {
            Error_text.text = "Fail because fall";
            Debug.Log("Fail because fall !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            IsOut = false; Out_Countdown = 0;
            eventmanager.settle("< 失敗(墜地) >");//開啟失敗結算畫面(墜地)墜地
            output.RecordData(NowRule.ToString(), false);
            CloseAllRule();
        }
    }
    public void Initial_Record_Data()
    {
        switchlevel = false;
        NowRule = -1;
        NowLevel = -1;
        Target_Distance = 0f ;
        IsClosed = false;
        Touching = false;
        IsOut = false ;
        Out_Countdown = 0f;
    }
    public void Initial_Position_And_Rotation()
    {
        GameObject.FindGameObjectWithTag("Drove").transform.position = new Vector3(0f, 100f, 0f);
        GameObject.FindGameObjectWithTag("Drove").transform.position = new Vector3(0f, 0.619f, 0f);
        GameObject.FindGameObjectWithTag("Drove").transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }
    public bool SetSwitch(bool a)
    {
        switchlevel = a;
        return a;
    }
    void Under2()
    {
        if (NowRule == -1)
        {
            NowRule = 2;
            switchlevel = true;
        }
        else if (Rule_02_IsSccessed && NowRule == 2)
        {
            eventmanager.settle("< " + GetRuleName(NowRule) + " 通關>", true);//級別訓練中單關通關
            output.RecordData(NowRule.ToString(),true);
            NowRule = 3;
        }
        else if (Rule_03_IsSccessed && NowRule == 3)
        {
            //目前到這裡
            output.RecordData(NowRule.ToString(),true);
            NowRule = 100;
            switchlevel = true;
            Console.WriteLine("Under2 Successed");
        }

    }

    void Basic()
    {
        if (NowRule == -1)
        {
            NowRule = 2;
            switchlevel = true;
        }
        else if (Rule_02_IsSccessed && NowRule == 2)
        {
            eventmanager.settle("< " + GetRuleName(NowRule) + " 通關>", true);//級別訓練中單關通關
            output.RecordData(NowRule.ToString(),true);
            NowRule = 4;
        }
        else if (Rule_04_IsSccessed && NowRule == 4)
        {
            eventmanager.settle("< " + GetRuleName(NowRule) + " 通關>", true);//級別訓練中單關通關
            output.RecordData(NowRule.ToString(),true);
            NowRule = 5;
        }
        else if (Rule_05_IsSccessed && NowRule == 5)
        {
            eventmanager.settle("< " + GetRuleName(NowRule) + " 通關>", true);//級別訓練中單關通關
            output.RecordData(NowRule.ToString(),true);
            NowRule = 1;
        }
        else if (Rule_01_IsSccessed && NowRule == 1)
        {
            //目前到這裡
            output.RecordData(NowRule.ToString(),true);
            NowRule = 100;
            switchlevel = true;
            Console.WriteLine("Under2 Successed");
        }
    }
    void HighOne()
    {
        if (NowRule == -1)
        {
            NowRule = 2;
            switchlevel = true;
        }
        else if (Rule_02_IsSccessed && NowRule == 2)
        {
            eventmanager.settle("< " + GetRuleName(NowRule) + " 通關>", true);//級別訓練中單關通關
            output.RecordData(NowRule.ToString(),true);
            NowRule = 4;
        }
        else if (Rule_04_IsSccessed && NowRule == 4)
        {
            eventmanager.settle("< " + GetRuleName(NowRule) + " 通關>", true);//級別訓練中單關通關
            output.RecordData(NowRule.ToString(),true);
            NowRule = 3;
        }
        else if (Rule_03_IsSccessed && NowRule == 3)
        {
            eventmanager.settle("< " + GetRuleName(NowRule) + " 通關>", true);//級別訓練中單關通關
            output.RecordData(NowRule.ToString(),true);
            NowRule = 6;
        }
        else if (Rule_06_IsSccessed && NowRule == 6)
        {
            //目前到這裡
            output.RecordData(NowRule.ToString(),true);
            NowRule = 100;
            switchlevel = true;
            Console.WriteLine("Under2 Successed");
        }
    }
    void HighTwo()
    {
        if (NowRule == -1)
        {
            NowRule = 2;
            switchlevel = true;
        }
        else if (Rule_02_IsSccessed && NowRule == 2)
        {
            eventmanager.settle("< " + GetRuleName(NowRule) + " 通關>", true);//級別訓練中單關通關
            output.RecordData(NowRule.ToString(),true);
            NowRule = 4;
        }
        else if (Rule_04_IsSccessed && NowRule == 4)
        {
            eventmanager.settle("< " + GetRuleName(NowRule) + " 通關>", true);//級別訓練中單關通關
            output.RecordData(NowRule.ToString(),true);
            NowRule = 3;
        }
        else if (Rule_03_IsSccessed && NowRule == 3)
        {
            eventmanager.settle("< " + GetRuleName(NowRule) + " 通關>", true);//級別訓練中單關通關
            output.RecordData(NowRule.ToString(),true);
            NowRule = 6;
        }
        else if (Rule_06_IsSccessed && NowRule == 6)
        {
            //目前到這裡
            output.RecordData(NowRule.ToString(),true);
            NowRule = 100;
            switchlevel = true;
            Console.WriteLine("Under2 Successed");
        }
    }
    void HighThree()
    {
        if (NowRule == -1)
        {
            eventmanager.settle("< " + GetRuleName(NowRule) + " 通關>", true);//級別訓練中單關通關
            output.RecordData(NowRule.ToString(),true);
            NowRule = 2;
        }
        else if (Rule_02_IsSccessed && NowRule == 2)
        {
            eventmanager.settle("< " + GetRuleName(NowRule) + " 通關>", true);//級別訓練中單關通關
            output.RecordData(NowRule.ToString(),true);
            NowRule = 4;
        }
        else if (Rule_04_IsSccessed && NowRule == 4)
        {
            eventmanager.settle("< " + GetRuleName(NowRule) + " 通關>", true);//級別訓練中單關通關
            output.RecordData(NowRule.ToString(),true);
            NowRule = 3;
        }
        else if (Rule_03_IsSccessed && NowRule == 3)
        {
            eventmanager.settle("< " + GetRuleName(NowRule) + " 通關>", true);//級別訓練中單關通關
            output.RecordData(NowRule.ToString(),true);
            NowRule = 7;
        }
        else if (Rule_07_IsSccessed && NowRule == 6)
        {
            //目前到這裡
            output.RecordData(NowRule.ToString(),true);
            NowRule = 100;
            switchlevel = true;
            Console.WriteLine("Under2 Successed");
        }

    }
    void CloseAllRule()
    {
        Rule_01.SetActive(false);
        Rule_02.SetActive(false);
        Rule_03.SetActive(false);
        Rule_04.SetActive(false);
        Rule_05.SetActive(false);
        Rule_06.SetActive(false);
        Rule_07.SetActive(false);
    }
    void ActiveAllRule()
    {
        Rule_01.SetActive(true);
        Rule_02.SetActive(true);
        Rule_03.SetActive(true);
        Rule_04.SetActive(true);
        Rule_05.SetActive(true);
        Rule_06.SetActive(true);
        Rule_07.SetActive(true);
    }
    void ChangeRule()
    {
        Error_text.text = "";
        DroneIsFly = false;
        Ground.GetComponent<Wrong_Ground>().IsFail = false;
        Touching = false;
        IsClosed = false;
        CloseAllRule();
        switch(NowRule)
        {
            case 1:
                Rule_01.SetActive(true);
                break;
            case 2:
                Rule_02.SetActive(true);
                break;
            case 3:
                Rule_03.SetActive(true);
                break;
            case 4:
                Rule_04.SetActive(true);
                break;
            case 5:
                Rule_05.SetActive(true);
                break;
            case 6:
                Rule_06.SetActive(true);
                break;
            case 7:
                Rule_07.SetActive(true);
                break;
            default:
                CloseAllRule();
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CountTime();
        if (Target)
        {
            UpdateTargetData();
        }
        SuccessLevelCheck(); FailCheck();
        if (NowLevel == 0)
        {
            Under2();
        }
        else if (NowLevel == 1)
        {
            Basic();
        }
        else if(NowLevel == 2)
        {
            HighOne();
        }
        else if (NowLevel == 3)
        {
            HighTwo();
        }
        else if (NowLevel == 4)
        {
            HighThree();
        }
        if (switchlevel == true)
        {
            count_time = 0;
            switchlevel = false;
            ChangeRule();
            Debug.Log("switchlevel == true");
        }
    }
}
