﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_03_P7 : Rule_P
{
    public Rule_03 Rule_03;
    public float StayTime;
    public bool NowInBox;
    public bool IsInBoxed;
    // Start is called before the first frame update
    void Start()
    {
        Rule_03 = GameObject.Find("03_Rectangle").GetComponent<Rule_03>();
    }
    public void OnEnable()
    {
        NowInBox = false;
        IsInBoxed = false;
        StayTime = 0;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "DroveCore" && (Rule_03.NowState == 4 || Rule_03.NowState == 6))
        {
            StayTime += Time.deltaTime;
        }
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
    // Update is called once per frame
    void Update()
    {
        if ((Rule_03.NowState == 4 || Rule_03.NowState == 6))
        {
            Rule_03.NowInBox = this.NowInBox;
            DetectClosed();
        }
        if (IsInBoxed && NowInBox == false && (Rule_03.NowState == 4 || Rule_03.NowState == 6))
        {
            StayTime = 0;
            print("error03_P7");
        }
        if (StayTime > 5 && Rule_03.NowState == 4)
        {
            Rule_03.SwitchBool = true;
            Rule_03.NowState = 5;
            print("From 03_P7 State 4 successed");
            Rule_03.Close_All_PPoint();
        }
        if (StayTime > 5 && Rule_03.NowState == 6)
        {
            Rule_03.SwitchBool = true;
            Rule_03.NowState = 7;
            print("From 03_P7 State 6 successed");
            Rule_03.Close_All_PPoint();
        }
    }
}