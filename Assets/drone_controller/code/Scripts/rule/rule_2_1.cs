using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rule_2_1 : MonoBehaviour
{
    public Toggle rule;
    public Rule_Controll main_rule;
    public rule_2_1_1 Bettery;
    public bool isCheck;
    public void initial()
    {
        main_rule = GetComponent<Rule_Controll>();
        main_rule.switch_bool = false;
        rule.isOn = false;
        isCheck = false;
        Bettery.enabled = true;
        Bettery.initial();
    }
    // Update is called once per frame
    void Update()
    {
        isCheck = Bettery.ReturnWatched();
        Bettery.enabled = true;
        if (isCheck)
        {
            endevent();
        }
    }
    public void endevent()
    {
        rule.isOn = true;
        Bettery.SetWatched(false);
        Bettery.enabled = false;
        main_rule.switch_bool = true;
        main_rule.Now_Rule =5;
        gameObject.GetComponent<rule_2_1>().enabled = false;
    }
}
