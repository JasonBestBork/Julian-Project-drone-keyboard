using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Rule_Controll : MonoBehaviour
{

    /*
    
    rule0~9
    ray
    
    */
    public int UIdispearCountdown;
    public float Countdown;
    public float check_time;
    public bool isStart;
    public bool isEnd;
    public RayScript ray;
    public int Now_Rule;
    public Text _text;
    public Text Hint_text;
    public bool switch_bool; 
    public rule_1_1 Rule_1_1;
    public rule_1_2 Rule_1_2;
    public rule_1_3 Rule_1_3;
    public rule_2_1 Rule_2_1;
    public rule_2_2 Rule_2_2;
    public rule_2_3 Rule_2_3;
    public rule_2_4 Rule_2_4;
    public rule_2_5 Rule_2_5;
    public rule_2_6 Rule_2_6;
    public rule_2_7 Rule_2_7;
    public void Initialized()
    {
        print("check restart");
        Countdown = 0;
        Now_Rule = 0;
        isStart = false;
        isEnd = false;
        ray.enabled = false;
        _text.text = "按X開始檢查測試";
        Hint_text.text = "";switch_bool = false;
        Rule_1_1.enabled = false; Rule_1_2.enabled = false;Rule_1_3.enabled = false;
        Rule_2_1.enabled = false; Rule_2_2.enabled = false; Rule_2_3.enabled = false; Rule_2_4.enabled = false;
        Rule_1_1.initial();
        Rule_1_2.initial();
        Rule_1_3.initial();
        Rule_2_1.initial();
        Rule_2_2.initial();
        Rule_2_3.initial();
        Rule_2_4.initial();
        Rule_2_5.initial();
        Rule_2_6.initial();
        Rule_2_7.initial();
    }


    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.Three))
        {
            isStart = true;
            _text.text = "";
            switch_bool = true;
            if(Now_Rule==0)
            {
                Now_Rule++;
            }
        }
        if (isStart&&switch_bool)
        {
            ray.enabled = true;
            if (Now_Rule == 1)
            {
                Debug.Log("螺旋槳：目視外觀無裂損");
                Rule_1_1.enabled = true;
                Rule_1_1.initial();
                Hint_text.text = "螺旋槳：目視外觀無裂損";
            }
            else if (Now_Rule == 2)
            {
                print("rule 2 ");
                Debug.Log("馬達：確認已固裝妥當及目視外觀無裂損");
                Rule_1_2.enabled = true;
                Rule_1_2.initial();
                Hint_text.text = "馬達：確認已固裝妥當及目視外觀無裂損";
            }
            else if (Now_Rule == 3)
            {
                Debug.Log("方向性檢查");
                Rule_1_3.enabled = true;
                Rule_1_3.initial();
                Hint_text.text = "方向性檢查" +
                    "(輕按右手食指以轉正葉片)";
            }
            else if (Now_Rule == 4)
            {
                Rule_2_1.enabled = true;
                Rule_2_1.initial();
                Hint_text.text = "電池或油箱：檢查外觀、工作電壓、油量，及確認已固裝妥當";
            }
            else if (Now_Rule == 5)
            {
                Rule_2_2.enabled = true;
                Rule_2_2.initial();
                Hint_text.text = "機臂：外觀確認已固裝妥當";
            }
            else if (Now_Rule == 6)
            {
                Rule_2_3.enabled = true;
                Rule_2_3.initial();
                Hint_text.text = "機身及酬載(如適用)：外觀確認已固裝妥當";
            }
            else if (Now_Rule == 7)
            {
                Rule_2_4.enabled = true;
                Rule_2_4.initial();
                Hint_text.text = "飛行控制器：外觀確認已固裝妥當";
            }
            else if (Now_Rule == 8)
            {
                Rule_2_5.enabled = true;
                Rule_2_5.initial();
                Hint_text.text = "GPS模組：外觀確認已固裝妥當";
            }
            else if (Now_Rule == 9)
            {
                Rule_2_6.enabled = true;
                Rule_2_6.initial();
                Hint_text.text = "點火系統或電系接頭：外觀確認已固裝妥當";
            }
            else if (Now_Rule == 10)
            {
                Rule_2_7.enabled = true;
                Rule_2_7.initial();
                Hint_text.text = "全系統動態檢查(包含手持操控器)";
            }
            else if(Now_Rule==11)
            {
                Hint_text.text = "END check";
                Countdown += Time.deltaTime;
                if (Countdown > UIdispearCountdown)
                {
                    endevent();
                }
                else
                {
                    Hint_text.text = "還有 " + UIdispearCountdown + " 秒結束檢查測試";
                }
            }

        }
    }
    public void endevent()
    {
        isEnd = true;
        GetComponent<Rule_Controll>().enabled = false;
    }
}
