using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeControll : MonoBehaviour
{
    public Behaviour drove;
    //public Behaviour person;

    // Start is called before the first frame update
    public void initial()
    {
        //person.enabled = true;
        drove.enabled = false;
    }
    public void end()
    {
        //person.enabled = false;
        drove.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Q))
            PersonActiveSwitch();
        if (Input.GetKeyDown(KeyCode.E))
            DroveActiveSwitch();
        */
    }

    /*
    void PersonActiveSwitch()
    {
        if (person.enabled)
            person.enabled = false;
        else
            person.enabled = true;

    }
    */
    void DroveActiveSwitch()
    {
        if (drove.enabled)
            drove.enabled = false;
        else
            drove.enabled = true;

    }
}
