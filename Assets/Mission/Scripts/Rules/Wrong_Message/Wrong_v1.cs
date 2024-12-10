using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Wrong_v1 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsOut;
    public bool IsError;
    public const double OutTime = 10;
    public double OutTimeCountDown;
    public Text ErrorText;
    public void OnEnable()
    {
        ErrorText = GameObject.Find("Error_text").GetComponent<Text>();
        OutTimeCountDown = OutTime;
        IsOut = false;
        IsError = false;
    }
    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("Exit_Wrong_v1");
        if (collision.gameObject.tag == "DroveCore")
        {
            Debug.Log("1ErrorText.enabled = " + ErrorText.isActiveAndEnabled);
            IsOut = true;
            ErrorText.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision" + collision.name);
        Debug.Log("Enter_Wrong_v1");
        if (collision.gameObject.tag == "DroveCore")
        {
            Debug.Log("2ErrorText.enabled = " + ErrorText.isActiveAndEnabled);
            IsOut = false;
            ErrorText.enabled=false;
        }
    }
    void Update()
    {
        Debug.Log("3ErrorText.enabled = " + ErrorText.isActiveAndEnabled);
        if (IsOut&& IsError == false)
        {
            if(OutTimeCountDown>=0)
                OutTimeCountDown -= Time.deltaTime;
            else
                OutTimeCountDown = 0;
            ErrorText.text = "已離開考試範圍，請在" +(int)OutTimeCountDown+"秒內回歸";
        }
        else
        {
            if (IsError == false)
                OutTimeCountDown = OutTime;
            else 
                OutTimeCountDown = 0;
        }
        if (OutTimeCountDown == 0)
        {
            IsError = true;
            ErrorText.text = "超出考場範圍，請重新測驗。";
        }
    }
}
