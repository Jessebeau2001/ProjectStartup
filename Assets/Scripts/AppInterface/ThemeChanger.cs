using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeChanger : MonoBehaviour
{
    Dropdown dropdown;
    public Material gradient;
    public Material unselected;
    Color NightSky1 = new Color(0.23f, 0.18f, 0.35f, 1.0f);
    Color NightSky2 = new Color(0.58f, 0.32f, 0.56f, 1.0f);
    Color Dawn1 = new Color(0.23f, 0.18f, 0.34f, 1.0f);
    Color Dawn2 = new Color(0.53f, 0.24f, 0.33f, 1.0f);
    Color Peach1 = new Color(0.95f, 0.49f, 0.42f, 1.0f);
    Color Peach2 = new Color(1.0f, 0.94f, 0.84f, 1.0f);
    Color Watermelon1 = new Color(0.87f, 0.24f, 0.15f, 1.0f);
    Color Watermelon2 = new Color(0.95f, 0.45f, 0.38f, 1.0f);

    Color UnselectedDark = new Color(0.44f, 0.44f, 0.44f, 1.0f);
    Color UnselectedLight = new Color(0.66f, 0.66f, 0.66f, 1.0f);

    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(delegate
        {
            SelectTheme(dropdown);
        });
    }

    public void SelectTheme(Dropdown themeNum)
    {
        if (themeNum.value == 0)
        {
            gradient.SetColor("_TopColor", NightSky1);
            gradient.SetColor("_BottomColor", NightSky2);

            unselected.SetColor("_Color", UnselectedDark);
        }
        if (themeNum.value == 1)
        {
            gradient.SetColor("_TopColor", Dawn1);
            gradient.SetColor("_BottomColor", Dawn2);

            unselected.SetColor("_Color", UnselectedDark);
        }
        if (themeNum.value == 2)
        {
            gradient.SetColor("_TopColor", Peach1);
            gradient.SetColor("_BottomColor", Peach2);

            unselected.SetColor("_Color", UnselectedLight);
        }
        if (themeNum.value == 3)
        {
            gradient.SetColor("_TopColor", Watermelon1);
            gradient.SetColor("_BottomColor", Watermelon2);

            unselected.SetColor("_Color", UnselectedLight);
        }
    }
}
