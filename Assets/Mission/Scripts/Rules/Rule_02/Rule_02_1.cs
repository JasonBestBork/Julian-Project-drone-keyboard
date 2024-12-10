using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Rule_02_1 : MonoBehaviour
{
    public Rule_02 Rule_02;
    public Text text;
    public Text Debug_text;
    public bool IsSccessed;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("mission_text").GetComponent<Text>();
        Debug_text = GameObject.Find("mission_debug_text").GetComponent<Text>();
        Rule_02 = GameObject.Find("02_FlyAndLand_Rotate").GetComponent<Rule_02>();
    }
    void OnEnable()
    {
        IsSccessed = false;
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision" + collision.name);
        if (collision.gameObject.tag == "DroveCore"&& Rule_02.NowState == 5)
        {
            //結束條件
            IsSccessed =true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
