using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmp_move : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject drove;
    public float speed = 0.1f;
    public float RotateSpeed = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            drove.transform.Translate(-1f * speed, 0f, 0f);
        }
        if (Input.GetKey("d"))
        {
            drove.transform.Translate(1f * speed, 0f, 0f);
        }
        if (Input.GetKey("w"))
        {
            drove.transform.Translate(0f, 0f, 1f * speed);
        }
        if (Input.GetKey("s"))
        {
            drove.transform.Translate(0f, 0f, -1f * speed);
        }

        if (Input.GetKey("j"))
        {
            drove.transform.Rotate(0f, -1f * RotateSpeed, 0f);
        }
        if (Input.GetKey("k"))
        {
            drove.transform.Translate(0f, -1f * speed, 0f);
        }
        if (Input.GetKey("l"))
        {
            drove.transform.Rotate(0f,1f * RotateSpeed, 0f);
        }
        if (Input.GetKey("i"))
        {
            drove.transform.Translate(0f, 1f * speed, 0f);
        }
    }
}
