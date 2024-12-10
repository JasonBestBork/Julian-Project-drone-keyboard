using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_07_Cube : Rule_P
{
    public Rule_07 Rule_07;
    public float StayTime;
    public bool NowInBox;
    public bool IsInBoxed;
    // Start is called before the first frame update
    void Start()
    {
        Rule_07 = GameObject.Find("07_Intresting_Point").GetComponent<Rule_07>();
    }
    public void Initial()
    {
        NowInBox = false;
        IsInBoxed = false;
        StayTime = 0;
        print("Rule_07_Cub_Initial");
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "DroveCore" && (Rule_07.NowState == 0 || Rule_07.NowState == 23))
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
        if (Rule_07.NowState == 0 || Rule_07.NowState == 23)
        {
            Rule_07.NowInBox = this.NowInBox;
            DetectClosed();
        }
        if (IsInBoxed && NowInBox == false && (Rule_07.NowState == 0 || Rule_07.NowState == 23 ))
        {
            StayTime = 0;
            print("error07");
        }
        if (StayTime > 5 && Rule_07.NowState == 0)
        {
            Rule_07.SwitchBool = true;
            Rule_07.NowState = 1;
            print("From 07_Cube State 0 successed");
            this.Initial();
            Rule_07.Close_All_PPoint();
        }
        if (StayTime > 5 && Rule_07.NowState == 23)
        {
            Rule_07.SwitchBool = true;
            Rule_07.NowState = 24;
            print("From 07_Cube State 23 successed");
            this.Initial();
            Rule_07.Close_All_PPoint();
        }
    }
}
