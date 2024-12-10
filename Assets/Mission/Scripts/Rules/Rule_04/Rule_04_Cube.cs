using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_04_Cube : Rule_P
{
    public Rule_04 Rule_04;
    public float StayTime;
    public bool NowInBox;
    public bool IsInBoxed;
    // Start is called before the first frame update
    void Start()
    {
        Rule_04 = GameObject.Find("04_8circle").GetComponent<Rule_04>();
    }
    public void OnEnable()
    {
        NowInBox = false;
        IsInBoxed = false;
        StayTime = 0;
        print("Rule_04_Cub_Initial");
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "DroveCore" && (Rule_04.NowState == 0 || Rule_04.NowState == 5 || Rule_04.NowState == 10))
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
        if (collision.gameObject.tag == "DroveCore" && (Rule_04.NowState == 0 || Rule_04.NowState == 5 || Rule_04.NowState == 10))
        {
            StayTime = 0;
            Debug.Log("Exit_test");
            NowInBox = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if ((Rule_04.NowState == 0 || Rule_04.NowState == 5 || Rule_04.NowState == 10))
        {
            Rule_04.NowInBox = this.NowInBox;
            DetectClosed();
        }
        if (IsInBoxed && NowInBox == false && (Rule_04.NowState == 0 || Rule_04.NowState == 5 || Rule_04.NowState == 10))
        {
            StayTime = 0;
            print("error04");
        }
        if (StayTime > 5 && Rule_04.NowState == 0)
        {
            Rule_04.SwitchBool = true;
            Rule_04.NowState = 1;
            print("From 04_Cube State 0 successed");
            this.OnEnable();
            Rule_04.Close_All_PPoint();
        }
        if (StayTime > 5 && Rule_04.NowState == 10)
        {
            Rule_04.SwitchBool = true;
            Rule_04.NowState = 11;
            print("From 04_Cube State 10 successed");
            this.OnEnable();
            Rule_04.Close_All_PPoint();
        }
    }
}