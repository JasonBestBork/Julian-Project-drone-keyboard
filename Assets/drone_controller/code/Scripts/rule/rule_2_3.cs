using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rule_2_3 : MonoBehaviour
{
    public Toggle rule;
    public Rule_Controll main_rule;
    public rule_2_3_1 Body;
    public bool isCheck;
    public void initial()
    {
        main_rule = GetComponent<Rule_Controll>();
        main_rule.switch_bool = false;
        rule.isOn = false;
        isCheck = false;
        Body.enabled = true;
        Body.initial();
    }
    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        isCheck = Body.ReturnWatched();
        Body.enabled = true;
        if (isCheck)
        {
            endevent();
        }
    }
    public void endevent()
    {
        rule.isOn = true;
        Body.SetWatched(false);
        Body.enabled = false;
        main_rule.switch_bool = true;
        main_rule.Now_Rule = 7;
        gameObject.GetComponent<rule_2_3>().enabled = false;
    }
}
