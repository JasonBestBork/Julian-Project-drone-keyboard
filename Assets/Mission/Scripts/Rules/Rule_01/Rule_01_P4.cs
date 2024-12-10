using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_01_P4 : Rule_P
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
        print("Rule_01_P4_Initial");
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
            Debug.Log("Exit_test");
            NowInBox = false;
        }

    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "DroveCore" && (Rule_01.NowState == 4))
        {
            StayTime += Time.deltaTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Rule_01.NowState == 4)
        {
            Rule_01.NowInBox = this.NowInBox;
            DetectClosed();
        }
        if (IsInBoxed && NowInBox == false && (Rule_01.NowState == 4))
        {
            StayTime = 0;
            print("error01_P1");
        }

        if (StayTime > 5 && Rule_01.NowState == 4)
        {
            Rule_01.SwitchBool = true;
            Rule_01.NowState = 5;
            print("From 01_P4 State 4 successed");
            this.Initial();
            Rule_01.Close_All_PPoint();
        }
    }
}
