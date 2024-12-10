using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rule : MonoBehaviour
{
    public Wrong_v1 Boundary;

    public manager manager;
    public bool IsSccessed;
    public bool IsStart;
    public bool NowInBox;
    public bool IsInBoxed;
    public bool Successed;
    public int NowState;
    public bool SwitchBool;

    public bool IsClosed;
    public bool IsOut;
    public float Out_Countdown;

    public int ExitCountDown;
    public int StayTimeCountDown;
    public float StayTime;
    public Text text;
    public Text Debug_text;
    public GameObject drove;
    public GameObject TargetObject;
    public void Error_Check()
    {
        IsOut = Boundary.IsOut;
        Out_Countdown = (float)Boundary.OutTimeCountDown;
        if (Boundary.IsError)
        {
            Debug_text.text = "Error.Please retry the level. ";
            Console.WriteLine("Boundary error from " + this.name);
        }
        manager.ChangeOut(IsOut, Out_Countdown);
    }


    public void CallChangeTarget()
    {
        manager.ChangeTarget(TargetObject);
    }
}
