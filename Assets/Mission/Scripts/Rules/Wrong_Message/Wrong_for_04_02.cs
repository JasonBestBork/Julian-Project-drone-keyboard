using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrong_for_04_02 : MonoBehaviour
{
    public bool IsOut;
    public bool IsError;
    public void OnEnable()
    {
        IsOut = false;
    }
    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("Exit_Wrong_for_04_02");
        if (collision.gameObject.tag == "DroveCore")
        {
            IsOut = true;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Enter_Wrong_for_04_02");
        if (collision.gameObject.tag == "DroveCore")
        {
            IsOut = false;
        }
    }
}
