using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_05_P7 : Rule_P
{
    public Rule_05 Rule_05;
    public double StayTime;
    public bool NowInBox;
    public bool IsInBoxed;
    // Start is called before the first frame update
    void Start()
    {
        Rule_05 = GameObject.Find("05_Goahead_And_Goback").GetComponent<Rule_05>();

        Debug.Log("Ready " + this.name);
    }
    public void Initial()
    {
        NowInBox = false;
        IsInBoxed = false;
        StayTime = 0;
        print("Rule_05_P3_Initial");
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
        if (collision.gameObject.tag == "DroveCore" && (Rule_05.NowState == 2 || Rule_05.NowState == 5))
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
        if ((Rule_05.NowState == 2 || Rule_05.NowState == 5))
        {
            Rule_05.NowInBox = this.NowInBox;
            DetectClosed();
        }
        if (IsInBoxed && NowInBox == false && (Rule_05.NowState == 2|| Rule_05.NowState == 5))
        {
            StayTime = 0;
            print("error05_P1");
        }

        if (StayTime > 5 && Rule_05.NowState == 2)
        {
            Rule_05.SwitchBool = true;
            Rule_05.NowState = 3;
            print("From 05_P3 State 2 successed");
            this.Initial();
            Rule_05.Close_All_PPoint();
        }
        if (StayTime > 5 && Rule_05.NowState == 5)
        {
            Rule_05.SwitchBool = true;
            Rule_05.NowState = 6;
            print("From 05_P3 State 5 successed");
            this.Initial();
            Rule_05.Close_All_PPoint();
        }
    }
}
