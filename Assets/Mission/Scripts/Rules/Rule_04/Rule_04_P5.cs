using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_04_P5 : Rule_P
{
    public Rule_04 Rule_04;
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
        //print("Rule_04_P5_Initial");
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
            Debug.Log("Exit_test");
            NowInBox = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if ((Rule_04.NowState == 6))
        {
            Rule_04.NowInBox = this.NowInBox;
            DetectClosed();
        }
        if (IsInBoxed && (Rule_04.NowState == 6))
        {
            Rule_04.SwitchBool = true;
            Rule_04.NowState = 7;
            print("From 04_P5 State 6 successed");
            this.OnEnable();
            Rule_04.Close_All_PPoint();
        }
    }
}
