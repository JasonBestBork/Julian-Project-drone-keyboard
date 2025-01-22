using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followplayer : MonoBehaviour
{

    public GameObject drone;
    public GameObject enemy;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        drone.transform.position = Vector3.MoveTowards(drone.transform.position, enemy.transform.position, speed);
    }
}
