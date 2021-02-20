using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class SwitchHandler : MonoBehaviour
{
    int switchState = 1;
    public GameObject switchBtn;
    public GameObject switchBack;
    public Material materialGrey;
    public Material materialColour;

    public void OnSwitchButtonClicked()
    {
        switchBtn.transform.DOLocalMoveX(-switchBtn.transform.localPosition.x, 0.2f);
        switchState = Math.Sign(-switchBtn.transform.localPosition.x);

        if (switchState == -1)
        {
            switchBack.GetComponent<Image>().material = materialGrey;
        }
        else
        {
            switchBack.GetComponent<Image>().material = materialColour;
        }
    }

}