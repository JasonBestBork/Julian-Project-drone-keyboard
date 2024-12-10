using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wrong_for_04_01 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsError;
    public bool IsOut;
    public Wrong_for_04_02 P1;
    public Wrong_for_04_02 P2;
    public const double OutTime = 10;
    public double OutTimeCountDown;
    public Text ErrorText;
    public void OnEnable()
    {
        OutTimeCountDown = OutTime;
        IsError = false;
    }
    void Update()
    {
        if (P1.IsOut && P2.IsOut)
            IsOut = true;
        else
            IsOut = false;
        if (IsOut && IsError == false)
        {
            if (OutTimeCountDown >= 0)
                OutTimeCountDown -= Time.deltaTime;
            else
                OutTimeCountDown = 0;
            ErrorText.enabled = true;
            ErrorText.text = "你已離開考試範圍，請在"+ (int)OutTimeCountDown+"秒內回歸。";
        }
        else
        {
            ErrorText.enabled = false;
            ErrorText.text = "";
            if (IsError == false)
                OutTimeCountDown = OutTime;
            else
                OutTimeCountDown = 0;
        }
        if (OutTimeCountDown == 0)
        {
            IsError = true;
        }
    }
}
