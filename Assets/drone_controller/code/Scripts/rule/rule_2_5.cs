using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class rule_2_5 : MonoBehaviour
{
    public Toggle rule;
    public Rule_Controll main_rule;
    public rule_2_5_1 GPS;
    public bool isCheck;
    public void initial()
    {
        main_rule = GetComponent<Rule_Controll>();
        main_rule.switch_bool = false;
        rule.isOn = false;
        isCheck = false;
        GPS.enabled = true;
        GPS.initial();
    }
    // Update is called once per frame
    void Update()
    {
        isCheck = GPS.ReturnWatched();
        GPS.enabled = true;
        if (isCheck)
        {
            endevent();
        }
    }
    public void endevent()
    {
        rule.isOn = true;
        GPS.SetWatched(false);
        GPS.enabled = false;
        main_rule.switch_bool = true;
        main_rule.Now_Rule = 9;
        gameObject.GetComponent<rule_2_5>().enabled = false;
    }
}
