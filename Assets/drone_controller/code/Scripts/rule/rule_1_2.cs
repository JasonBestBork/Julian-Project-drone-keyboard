using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rule_1_2 : MonoBehaviour
{
    public Toggle rule;
    public Rule_Controll main_rule;
    public rule_1_2_1 LF, LB, RF, RB;
    public bool isLFCheck, isLBCheck, isRFCheck, isRBCheck;
    public void initial()
    {

        main_rule = GetComponent<Rule_Controll>();
        main_rule.switch_bool = false;
        rule.isOn = false;
        isLFCheck = false;
        isLBCheck = false;
        isRFCheck = false;
        isRBCheck = false;
        LB.enabled = true;
        LF.enabled = true;
        RB.enabled = true;
        RF.enabled = true;
        LB.initial();
        LF.initial();
        RB.initial();
        RF.initial();
    }
    // Update is called once per frame
    void Update()
    {
        isLFCheck = LF.ReturnWatched();
        isRFCheck = RF.ReturnWatched();
        isRBCheck = RB.ReturnWatched();
        isLBCheck = LB.ReturnWatched();
        if (isLFCheck && isRFCheck && isRBCheck && isLBCheck)
        {
            endevent();
        }
    }
    public void endevent()
    {
        rule.isOn = true;
        LB.SetWatched(false);
        LF.SetWatched(false);
        RB.SetWatched(false);
        RF.SetWatched(false);
        LB.enabled = false;
        LF.enabled = false;
        RB.enabled = false;
        RF.enabled = false;
        main_rule.switch_bool = true;
        main_rule.Now_Rule = 3;
        gameObject.GetComponent<rule_1_2>().enabled = false;
    }
}
