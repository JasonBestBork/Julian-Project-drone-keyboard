using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Rule_02_Cube : MonoBehaviour
{
    public bool IsStay;
    public bool IsInBoxed;
    public void OnEnable()
    {
        IsStay = false;
        IsInBoxed = false;
    }
    // Start is called before the first frame update
    private void OnTriggerStay(Collider collision)
    {
        Debug.Log("Stay collision" + collision.name);
        if (collision.gameObject.tag == "DroveCore")
        {
            IsStay = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("Exit collision" + collision.name);
        if (collision.gameObject.tag == "DroveCore")
        {
            IsStay = false;
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Enter collision" + collision.name);
        if (collision.gameObject.tag == "DroveCore")
        {
            IsStay = true;
            IsInBoxed = true;
        }
    }
}
