using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Rule_02 : Rule
{
    public Rule_02_1 Sub;
    public Rule_02_Cube Cube;

    private int DroveAnglesY;
    private float TargetAngleMin;
    private float TargetAngleMax;
    // Start is called before the first frame update
    private void Start()
    {
        text = GameObject.Find("mission_text").GetComponent<Text>();
        drove = GameObject.FindWithTag("Drove");
        Debug_text = GameObject.Find("mission_debug_text").GetComponent<Text>();
        Cube = GameObject.Find("02_Cube").GetComponent<Rule_02_Cube>();
        manager = GameObject.Find("rule_manager").GetComponent<manager>();
    }

    void OnEnable()
    {
        manager.Initial_Position_And_Rotation();
        IsSccessed = false;
        IsStart = true;
        NowState = 0;
        IsInBoxed = false;
        NowInBox = false;
        StayTime = 0;
        Successed=false; TargetObject = null;
        text.text = "機頭朝外，自起降點H起飛至高度約1~2公尺，穩定高度，定點懸停" + StayTimeCountDown + "秒（含）以上。";
    }

    private void End()
    {
        text.text = "Rule02 success !";
        Debug.Log("Rule02 success !");
        IsSccessed = true; TargetObject = null;
        GameObject.Find("rule_manager").GetComponent<manager>().Rule_02_IsSccessed = IsSccessed;
    }
    private void LandingDetect()
    {
        Debug_text.text = "LandingDetect();";
    }
    private void RotateDetect()
    {
        if(NowState<4 && NowState > 0 )
        {
            TargetAngleMax = 10 + NowState * 90.0f;
            TargetAngleMin = -10 + NowState * 90.0f;
        }
        if(NowState == 4 || NowState == 0)
        {
            TargetAngleMax = 10;
            TargetAngleMin = 350;
        }
        
        DroveAnglesY = (int)drove.transform.eulerAngles.y;
        Debug_text.text = "目標角度:" + TargetAngleMin + "~" + TargetAngleMax + "\n目前角度:" + DroveAnglesY;

        if ((DroveAnglesY <= TargetAngleMax && DroveAnglesY >= TargetAngleMin)
            ||
            (
            (NowState == 4 || NowState == 0) &&
            (DroveAnglesY >= TargetAngleMin || DroveAnglesY <= TargetAngleMax)
            )
            )
        {
            //Debug.Log("staytime =" + StayTime);
            StayTime += Time.deltaTime;
            if(NowState ==0)
            {
                text.text = "機頭朝外自起降點H起飛至高度約1~2公尺穩定高度，定點懸停" + StayTimeCountDown + "秒（含）以上。\n" +
                    "目前滯留時間 = " + (int)StayTime;
            }
            else
            {
                text.text = "機頭依順時針方向旋轉，定點側面懸停5秒（含）以上。";
                switch (NowState)
                {
                    case 1:
                        text.text += "(機頭朝右)\n" +
                        "目前滯留時間 = " + (int)StayTime;
                        break;
                    case 2:
                        text.text += "(機頭朝內)\n" +
                        "目前滯留時間 = " + (int)StayTime;
                        break;
                    case 3:
                        text.text += "(機頭朝左)\n" +
                        "目前滯留時間 = " + (int)StayTime;
                        break;
                    case 4:
                        text.text += "(機頭朝外)\n" +
                        "目前滯留時間 = " + (int)StayTime;
                        break;
                    case 5:
                        text.text = "機頭朝外，降落至起降點H，起落架不得超過標示範圍。 ";
                        LandingDetect();
                        break;
                }
            }

            if (StayTime >= StayTimeCountDown)
            {
                StayTime = 0;
                NowState++;
                text.text = "機頭依順時針方向旋轉，定點側面懸停5秒（含）以上。";
                switch (NowState)
                {
                    case 1:
                        text.text += "(機頭朝右)\n" +
                        "目前滯留時間 = " + (int)StayTime;
                        break;
                    case 2:
                        text.text += "(機頭朝內)\n" +
                        "目前滯留時間 = " + (int)StayTime;
                        break;
                    case 3:
                        text.text += "(機頭朝左)\n" +
                        "目前滯留時間 = " + (int)StayTime;
                        break;
                    case 4:
                        text.text += "(機頭朝外)\n" +
                        "目前滯留時間 = " + (int)StayTime;
                        break;
                    case 5:
                        text.text = "機頭朝外，降落至起降點H，起落架不得超過標示範圍。 ";
                        LandingDetect();
                        break;
                }
            }
        }
        else
        {
            StayTime = 0;
            switch (NowState)
            {
                case 0:
                    text.text = "機頭朝外，自起降點H起飛至高度約1~2公尺，穩定高度，定點懸停" + StayTimeCountDown + "秒（含）以上。\n" +
                    "目前滯留時間 = " + (int)StayTime;
                    break;
                case 1:
                    text.text = "機頭依順時針方向旋轉，定點側面懸停5秒（含）以上。(機頭朝右)\n" +
                    "目前滯留時間 = " + (int)StayTime;
                    break;
                case 2:
                    text.text = "機頭依順時針方向旋轉，定點側面懸停5秒（含）以上。(機頭朝內)\n" +
                    "目前滯留時間 = " + (int)StayTime;
                    break;
                case 3:
                    text.text = "機頭依順時針方向旋轉，定點側面懸停5秒（含）以上。(機頭朝左)\n" +
                    "目前滯留時間 = " + (int)StayTime;
                    break;
                case 4:
                    text.text = "機頭依順時針方向旋轉，定點側面懸停5秒（含）以上。(機頭朝外)\n" +
                    "目前滯留時間 = " + (int)StayTime;
                    break;
                case 5:
                    break;
            }
        }
    }
    // Update is called once per frame

    void Update()
    {
        Error_Check();
        if (NowState < 5 && NowState > -1&&Cube.IsStay)
        {
            RotateDetect();
        }
        else 
        {
            text.text = "機頭朝外，自起降點H起飛至高度約1~2公尺，穩定高度，定點懸停" + StayTimeCountDown + "秒（含）以上。";
        }
        if(Cube.IsInBoxed && Cube.IsStay == false && NowState <5)
        {
            StayTime = 0;
            //print("error02");
        }
        if(Sub.IsSccessed)
        {
            End();
        }
    }
}
