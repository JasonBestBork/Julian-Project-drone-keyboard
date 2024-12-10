using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class rule_1_1_1 : MonoBehaviour
{
    public Renderer R1;
    public Rule_Controll main_rule;
    public bool isWatched;
    public float timer;
    // Start is called before the first frame update
    public void initial()
    {
        timer = 0; isWatched = false;
        R1 = gameObject.GetComponent<Renderer>();
    }
    public void Check()
    {
        print("now hit = " + R1.gameObject.name);
        timer += Time.deltaTime;
        print(gameObject.name + "'s timer = " + ((int)timer));
        if (timer >= main_rule.check_time)
        {
            SetWatched(true);
        }
    }
    public bool ReturnWatched()
    {
        return isWatched;
    }
    public void SetWatched(bool x)
    {
        isWatched = x;
    }
}
