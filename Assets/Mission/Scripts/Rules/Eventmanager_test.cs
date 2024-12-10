using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Eventmanager_test : MonoBehaviour
{
    public GameObject panel_pause;
    public GameObject panel_settle;
    public GameObject panel_test;
    public Text title;
    public TextMeshProUGUI time;
    public TextMeshProUGUI total_time;
    public TextMeshProUGUI success;

    public GameObject bottom_next;
    public GameObject bottom_restart;
    public GameObject Quad_TopView;
    public GameObject Quad_Droneiew;
    public manager manager;

    // Start is called before the first frame update
    void Start()
    {
        panel_pause.SetActive(false);
        panel_test.SetActive(true);
        panel_settle.SetActive(false);
        Quad_TopView.SetActive(Setting.SmallMap);
        Quad_Droneiew.SetActive(Setting.DroneCamera);
    }
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.Three))//開啟暫停畫面
        {
            panel_pause.SetActive(true);
            panel_test.SetActive(false);
        }
        if (Setting.Stage == 0)
        {
            title.text = "00.檢查";
        }
        else if (Setting.Stage == 1)
        {
            title.text = "01.高度保持五邊飛行";
        }
        else if(Setting.Stage == 2)
        {
            title.text = "02.定點起降及四面停懸";
        }
        else if (Setting.Stage == 3)
        {
            title.text = "03.矩形航線";
        }
        else if (Setting.Stage == 4)
        {
            title.text = "04.八字水平圓";
        }
        else if (Setting.Stage == 5)
        {
            title.text = "05.側面懸停及前進後退";
        }
        else if (Setting.Stage == 6)
        {
            title.text = "06.任務模式飛行";
        }
        else if (Setting.Stage == 7)
        {
            title.text = "07.興趣點飛行";
        }
        else if (Setting.Stage == 8)
        {
            title.text = "08.緊急程序處置";
        }
    }
    public void b1_click()//繼續
    {
        panel_pause.SetActive(false);
        panel_test.SetActive(true);
    }
    public void b2_click()//退出
    {
        SceneManager.LoadScene(0);
    }
    public void b3_click()//重新開始
    {
        SceneManager.LoadScene(2);
    }
    public void b4_click()//下一關
    {
        panel_settle.SetActive(false);
        panel_test.SetActive(true);
        manager.switchlevel = true;
    }
    public void settle(string str ,bool next = false)//開啟結算畫面
    {
        panel_settle.SetActive(true);
        panel_pause.SetActive(false);
        panel_test.SetActive(false);
        success.text = str;
        time.text = ((int)(manager.count_time/60)).ToString("D2") 
            + ":" + ((int)(manager.count_time % 60)).ToString("D2") 
            + ":" + ((int)(manager.count_time *100)%100).ToString("D2"); ;
        total_time.text = ((int)(manager.total_count_time / 60)).ToString("D2")
            + ":" + ((int)(manager.total_count_time % 60)).ToString("D2")
            + ":" + ((int)(manager.total_count_time * 100) % 100).ToString("D2"); ;

        if (next == true)//級別測驗中單關通過
        {
            bottom_next.SetActive(true);//按鈕改為前往下一關
            bottom_restart.SetActive(false);
        }
        else
        {
            bottom_next.SetActive(false);
            bottom_restart.SetActive(true);
        }
    }
}
