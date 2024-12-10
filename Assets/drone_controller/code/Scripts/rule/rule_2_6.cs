using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rule_2_6 : MonoBehaviour
{
    public Toggle rule;
    public Rule_Controll main_rule;
    public rule_2_6_1 Active_System;
    public bool isCheck;
    public void initial()
    {
        main_rule = GetComponent<Rule_Controll>();
        main_rule.switch_bool = false;
        rule.isOn = false;
        isCheck = false;
        Active_System.enabled = true;
        Active_System.initial();
    }
    // Update is called once per frame
    void Update()
    {
        isCheck = Active_System.ReturnWatched();
        Active_System.enabled = true;
        if (isCheck)
        {
            endevent();
        }
    }
    public void endevent()
    {
        rule.isOn = true;
        Active_System.SetWatched(false);
        Active_System.enabled = false;
        main_rule.switch_bool = true;
        main_rule.Now_Rule = 10;
        gameObject.GetComponent<rule_2_6>().enabled = false;
    }
}
