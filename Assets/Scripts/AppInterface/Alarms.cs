using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarms : MonoBehaviour
{
    public GameObject Prefab;
    float alarmPosX, alarmPosY;
    float alarmPrevPosX, alarmPrevPosY;

    public void AddAlarm()
    {
        Instantiate(Prefab, new Vector3(alarmPosX, alarmPosY, 0), Quaternion.identity);
    }
}
