﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_06_Cube : Rule_P
{
    public Rule_06 Rule_06;
    public float StayTime;
    public bool NowInBox;
    public bool IsInBoxed;
    // Start is called before the first frame update
    void Start()
    {
        Rule_06 = GameObject.Find("06_Mission_Fly").GetComponent<Rule_06>();
    }
    public void Initial()
    {
        NowInBox = false;
        IsInBoxed = false;
        StayTime = 0;
        print("Rule_06_Cube_Initial");
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "DroveCore" && (Rule_06.NowState == 0 || Rule_06.NowState == 5))
        {
            StayTime += Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision" + collision.name);
        Debug.Log("Enter_test");
        if (collision.gameObject.tag == "DroveCore")
        {
            Debug.Log("collision" + collision.name);
            Debug.Log("Enter_test_Success");
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
        if ((Rule_06.NowState == 0 || Rule_06.NowState == 5))
        {
            Rule_06.NowInBox = this.NowInBox;
            DetectClosed();
        }
        if (IsInBoxed && NowInBox == false && (Rule_06.NowState == 0 || Rule_06.NowState == 5))
        {
            StayTime = 0;
            print("error06");
        }
        if (StayTime > 5 && Rule_06.NowState == 0)
        {
            Rule_06.SwitchBool = true;
            Rule_06.NowState = 1;
            print("From 06_Cube State 0 successed");
            this.Initial();
            Rule_06.Close_All_PPoint();
        }
        if (StayTime > 5 && Rule_06.NowState == 5)
        {
            Rule_06.SwitchBool = true;
            Rule_06.NowState = 6;
            print("From 06_Cube State 5 successed");
            this.Initial();
            Rule_06.Close_All_PPoint();
        }
    }
}