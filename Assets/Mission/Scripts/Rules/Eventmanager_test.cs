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
        if (OVRInput.GetUp(OVRInput.Button.Three))//�}�ҼȰ��e��
        {
            panel_pause.SetActive(true);
            panel_test.SetActive(false);
        }
        if (Setting.Stage == 0)
        {
            title.text = "00.�ˬd";
        }
        else if (Setting.Stage == 1)
        {
            title.text = "01.���׫O�����䭸��";
        }
        else if(Setting.Stage == 2)
        {
            title.text = "02.�w�I�_���Υ|�����a";
        }
        else if (Setting.Stage == 3)
        {
            title.text = "03.�x�ί�u";
        }
        else if (Setting.Stage == 4)
        {
            title.text = "04.�K�r������";
        }
        else if (Setting.Stage == 5)
        {
            title.text = "05.�����a���Ϋe�i��h";
        }
        else if (Setting.Stage == 6)
        {
            title.text = "06.���ȼҦ�����";
        }
        else if (Setting.Stage == 7)
        {
            title.text = "07.�����I����";
        }
        else if (Setting.Stage == 8)
        {
            title.text = "08.���{�ǳB�m";
        }
    }
    public void b1_click()//�~��
    {
        panel_pause.SetActive(false);
        panel_test.SetActive(true);
    }
    public void b2_click()//�h�X
    {
        SceneManager.LoadScene(0);
    }
    public void b3_click()//���s�}�l
    {
        SceneManager.LoadScene(2);
    }
    public void b4_click()//�U�@��
    {
        panel_settle.SetActive(false);
        panel_test.SetActive(true);
        manager.switchlevel = true;
    }
    public void settle(string str ,bool next = false)//�}�ҵ���e��
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

        if (next == true)//�ŧO���礤�����q�L
        {
            bottom_next.SetActive(true);//���s�אּ�e���U�@��
            bottom_restart.SetActive(false);
        }
        else
        {
            bottom_next.SetActive(false);
            bottom_restart.SetActive(true);
        }
    }
}
