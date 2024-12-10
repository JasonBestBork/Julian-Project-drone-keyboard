using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public static int Level = -1; //目前等級 0基本<2 1基本 2高級一 3高級二 4高級三
    public static int Stage = -1; //目前關卡
    public static bool Complete = false;//0單關 1完整流程
    public static int Control = 0; //操作模式 0美國手 1日本手 2中國手
    public static bool Attitude = false; //飛行模式 0GPS 1姿態
    public static float Sensitivity = 1f; //靈敏度 1 1.25 1.5
    public static bool SmallMap = true;//小地圖開關
    public static bool DroneCamera = true;//無人機前鏡頭開關
    public static bool Cheat = false;//作弊開關
    public static int Language = 0;//0中文 1英文
    public static bool End_Check = false;//是否為結尾檢查
    internal static Vector3 DroneDefaultPosition;

    public static float CameraHight { get; internal set; }
    //左垂直/左水平/右垂直/右水平
    //美國手 上下 旋轉 前後 左右
    //日本手 前後 旋轉 上下 左右
    //中國手 前後 左右 上下 旋轉
}
