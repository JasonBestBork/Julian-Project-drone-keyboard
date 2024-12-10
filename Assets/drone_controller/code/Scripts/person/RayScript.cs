using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
using TMPro;
using System.Net.NetworkInformation;
using UnityEngine.UIElements;

public class RayScript : MonoBehaviour
{
    [Header("Ray")]
    public Ray ray;
    public float raylength = 1.5f;
    public RaycastHit hit;
    public Text Raytext;
    public rule_1_1_1 R1_1_1, R1_1_2, R1_1_3, R1_1_4;
    public rule_1_2_1 R1_2_1, R1_2_2, R1_2_3, R1_2_4;
    public rule_2_1_1 R2_1_1;
    public rule_2_2_1 R2_2_1, R2_2_2, R2_2_3, R2_2_4;
    public rule_2_3_1 R2_3_1;
    public rule_2_4_1 R2_4_1;
    public GameObject RightHandAnchor;
    public GameObject direct;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast ( RightHandAnchor.transform.position, Vector3.Normalize(direct.transform.position - RightHandAnchor.transform.position ) , out hit, raylength))
        {
            if (hit.transform.tag == "Player")
            {
                hit.transform.SendMessage("Catch", gameObject, SendMessageOptions.DontRequireReceiver);
                print("now hit hit.transform.gameObject.name = " + hit.transform.gameObject.name);
            }
            if (hit.collider.transform.tag == "CheckTag")
            {
                Raytext.text = hit.collider.gameObject.name;
                hit.collider.transform.SendMessage("Check", gameObject, SendMessageOptions.DontRequireReceiver);
            }
            else if(hit.collider.transform.tag != "CheckTag")
            {
                Raytext.text = " ";
                R1_1_1.timer = 0;
                R1_1_2.timer = 0;
                R1_1_3.timer = 0;
                R1_1_4.timer = 0;
                R1_2_1.timer = 0;
                R1_2_2.timer = 0;
                R1_2_3.timer = 0;
                R1_2_4.timer = 0;
                R2_1_1.timer = 0;
                R2_2_1.timer = 0;
                R2_2_2.timer = 0;
                R2_2_3.timer = 0;
                R2_2_4.timer = 0;
                R2_3_1.timer = 0;
                R2_4_1.timer = 0;
            }


            Debug.DrawLine(ray.origin, hit.point, Color.yellow);
            print("hit = " + hit.collider.transform.name);                 
        }
        else
        {
            Raytext.text = " ";
            R1_1_1.timer = 0;
            R1_1_2.timer = 0;
            R1_1_3.timer = 0;
            R1_1_4.timer = 0;
            R1_2_1.timer = 0;
            R1_2_2.timer = 0;
            R1_2_3.timer = 0;
            R1_2_4.timer = 0;
            R2_1_1.timer = 0;
            R2_2_1.timer = 0;
            R2_2_2.timer = 0;
            R2_2_3.timer = 0;
            R2_2_4.timer = 0;
            R2_3_1.timer = 0;
            R2_4_1.timer = 0;
        }
    }
}
