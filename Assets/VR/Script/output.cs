using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using OfficeOpenXml;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Android;


public class output : MonoBehaviour
{
    private Vector3 position;//座標
    private Vector3 rotation;//角度
    private float speed;//速度

    private Vector2 leftinput;//左手輸入
    private Vector2 rightinput;//右手輸入

    private float time;


    string target_name;

    public fly drone;
    public manager manager;

    StreamWriter writer;
    string path;
    FileInfo tmp_file;
    FileInfo file;

    void permission()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {

        }
        else
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }
    }
    private void Start()
    {
        permission();
    }
    void OnEnable()
    {
        //path = Application.persistentDataPath;
        path = "C:/123";
        tmp_file = new FileInfo(path + "/tmp_filedata.csv");
        if (tmp_file.Exists)
        {
            tmp_file.Delete();
            tmp_file.Refresh();

            WriteData("time" + "," +
                      "pos_x" + "," + "pos_y" + "," + "pos_z" + "," +
                      "rot_x" + "," + "rot_y" + "," + "rot_z" + "," +
                      "speed" + "," +
                      "left_x" + "," + "left_y" + "," +
                      "right_x" + "," + "right_y" + "," +
                      "tar_name" + "," +
                      "tar_distance" + "," +
                      "tar_x" + "," + "tar_y" + "," + "tar_z" + "," +
                      "IsClosed" + "," +
                      "Touching" + "," +
                      "IsOut" + "," +
                      "Out_Countdown" + "," +
                      "\n");
        }
    }
    void WriteData(string message)
    {
        //FileInfo file = new FileInfo(path + "/data.csv");
        FileInfo tmp_file = new FileInfo(path + "/tmp_filedata.csv");
        if (!tmp_file.Exists)
        {
            writer = tmp_file.CreateText();
        }
        else
        {
            writer = tmp_file.AppendText();
        }
        writer.WriteLine(message);
        writer.Flush();
        writer.Dispose();
        writer.Close();
    }
    public void RecordData(string RuleName, bool IsSeccess)
    {
        //設定值
        Debug.Log("111111111111");
        WriteData("Level : " + manager.NowLevel);
        WriteData("Stage : " + manager.NowRule);
        WriteData("Control : " + Setting.Control.ToString());
        WriteData("Attitude : " + Setting.Attitude.ToString());
        WriteData("Sensitivity : " + Setting.Sensitivity.ToString("f2"));
        if (IsSeccess)
        {
            Debug.Log("2222222222222222");
            FileInfo t = new FileInfo(path + "/" + RuleName + "PassData.csv");
            if (t.Exists)
            {
                t.Delete();
                t.Refresh();
            }
            file = tmp_file.CopyTo(path + "/" + RuleName + "PassData.csv");
        }
        else
        {
            Debug.Log("3333333333333333");
            FileInfo t = new FileInfo(path + "/" + RuleName + "FailData.csv");
            if (t.Exists)
            {
                t.Delete();
                t.Refresh();
            }
            file = tmp_file.CopyTo(path + "/" + RuleName + "FailData.csv");
        }
    }
    void FixedUpdate()
    {
        rotation = drone.transform.rotation.ToEulerAngles();
        speed = drone.speed;
        position = drone.position;

        leftinput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);//左手輸入;
        rightinput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);//右手輸入;

        if (manager.Target)
        {
            target_name = manager.Target.name;
        }
        else
        {
            target_name = "not_exit";
        }

        time = manager.count_time;

        WriteData(time.ToString("f3") + "," +//time
                   position.x.ToString("f3") + "," + position.y.ToString("f3") + "," + position.z.ToString("f3") + "," +//position
                   rotation.x.ToString("f3") + "," + rotation.y.ToString("f3") + "," + rotation.z.ToString("f3") + "," +//rotation
                   speed.ToString("f3") + "," + //speed
                   leftinput.x.ToString("f3") + "," + leftinput.y.ToString("f3") + "," +//leftinput
                   rightinput.x.ToString("f3") + "," + rightinput.y.ToString("f3") + "," +//rightinput
                   target_name + "," +//target_name
                   manager.Target_Distance.ToString("f3") + "," +//target_distance
                   manager.Target_Position.x.ToString("f3") + "," + manager.Target_Position.y.ToString("f3") + "," + manager.Target_Position.z.ToString("f3") + "," + //target_position
                   manager.IsClosed.ToString() + "," +//IsClosed
                   manager.Touching.ToString() + "," +//Touching
                   manager.IsOut.ToString() + "," +//IsOut
                   manager.Out_Countdown.ToString("f3") + "," +//Out_Countdown
                   "\n");
    }
}
