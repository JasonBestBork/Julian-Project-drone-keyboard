using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_P : MonoBehaviour
{
    public const double Close_Dis = 3;
    public bool IsClosed;
    public double Dis;

    public void DetectClosed()
    {
        Dis= (GameObject.FindGameObjectWithTag("Drove").transform.position - this.transform.position).magnitude;
        //Debug.Log("this. = " + this.name);
        if (Dis< Close_Dis)
        {
            IsClosed =true;
        }
        else
        {
            IsClosed = false;
        }
    }
}
