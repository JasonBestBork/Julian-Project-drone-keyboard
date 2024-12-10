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
        _text.text = "��X�}�l�ˬd����";
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
                Debug.Log("���ۼաG�ص��~�[�L���l");
                Rule_1_1.enabled = true;
                Rule_1_1.initial();
                Hint_text.text = "���ۼաG�ص��~�[�L���l";
            }
            else if (Now_Rule == 2)
            {
                print("rule 2 ");
                Debug.Log("���F�G�T�{�w�T�˧���Υص��~�[�L���l");
                Rule_1_2.enabled = true;
                Rule_1_2.initial();
                Hint_text.text = "���F�G�T�{�w�T�˧���Υص��~�[�L���l";
            }
            else if (Now_Rule == 3)
            {
                Debug.Log("��V���ˬd");
                Rule_1_3.enabled = true;
                Rule_1_3.initial();
                Hint_text.text = "��V���ˬd" +
                    "(�����k�⭹���H�ॿ����)";
            }
            else if (Now_Rule == 4)
            {
                Rule_2_1.enabled = true;
                Rule_2_1.initial();
                Hint_text.text = "�q���Ϊo�c�G�ˬd�~�[�B�u�@�q���B�o�q�A�νT�{�w�T�˧���";
            }
            else if (Now_Rule == 5)
            {
                Rule_2_2.enabled = true;
                Rule_2_2.initial();
                Hint_text.text = "���u�G�~�[�T�{�w�T�˧���";
            }
            else if (Now_Rule == 6)
            {
                Rule_2_3.enabled = true;
                Rule_2_3.initial();
                Hint_text.text = "�����ιS��(�p�A��)�G�~�[�T�{�w�T�˧���";
            }
            else if (Now_Rule == 7)
            {
                Rule_2_4.enabled = true;
                Rule_2_4.initial();
                Hint_text.text = "���汱��G�~�[�T�{�w�T�˧���";
            }
            else if (Now_Rule == 8)
            {
                Rule_2_5.enabled = true;
                Rule_2_5.initial();
                Hint_text.text = "GPS�ҲաG�~�[�T�{�w�T�˧���";
            }
            else if (Now_Rule == 9)
            {
                Rule_2_6.enabled = true;
                Rule_2_6.initial();
                Hint_text.text = "�I���t�Ωιq�t���Y�G�~�[�T�{�w�T�˧���";
            }
            else if (Now_Rule == 10)
            {
                Rule_2_7.enabled = true;
                Rule_2_7.initial();
                Hint_text.text = "���t�ΰʺA�ˬd(�]�t����ޱ���)";
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
                    Hint_text.text = "�٦� " + UIdispearCountdown + " �����ˬd����";
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
