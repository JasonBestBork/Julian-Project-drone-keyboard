﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_01_P3 : Rule_P
{
    public Rule_01 Rule_01;
    public double StayTime;
    public bool NowInBox;
    public bool IsInBoxed;
    // Start is called before the first frame update
    void Start()
    {
        Rule_01 = GameObject.Find("01_Altitude_Hole").GetComponent<Rule_01>();

        Debug.Log("Ready " + this.name);
    }
    public void Initial()
    {
        NowInBox = false;
        IsInBoxed = false;
        print("Rule_01_P3_Initial");
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
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "DroveCore" && (Rule_01.NowState == 3))
        {
            StayTime += Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "DroveCore")
        {
            Debug.Log("Exit_test");
            NowInBox = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Rule_01.NowState == 3)
        {
            Rule_01.NowInBox = this.NowInBox;
            DetectClosed();
        }
        if (IsInBoxed && NowInBox == false && (Rule_01.NowState == 3))
        {
            StayTime = 0;
            print("error01_P1");
        }

        if (StayTime > 5 && Rule_01.NowState == 3)
        {
            Rule_01.SwitchBool = true;
            Rule_01.NowState = 4;
            print("From 01_P3 State 3 successed");
            this.Initial();
            Rule_01.Close_All_PPoint();
        }
    }
}