using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StopSearch : MonoBehaviour
{
    public TMP_Text but;



    // Update is called once per frame
    public void Lemon()
    {
        if (but.text == "Остановить поиск")
        {
            Rayc.FF=false;
            but.text = "Возобновить поиск";
        }
        else 
        {
            Rayc.FF = true;
            but.text = "Остановить поиск";
        }

    }
}
