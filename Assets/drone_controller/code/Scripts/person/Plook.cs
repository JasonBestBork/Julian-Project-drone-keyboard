using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plook : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public Transform orientation;

    float xRotation;
    float yRotation;

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //print("Input.GetKey(X) = " + Input.GetAxisRaw("Mouse X"));
        //print("Input.GetKey(Y) = " + Input.GetAxisRaw("Mouse Y"));
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        orientation.Rotate(Vector3.up*mouseX);

    }

}
