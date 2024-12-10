using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_07_P6 : Rule_P
{
    public Rule_07 Rule_07;
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
        print("Rule_07_P6_Initial");
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
    // Update is called once per frame
    void Update()
    {
        if (Rule_07.NowState == 14 || Rule_07.NowState == 20 )
        {
            Rule_07.NowInBox = this.NowInBox;
            DetectClosed();
        }
        if (IsInBoxed && (Rule_07.NowState == 14))
        {
            Rule_07.SwitchBool = true;
            Rule_07.NowState = 15;
            print("From 07_P6 State 14 successed");
            this.Initial();
            Rule_07.Close_All_PPoint();
        }
        if (IsInBoxed && (Rule_07.NowState == 20))
        {
            Rule_07.SwitchBool = true;
            Rule_07.NowState = 21;
            print("From 07_P6 State 20 successed");
            this.Initial();
            Rule_07.Close_All_PPoint();
        }
    }
}
