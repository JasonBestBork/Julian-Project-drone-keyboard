using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_01_Cube : Rule_P
{
    public Rule_01 Rule_01;
    public float StayTime;
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
        StayTime = 0;
        print("Rule_01_Cub_Initial");
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "DroveCore" && (Rule_01.NowState == 0 || Rule_01.NowState == 5))
        {
            StayTime += Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("collision" + collision.name);
        //Debug.Log("Enter_test");
        if (collision.gameObject.tag == "DroveCore")
        {
            //Debug.Log("collision" + collision.name);
            //Debug.Log("Enter_test_Success");
            IsInBoxed = true;
            NowInBox = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "DroveCore")
        {
            StayTime = 0;
            //Debug.Log("Exit_test");
            NowInBox = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Rule_01.NowState == 0 || Rule_01.NowState == 5)
        {
            Rule_01.NowInBox = this.NowInBox;
            DetectClosed();
        }
        if (IsInBoxed && NowInBox == false && (Rule_01.NowState == 0 || Rule_01.NowState == 5 ))
        {
            StayTime = 0;
            print("error04");
        }
        if (StayTime > 5 && Rule_01.NowState == 0)
        {
            Rule_01.SwitchBool = true;
            Rule_01.NowState = 1;
            print("From 01_Cube State 0 successed");
            this.Initial();
            Rule_01.Close_All_PPoint();
        }
        if (StayTime > 5 && Rule_01.NowState == 5)
        {
            Rule_01.SwitchBool = true;
            Rule_01.NowState = 6;
            print("From 01_Cube State 5 successed");
            this.Initial();
            Rule_01.Close_All_PPoint();
        }
    }
}
