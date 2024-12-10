using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Eventmanager_free : MonoBehaviour
{
    bool control = false; //false無人機 true人
    public fly drone;
    public GameObject Canvas_WordSpace;
    public GameObject panel_pause;
    public GameObject camera;
    // Start is called before the first frame update
    private void Awake()
    {
        Canvas_WordSpace.transform.position = new Vector3(0, Setting.CameraHight-0.5f, -13.5f);
        camera.transform.position = new Vector3(0, Setting.CameraHight, -15);
        drone.transform.position = Setting.DroneDefaultPosition;
    }
    public void Button_back_click()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.Three))//開啟暫停畫面 
        {
            panel_pause.SetActive(true);
        }
    }
    public void b1_click()//繼續
    {
        panel_pause.SetActive(false);
    }
    public void b2_click()//退出
    {
        SceneManager.LoadScene(0);
    }
}
