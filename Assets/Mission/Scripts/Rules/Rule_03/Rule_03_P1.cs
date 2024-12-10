using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_03_P1 : Rule_P
{
    public Rule_03 Rule_03;
    public float StayTime;
    public bool NowInBox;
    public bool IsInBoxed;
    // Start is called before the first frame update
    void Start()
    {
        Rule_03 = GameObject.Find("03_Rectangle").GetComponent<Rule_03>();
        Debug.Log("Ready " + this.name);
    }
    public void OnEnable()
    {
        NowInBox = false;
        IsInBoxed = false;
        StayTime = 0;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "DroveCore" && (Rule_03.NowState == 2 || Rule_03.NowState == 8))
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
        if (collision.gameObject.tag == "DroveCore" )
        {
            StayTime = 0;
            Debug.Log("Exit_test");
            NowInBox = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if ((Rule_03.NowState == 2 || Rule_03.NowState == 8))
        {
            Rule_03.NowInBox = this.NowInBox;
            DetectClosed();
        }
        if (IsInBoxed && NowInBox == false && (Rule_03.NowState == 2||Rule_03.NowState == 8))
        {
            StayTime = 0;
            print("error03_P1");
        }

        if (StayTime > 5 && Rule_03.NowState == 2)
        {
            Rule_03.SwitchBool = true;
            Rule_03.NowState = 3;
            print("From 03_P1 State 2 successed");
            Rule_03.Close_All_PPoint();
        }
        if (StayTime > 5 && Rule_03.NowState == 8)
        {
            Rule_03.SwitchBool = true;
            Rule_03.NowState = 9;
            print("From 03_P1 State 8 successed");
            Rule_03.Close_All_PPoint();
        }
    }
}
