using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class OptionsMenu : MonoBehaviour
{
    //TODO: TRY CATCH in reading/writing //// Buttons Switch colors;

    public bool Readable = true;
    
    private int currentSceneINX = -3;
    
    private string path = "data.jjer";

    public bool GraphicsFancy = true;
    
    private void Start()
    {
        //TODO Read and Initialize
        if (File.Exists(path))
        {
            ReadGraphics();
        }
        else
        {
            StreamWriter sw = File.AppendText(path);
            sw.Write("100\\100\\1");
            sw.Dispose();
        }
    }

    public void Back()
    {
        //GameObject.FindWithTag("Settings").SetActive(false);
        EntirePanel.SetActive(false);
    }

    public void Apply()
    {
        WriteGraphics(Brightness.value * 100, Volume.value * 100, Graphics.Fancy);
        Back();
    }

    public void ShowMenu()
    {
        //GameObject.FindWithTag("Settings").SetActive(true);
        EntirePanel.SetActive(true);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != currentSceneINX)
        {
            currentSceneINX = SceneManager.GetActiveScene().buildIndex;
        }
    }
    
    #region SaveStats

    public void ReadGraphics()
    {
        if (Readable)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                string st = sr.ReadToEnd();
                sr.Dispose();
                string[] Splitted = st.Split('\\');
                if (Splitted.Length == 3)
                {
                    Screen.brightness = float.Parse(Splitted[0]) / 100f;
                    Brightness.value = Screen.brightness;
                    AudioListener.volume = float.Parse(Splitted[1]) / 100f;
                    Volume.value = AudioListener.volume;
                    if (Splitted[2] == "0")
                    {
                        GraphicsFancy = false;
                    }
                    else
                    {
                        GraphicsFancy = true;
                    }
                }
            }
            catch
            {

            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Brightness">Between 0 and 100</param>
    /// <param name="Volume">Between 0 and 100</param>
    /// <param name="GoodGraphs">true: good, false: bad graphics</param>
    public void WriteGraphics(float Brightness, float Volume, bool GoodGraphs)
    {
        Readable = false;
        try
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                StreamWriter sw = File.CreateText(path);
                sw.Write(Brightness.ToString() + "\\" + Volume.ToString() + "\\" + (GoodGraphs ? "1" : "0"));
            }
        }
        catch
        {

        }
        finally
        {
            Readable = true;
            ReadGraphics();
        }
    }
    
    #endregion

    #region Items

    public Slider Brightness;
    public Slider Volume;
    public GraphicsButton Graphics;
    public GameObject EntirePanel;

    #endregion
}

//Brightness\Volume\{0/1 for graphics : 1 means fancy}