using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public static int Level = -1; //�ثe���� 0��<2 1�� 2���Ť@ 3���ŤG 4���ŤT
    public static int Stage = -1; //�ثe���d
    public static bool Complete = false;//0���� 1����y�{
    public static int Control = 0; //�ާ@�Ҧ� 0����� 1�饻�� 2�����
    public static bool Attitude = false; //����Ҧ� 0GPS 1���A
    public static float Sensitivity = 1f; //�F�ӫ� 1 1.25 1.5
    public static bool SmallMap = true;//�p�a�϶}��
    public static bool DroneCamera = true;//�L�H���e���Y�}��
    public static bool Cheat = false;//�@���}��
    public static int Language = 0;//0���� 1�^��
    public static bool End_Check = false;//�O�_�������ˬd
    internal static Vector3 DroneDefaultPosition;

    public static float CameraHight { get; internal set; }
    //������/������/�k����/�k����
    //����� �W�U ���� �e�� ���k
    //�饻�� �e�� ���� �W�U ���k
    //����� �e�� ���k �W�U ����
}
