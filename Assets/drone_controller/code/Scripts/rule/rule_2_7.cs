using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rule_2_7 : MonoBehaviour
{
    public Toggle R1_1, R1_2, R1_3;
    public Toggle R2_1, R2_2, R2_3, R2_4, R2_5, R2_6, R2_7;
    public Rule_Controll main_rule;
    // Start is called before the first frame update
    public void initial()
    {
        main_rule = GetComponent<Rule_Controll>();
        main_rule.switch_bool = false;
        R2_7.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (R1_1.isOn && R1_2.isOn && R1_3.isOn && R2_1.isOn && R2_2.isOn && R2_3.isOn && R2_4.isOn && R2_5.isOn && R2_6.isOn)
            endevent();
    }
    public void endevent()
    {
        R2_7.isOn = true;
        main_rule.switch_bool = true;
        main_rule.Now_Rule = 11;
        gameObject.GetComponent<rule_2_7>().enabled = false;
    }
}
