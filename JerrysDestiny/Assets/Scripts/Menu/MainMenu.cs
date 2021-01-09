using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        
    }

    public void Options()
    {
        GameObject.FindWithTag("SettingsController").GetComponent<OptionsMenu>().ShowMenu();
    }

    public void Credits()
    {
        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
