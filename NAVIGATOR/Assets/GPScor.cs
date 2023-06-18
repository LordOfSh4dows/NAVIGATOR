using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GPScor : MonoBehaviour
{
    public TMP_Text GPSStatus;
    public TMP_Text Latitude;
    public TMP_Text Longitude;
    public TMP_Text Altitude;


    void Start()
    {
        StartCoroutine(GPSin());
    }

    IEnumerator GPSin()
    {
        if (!Input.location.isEnabledByUser)
            yield break;

        Input.location.Start();
        int Wait = 30;
        while (Input.location.status == LocationServiceStatus.Initializing && Wait > 0)
        {
            yield return new WaitForSeconds(1);
            Wait--;
        }

        if (Wait < 1)
        {
            GPSStatus.text = "Время вышло";
            yield break;
        } 

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GPSStatus.text = "Не удаётся определить местоположение устройства";
            yield break;
        }
        else
        {
            InvokeRepeating("UpdateGPS", 1f, 1f);
        }
    }

    void UpdateGPS()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            GPSStatus.text = "Обновление...";
            Latitude.text=Input.location.lastData.latitude.ToString();
            Longitude.text=Input.location.lastData.longitude.ToString();
            Altitude.text=Input.location.lastData.altitude.ToString();

        }  
        else
        {
             GPSStatus.text = "Выполнено";
        }


    }

}
