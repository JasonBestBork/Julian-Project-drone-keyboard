using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class rule_1_3_1 : MonoBehaviour//¶¶®É°w
{
    public Renderer R1;
    public Rule_Controll main_rule;
    public GameObject RightMode;
    public GameObject WropngMode;
    public bool now_mod;
    public float timer;
    // Start is called before the first frame update
    public void initial()
    {
        timer = 0;
        print("1_3_1 "+now_mod);
        R1 = gameObject.GetComponent<Renderer>();
    }
    public void Check()
    {
        print("now hit = " + R1.gameObject.name);
        timer += Time.deltaTime;
        print(gameObject.name + "'s timer = " + ((int)timer));
        if(OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            SwitchMod();
        }
    }
    private void FixedUpdate()
    {
        if (now_mod)
        {
            RightMode.SetActive(true);
            WropngMode.SetActive(false);
        }
        else
        {
            RightMode.SetActive(false);
            WropngMode.SetActive(true);
        }
    }
    public void SwitchMod()
    {
        if(now_mod==true)
            now_mod = false;
        else
            now_mod = true;
    }
}
