using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class rotate : MonoBehaviour
{
    public bool direction;
    public fly fly;
    void FixedUpdate()
    {
        if (fly.FlyStatus!=0)
        {
            if(direction)
            {
                transform.Rotate(0, 50, 0);
            }
            else
            {
                transform.Rotate(0, -50, 0);
            }
        }
    }
}