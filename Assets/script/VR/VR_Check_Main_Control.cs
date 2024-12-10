using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class VR_Check_Main_Control : MonoBehaviour
{
    public Rule_Controll rule_Controll;
    void Start()
    {
        rule_Controll.enabled = true;
        rule_Controll.Initialized();
    }
    public void End_all()
    {
        print("end_all");
        rule_Controll.isEnd = false;
        rule_Controll.enabled = false;
        if(Setting.End_Check == true)
        {
            SceneManager.LoadScene(0);//結束回選單
        }
        else
        {
            Setting.End_Check = true;
            SceneManager.LoadScene(3);//繼續測驗
        }
    }
    void Update()
    {
        if (rule_Controll.isEnd)
        {
            End_all();
        }
    }
}
