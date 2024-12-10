using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rule_2_4 : MonoBehaviour
{
    public Toggle rule;
    public Rule_Controll main_rule;
    public rule_2_4_1 Controller;
    public bool isCheck;
    public void initial()
    {
        main_rule = GetComponent<Rule_Controll>();
        main_rule.switch_bool = false;
        rule.isOn = false;
        isCheck = false;
        Controller.enabled = true;
        Controller.initial();
    }
    // Update is called once per frame
    void Update()
    {
        isCheck = Controller.ReturnWatched();
        Controller.enabled = true;
        if (isCheck)
        {
            endevent();
        }
    }
    public void endevent()
    {
        rule.isOn = true;
        Controller.SetWatched(false);
        Controller.enabled = false;
        main_rule.switch_bool = true;
        main_rule.Now_Rule = 8;
        gameObject.GetComponent<rule_2_4>().enabled = false;
    }
}
