using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrong_Ground : MonoBehaviour
{
    public bool IsFail;
    public bool IsFall;
    public manager manager;

    private void Start()
    {
        manager = GameObject.Find("rule_manager").GetComponent<manager>();
    }
    public void OnEnable()
    {
        IsFall = false;
        IsFail = false;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Drove")
        {
            IsFall = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Drove")
        {
            IsFall = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFall&& manager.DroneIsFly)
        {
            IsFail = true;
        }
        
    }
}
