using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;
public class Rule_05_Cube : Rule_P
{
    public Rule_05 Rule_05;
    public float StayTime;
    public bool NowInBox;
    public bool IsInBoxed;

    public Text Debug_text;
    public int NowState;
    public GameObject drove;
    private float DroveAnglesY;
    private float TargetAngleMin;
    private float TargetAngleMax;
    // Start is called before the first frame update
    void Start()
    {
        drove = GameObject.FindWithTag("Drove");
        Rule_05 = GameObject.Find("05_Goahead_And_Goback").GetComponent<Rule_05>();
        Debug_text = GameObject.Find("mission_debug_text").GetComponent<Text>();
    }
    public void Initial()
    {
        NowInBox = false;
        IsInBoxed = false;
        print("Rule_05.NowState  = "+ Rule_05.NowState);

        if (Rule_05.NowState == 0)
            NowState = 3;
        if (Rule_05.NowState == 4)
            NowState = 1;
        StayTime = 0;
        print("Rule_05_Cub_Initial");
    }
    private void RotateDetect()
    {
        if (NowState == 1 || NowState == 3)
        {
            TargetAngleMax = 10 + NowState * 90.0f;
            TargetAngleMin = -10 + NowState * 90.0f;
        }

        DroveAnglesY = drove.transform.eulerAngles.y;
        Debug_text.text = "目標角度:" + TargetAngleMin + "~" + TargetAngleMax + "\n目前角度:" + DroveAnglesY;

        if (DroveAnglesY <= TargetAngleMax && DroveAnglesY >= TargetAngleMin)
        {
            //Debug.Log("staytime =" + StayTime);
            StayTime += Time.deltaTime;
            if (StayTime >= 5)
            {
                if(NowState==3&& Rule_05.NowState == 0)
                {
                    Rule_05.SwitchBool = true;
                    Rule_05.NowState = 1;
                    print("From 05_Cube State 0 successed");
                    this.Initial();
                }
                else if(NowState == 1&& Rule_05.NowState == 4)
                {
                    Rule_05.SwitchBool = true;
                    Rule_05.NowState = 5;
                    print("From 05_Cube State 4 successed");
                    this.Initial();
                }
                StayTime = 0;
            }
        }
        else
        {
            StayTime = 0;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "DroveCore" && (Rule_05.NowState == 3 || Rule_05.NowState == 7))
        {
            StayTime += Time.deltaTime;
        }
        if (collision.gameObject.tag == "DroveCore" && (Rule_05.NowState == 0 || Rule_05.NowState == 4))
        {
            RotateDetect();
        }
        if (collision.gameObject.tag == "DroveCore")
            NowInBox =true;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "DroveCore")
        {
            Debug.Log("collision" + collision.name);
            Debug.Log("Enter_test");
            IsInBoxed = true;
            NowInBox = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "DroveCore")
        {
            StayTime = 0;
            Debug.Log("Exit_test");
            NowInBox = false;
        }
    }
    void Update()
    {
        if ((Rule_05.NowState == 0 || Rule_05.NowState == 3 || Rule_05.NowState == 4 || Rule_05.NowState == 7))
        {
            Rule_05.NowInBox = this.NowInBox;
            DetectClosed();
        }
        if (IsInBoxed && NowInBox == false && (Rule_05.NowState == 0 || Rule_05.NowState == 3 || Rule_05.NowState == 4 || Rule_05.NowState == 7))
        {
            StayTime = 0;
            print("error05_Cube");
        }
        if (StayTime > 5 && Rule_05.NowState == 3)
        {
            Rule_05.SwitchBool = true;
            Rule_05.NowState = 4;
            print("From 05_Cube State 3 successed");
            this.Initial();
            Rule_05.Close_All_PPoint();
        }
        if (StayTime > 5 && Rule_05.NowState == 7)
        {
            Rule_05.SwitchBool = true;
            Rule_05.NowState = 8;
            print("From 05_Cube State 7 successed");
            this.Initial(); 
            Rule_05.Close_All_PPoint();
        }
    }
}
