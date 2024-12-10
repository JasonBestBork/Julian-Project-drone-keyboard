using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rule_Record_Data : MonoBehaviour
{
    [HeaderAttribute("Record_Data")]
    public GameObject Drone;
    public GameObject Target;
    public float Target_Distance;
    public Vector3 Target_Position;
    public bool IsClosed;
    public bool Touching;
    public bool IsOut;
    public float Out_Countdown;
    public Text Distance_text;
    public float count_time;//小關時間
    public float total_count_time;//總時間

    public void ChangeTarget(GameObject T)
    {
        Target = T;
    }
    public void ChangeTouchData(bool C,bool T)
    {
        IsClosed = C;
        Touching = T;
    }
    public void ChangeOut(bool O, float O_C)
    {
        IsOut = O;
        Out_Countdown = O_C;
    }
    public void UpdateTargetData()
    {
        if(Target)
        {
            Target_Position = Target.transform.position;
            Target_Distance = (Target_Position - Drone.transform.position).magnitude;
            Distance_text.text = "目標距離 : " + Target_Distance.ToString("0.00");
        }
        else
        {
            IsClosed = false;
            Touching = false;
            Target_Position = new Vector3(0f,0f,0f);
            Target_Distance = 0;
            Distance_text.text = "";
        }
    }
    
}
