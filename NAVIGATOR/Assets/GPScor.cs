using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text GPSStatus;
    public Text Latitude;
    public Text Longitude;
    public Text altitude;
    public Text Hacc;
    public Text Time;
    void Start()
    {
        
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
            GPSStatus.text = "Выполнение...";
            InvokeRepeating("UpdateGPS", 1f, 1f);
        }
        }

    void UpdateGPS()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
             GPSStatus.text = "Выполнение...";
            Latitude.text=Input.location.lastData.latitude.ToString();
            Longitude.text=Input.location.lastData.longitude.ToString();
            altitude.text=Input.location.lastData.altitude.ToString();
            Hacc.text=Input.location.lastData.horizontalAccuracy.ToString();
            Time.text =Input.location.lastData.timestamp.ToString();

        }  
        else
        {
             GPSStatus.text = "Выполнено";
        }


    }

}
