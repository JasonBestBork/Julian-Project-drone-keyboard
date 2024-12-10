using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class VR_TMP_Control : MonoBehaviour
{
    public TextMeshProUGUI hight;
    public TextMeshProUGUI time;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI GPS;
    public TextMeshProUGUI scoreDisplay;
    public int min;
    public int sec;
    public int fra;
    private float count_time;
    public fly drone;
    public manager manager;
    public GameObject panel_test;
    private void Start()
    {
        count_time = 0;
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(panel_test.active)
        {
            if(manager)
            {
                count_time = manager.count_time;
            }
            min = (int)(count_time) / 60;
            sec = (int)(count_time % 60);
            fra = (int)(count_time * 100) % 100;
            time.text = min.ToString("D2") + ":" + sec.ToString("D2") + ":" + fra.ToString("D2");
            hight.text = drone.position.y.ToString("f1") + "m";
            speed.text = drone.speed.ToString("f2") + "m/s";
            scoreDisplay.text = "" + PlatformCollider.score;
            if (Setting.Attitude)
            {
                GPS.text = "(ATTI Mode)";
            }
            else
            {
                GPS.text = "(GPS Mode)";
            }
        }
    }
}
