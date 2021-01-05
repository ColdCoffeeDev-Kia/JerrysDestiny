using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilmGrain : MonoBehaviour
{
    public float ChangeSpeed = 0.0001f;

    public float MinX, MaxX, MinY, MaxY;

    private float lastUpdate = 0f;
    private void Update()
    {

        if (Time.time - lastUpdate >= ChangeSpeed)
        {
            float x = UnityEngine.Random.Range(MinX, MaxX);
            float y = UnityEngine.Random.Range(MinY, MaxY);

            GetComponent<RectTransform>().position = new Vector3(x, y, 0f);
            
            lastUpdate = Time.time;
        }
    }
}
