using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Camera_TopView;
    public GameObject Camera_Drone;
    public GameObject drone;
    void FixedUpdate()
    {
        Camera_TopView.transform.position = drone.transform.position + new Vector3(0,10,0);
        //Camera_Drone.transform.position = drone.transform.position + new Vector3(0, 0.05f, 0.2f);
        //Camera_Drone.transform.rotation = drone.transform.rotation;
    }
}
