using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class fly : MonoBehaviour
{
    Rigidbody Drone;
    public GameObject TiltObject;//傾斜物件 (Drone_Body)
    private float Tilt_Amount_Forward = 0;//前後傾斜量(Rotation_X)
    private float Tilt_Amount_Sideway = 0;//左右傾斜量(Rotation_Z)
    private float Tilt_Velocity_Forward ;//前後傾斜速度
    private float Tilt_Velocity_Sideway ;//左右傾斜速度
    private float Rotation_Y = 0;//水平旋轉量

    public GameObject Reference1;//參考物件(地面)
    public GameObject Reference2;//參考物件(強制降落高度)
    public int FlyStatus;//飛行狀態 0關機 1起飛 2飛行 3降落

    public Vector3 position;//目前位置
    public float speed;//目前速度

    public Vector2 VectorLeft;//左手輸入
    public Vector2 VectorRight;//右手輸入
 
    private float Threshold = 0.4f;//誤觸阈值
    private int LeftM = 0;//左手主要方向(不檢測阈值) 0垂直1水平
    private int RightM = 0;//右手主要方向(不檢測阈值) 0垂直1水平

    private float RotationSpeed = 3; //水平旋轉速度
    private float HorizontalSpeed = 200f * Setting.Sensitivity; //水平移動速度
    private float VerticallSpeed = 0.8f * Setting.Sensitivity; //垂直移動速度
    private float TakeOffSpeed = 1.2f;//起飛速度

    private float MaxWindSpeed = 20f; //最大風速
    private float timer;//計時器
    private int cycle = 0;//風隨機週期
    private Vector3 WindVec;//風向量

    void Awake()
    {
        Drone = GetComponent<Rigidbody>();
        FlyStatus = 0;
    }
    void FixedUpdate()
    {
        position = Drone.transform.position - Reference1.transform.position;
        speed = Drone.velocity.magnitude;
        
        VectorLeft = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);//左手輸入;
        VectorRight = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);//右手輸入;
        
        if(Input.GetKey("w"))
        {
            VectorLeft.y = 0.7f;
        }
        else if (Input.GetKey("s"))
        {
            VectorLeft.y = -0.7f;
        }
        else
        {
            VectorLeft.y = 0;
        }

        if (Input.GetKey("a"))
        {
            VectorLeft.x = -0.7f;
        }
        else if(Input.GetKey("d"))
        {
            VectorLeft.x = 0.7f;
        }
        else
        {
            VectorLeft.x = 0;
        }

        if (Input.GetKey("i"))
        {
            VectorRight.y = 0.7f;
        }
        else if (Input.GetKey("k"))
        {
            VectorRight.y = -0.7f;
        }
        else
        {
            VectorRight.y = 0;
        }

        if (Input.GetKey("j"))
        {
            VectorRight.x = -0.7f;
        }
        else if (Input.GetKey("l"))
        {
            VectorRight.x = 0.7f;
        }
        else
        {
            VectorRight.x = 0;
        }

        if (Mathf.Abs(VectorLeft.x) > Mathf.Abs(VectorLeft.y))//判斷左手主要方向
        {
            LeftM = 1;//水平
        }
        else
        {
            LeftM = 0;//垂直
        }
        if (Mathf.Abs(VectorRight.x) > Mathf.Abs(VectorRight.y))//判斷右手主要方向
        {
            RightM = 1;//水平
        }
        else
        {
            RightM = 0;//垂直
        }

        if (FlyStatus == 0)//未啟動
        {
            if (VectorLeft.x > 0.5 && VectorRight.x < -0.5 && VectorLeft.y < -0.5 && VectorRight.y < -0.5)//內八
            {
                FlyStatus = 1;
            }
        }
        else if (FlyStatus == 1)//起飛
        {
            Drone.AddForce(Vector3.up * Drone.mass * Physics.gravity.magnitude * TakeOffSpeed);
            if (Drone.position.y > Reference2.transform.position.y + 0.3)
            {
                FlyStatus = 2;
            }
        }
        else if (FlyStatus == 2)//飛行
        {
            UpDown();//上下
            ForwardBackward();//前後
            LeftRight();//左右
            Rotation();//水平旋轉
            Tilt();//傾斜
            if(Setting.Attitude == true)
            {
                Wind();//隨機風場
            }
            if (Drone.position.y < Reference2.transform.position.y)
            {
                FlyStatus = 3;
            }
        }
        else if (FlyStatus == 3)//降落
        {
            if (Drone.position.y < Reference1.transform.position.y)//低於地面
            {
                FlyStatus = 0;
            }
            else//緩降
            {
                Drone.AddForce(Vector3.up * Drone.mass * Physics.gravity.magnitude * 0.6f);
            }
        }
    }
    void UpDown()//上下
    {
        if (Setting.Control == 0)//美 左垂直
        {
            if ((LeftM == 1 && Mathf.Abs(VectorLeft.y) < Threshold)||Mathf.Abs(VectorLeft.y) == 0)//小於阈值或輸入為零
            {
                Drone.AddForce(Vector3.up * Drone.mass * Physics.gravity.magnitude);//抵消重力
            }
            else
            {
                Drone.AddForce(Vector3.up * Drone.mass * Physics.gravity.magnitude * (1 + VectorLeft.y * VerticallSpeed));
            }
        }
        else if (Setting.Control == 1 || Setting.Control == 2)//日中 右垂直
        {
            if ((RightM == 1 && Mathf.Abs(VectorRight.y) < Threshold) || Mathf.Abs(VectorRight.y) == 0)//小於阈值或輸入為零
            {
                Drone.AddForce(Vector3.up * Drone.mass * Physics.gravity.magnitude);//抵消重力
            }
            else
            {
                if (VectorRight.y < 0)//下降
                {
                    Drone.AddForce(Vector3.up * Drone.mass * Physics.gravity.magnitude * (1 + (VectorLeft.y * 0.5f)) * VerticallSpeed * 0.2f);
                }
                else//上升
                {
                    Drone.AddForce(Vector3.up * Drone.mass * Physics.gravity.magnitude * (1 + VectorRight.y) * VerticallSpeed);
                }
            }
        }
    }
    void ForwardBackward()//前後
    {
        if (Setting.Control == 0)//美 右垂直
        {
            if (RightM == 0 || Mathf.Abs(VectorRight.y) > Threshold)//主方向或大於阈值
            {
                Drone.AddRelativeForce(Vector3.forward * VectorRight.y * HorizontalSpeed);
                Tilt_Amount_Forward = Mathf.SmoothDamp(Tilt_Amount_Forward, 20 * VectorRight.y, ref Tilt_Velocity_Forward, 0.1f);
            }
            else//不動
            {
                Tilt_Amount_Forward = Mathf.SmoothDamp(Tilt_Amount_Forward, 0.0f, ref Tilt_Velocity_Forward, 0.1f);
            }
        }
        else if (Setting.Control == 1 || Setting.Control == 2)//日中 左垂直
        {
            if (LeftM == 0 || Mathf.Abs(VectorLeft.y) > Threshold)//主方向或大於阈值
            {
                Drone.AddRelativeForce(Vector3.forward * VectorLeft.y * HorizontalSpeed);
                Tilt_Amount_Forward = Mathf.SmoothDamp(Tilt_Amount_Forward, 20 * VectorLeft.y, ref Tilt_Velocity_Forward, 0.1f);//計算傾斜量
            }
            else//不動
            {
                Tilt_Amount_Forward = Mathf.SmoothDamp(Tilt_Amount_Forward, 0.0f, ref Tilt_Velocity_Forward, 0.1f);//減少傾斜量
            }
        }
    }
    void LeftRight()//左右
    {
        if (Setting.Control == 2)//中 左水平
        {
            if (LeftM == 1 || Mathf.Abs(VectorLeft.x) > Threshold)//主方向或大於阈值
            {
                Drone.AddRelativeForce(Vector3.right * VectorLeft.x * HorizontalSpeed);
                Tilt_Amount_Sideway = Mathf.SmoothDamp(Tilt_Amount_Sideway, 20 * VectorLeft.x, ref Tilt_Velocity_Sideway, 0.1f);//計算傾斜量
            }
            else
            {
                Tilt_Amount_Sideway = Mathf.SmoothDamp(Tilt_Amount_Sideway, 0.0f, ref Tilt_Velocity_Sideway, 0.1f);//減少傾斜量
            }
        }
        else if (Setting.Control == 0 || Setting.Control == 1)//日美 右水平
        {
            if (RightM == 1 || Mathf.Abs(VectorRight.x) > Threshold)//主方向或大於阈值
            {
                Drone.AddRelativeForce(Vector3.right * VectorRight.x * HorizontalSpeed);
                Tilt_Amount_Sideway = Mathf.SmoothDamp(Tilt_Amount_Sideway, 20 * VectorRight.x, ref Tilt_Velocity_Sideway, 0.1f);//計算傾斜量
            }
            else
            {
                Tilt_Amount_Sideway = Mathf.SmoothDamp(Tilt_Amount_Sideway, 0.0f, ref Tilt_Velocity_Sideway, 0.1f);//減少傾斜量
            }
        }
    }
    void Rotation()//旋轉
    {
        if (Setting.Control == 2)//中 右水平
        {
            if (RightM == 1 || Mathf.Abs(VectorRight.x) > Threshold)//主方向或大於阈值
            {
                if (VectorRight.x > 0)
                {
                    Rotation_Y += RotationSpeed;
                }
                else
                {
                    Rotation_Y -= RotationSpeed;
                }
            }
        }
        else if (Setting.Control == 0 || Setting.Control == 1)//日美 左水平
        {
            if (LeftM == 1 || Mathf.Abs(VectorLeft.x) > Threshold)//主方向或大於阈值
            {
                if (VectorLeft.x > 0)
                {
                    Rotation_Y += RotationSpeed;
                }
                else
                {
                    Rotation_Y -= RotationSpeed;
                }
            }
        }
        Drone.transform.rotation = Quaternion.Euler(new Vector3(0, Rotation_Y, 0));//水平旋轉
    }
    void Tilt()//傾斜
    {
        TiltObject.transform.rotation = Quaternion.Euler(new Vector3(Tilt_Amount_Forward , Rotation_Y ,-Tilt_Amount_Sideway));//傾斜
    }
    void Wind()
    {
        timer++;
        if (timer > cycle)//每300幀隨機
        {
            WindVec = new Vector3(Random.Range(-MaxWindSpeed, MaxWindSpeed), 
                                  Random.Range(-MaxWindSpeed, MaxWindSpeed), 
                                  Random.Range(-MaxWindSpeed, MaxWindSpeed));
            timer = 0;
            cycle = Random.Range(10,500);
        }
        Drone.AddRelativeForce(WindVec);
        print("WindVec : " + WindVec);
    }
}
