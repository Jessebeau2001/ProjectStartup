using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAlarm : MonoBehaviour
{
    const string ACTION_SET_ALARM = "android.intent.action.SET_ALARM";
    const string EXTRA_HOUR = "android.intent.extra.alarm.HOUR";
    const string EXTRA_MINUTES = "android.intent.extra.alarm.MINUTES";
    const string EXTRA_DAYS = "android.intent.extra.alarm.DAYS";
    const string EXTRA_MESSAGE = "android.intent.extra.alarm.MESSAGE";

    string AlarmTitle = "Test";
    int AlarmMinutes = 00;
    int AlarmHours = 12;
    int AlarmDay = 1;

    public void OnClick()
    {
        Debug.Log("Setting Alarm: " + AlarmHours + ":" + AlarmMinutes + " " + AlarmTitle);
        createAlarm();
    }

    public void createAlarm()
    {
        var intentAJO = new AndroidJavaObject("android.content.Intent", ACTION_SET_ALARM);
        intentAJO.Call<AndroidJavaObject>("putExtra", EXTRA_MESSAGE, AlarmTitle)
            .Call<AndroidJavaObject>("putExtra", EXTRA_MINUTES, AlarmMinutes)
            .Call<AndroidJavaObject>("putExtra", EXTRA_HOUR, AlarmHours)
            .Call<AndroidJavaObject>("putExtra", EXTRA_DAYS, AlarmDay);
        GetUnityActivity().Call("startActivity", intentAJO);

    }

    AndroidJavaObject GetUnityActivity()
    {
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }


    public void SetAlarmTitle(string title)
    {
        AlarmTitle = title;
    }

    public void SetAlarmMinutes(int minutes)
    {
        AlarmMinutes = minutes;
    }

    public void SetAlarmHours(int hours)
    {
        AlarmHours = hours;
    }

    public void SetAlarmDay(int day)
    {
        AlarmDay = day;
    }
}
