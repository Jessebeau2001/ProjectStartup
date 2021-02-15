using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAlarm : MonoBehaviour
{
    const string ACTION_SET_ALARM = "android.intent.action.SET_ALARM";
    const string EXTRA_HOUR = "android.intent.extra.alarm.HOUR";
    const string EXTRA_MINUTES = "android.intent.extra.alarm.MINUTES";
    const string EXTRA_MESSAGE = "android.intent.extra.alarm.MESSAGE";

    public void OnClick()
    {
        Debug.Log("Setting Alarm");
        createAlarm("TestAlarm", 11, 00);
    }

    public void createAlarm(string message = "Test", int hours = 12, int minutes = 00)
    {
        var intentAJO = new AndroidJavaObject("android.content.Intent", ACTION_SET_ALARM);
        intentAJO.Call<AndroidJavaObject>("putExtra", EXTRA_MESSAGE, message)
            .Call<AndroidJavaObject>("putExtra", EXTRA_MINUTES, minutes)
            .Call<AndroidJavaObject>("putExtra", EXTRA_HOUR, hours);
        GetUnityActivity().Call("startActivity", intentAJO);

    }

    AndroidJavaObject GetUnityActivity()
    {
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }
}
