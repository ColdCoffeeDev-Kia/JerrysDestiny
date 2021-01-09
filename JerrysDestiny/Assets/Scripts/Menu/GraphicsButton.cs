using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsButton : MonoBehaviour
{
    [SerializeField] public Button Fast;
    [SerializeField] public Button Fancy;

    public Color EnabledCC;
    public Color DisabledCC;

    public void EnableFast()
    {
            ColorBlock en = Fast.colors;
            en.normalColor = EnabledCC;
            en.pressedColor = EnabledCC;
            en.selectedColor = EnabledCC;
            en.highlightedColor = EnabledCC;

            Fast.colors = en;
            ColorBlock dis = Fancy.colors;
            dis.normalColor = EnabledCC;
            dis.pressedColor = EnabledCC;
            dis.selectedColor = EnabledCC;
            dis.highlightedColor = EnabledCC;

            Fancy.colors = dis;
    }

    public void EnableFancy()
    {
        ColorBlock en = Fancy.colors;
        en.normalColor = EnabledCC;
        en.pressedColor = EnabledCC;
        en.selectedColor = EnabledCC;
        en.highlightedColor = EnabledCC;

        Fancy.colors = en;
        ColorBlock dis = Fast.colors;
        dis.normalColor = EnabledCC;
        dis.pressedColor = EnabledCC;
        dis.selectedColor = EnabledCC;
        dis.highlightedColor = EnabledCC;

        Fast.colors = dis;
    }
}
