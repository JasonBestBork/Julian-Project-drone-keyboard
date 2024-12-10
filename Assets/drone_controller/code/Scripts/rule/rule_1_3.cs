using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
//using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

public class rule_1_3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle R1, R2, R3;
    public Rule_Controll main_rule;
    public rule_1_3_1 LF,RF,LB,RB;
    int test_int=0;
    public void initial()
    {
        main_rule.switch_bool = false;
        LF.initial();
        RF.initial();
        RB.initial();
        LB.initial(); 
        SetMod();
        R3.isOn = false;
        //print("rule_1_3  test_int = " + test_int);
    }
    public void SetMod()
    {
        int tmp = Random.Range(0, 4);
        //print("mod tmp = "+tmp);
        switch (tmp)
        {
            case 0:
                LF.now_mod = false;
                RF.now_mod = false;
                LB.now_mod = true;
                RB.now_mod = true;
                break;
            case 1:
                LF.now_mod = true;
                RF.now_mod = false;
                LB.now_mod = false;
                RB.now_mod = true;
                break;
            case 2:
                LF.now_mod = true;
                RF.now_mod = true;
                LB.now_mod = false;
                RB.now_mod = false;
                break;
            case 3:
                LF.now_mod = true;
                RF.now_mod = false;
                LB.now_mod = false;
                RB.now_mod = true;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (LF.now_mod&& RB.now_mod && RF.now_mod && LB.now_mod)
            endevent();
    }
    public void endevent()
    {
        R3.isOn = true;
        main_rule.switch_bool = true;
        main_rule.Now_Rule = 4;
        gameObject.GetComponent<rule_1_3>().enabled = false;
    }
}
