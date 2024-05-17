using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using TMPro;
using System;


public class GPScor : MonoBehaviour
{
    public TMP_Text GPSStatus;
    public TMP_Text Latitude;
    public TMP_Text Longitude;
    public TMP_Text AAltitude;
    public TMP_Text COMPAStude;


    void Start()
    {
        StartCoroutine(GPSin());
    }

    IEnumerator GPSin()
    {

        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }

        yield return new WaitForSeconds(5);

        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }

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
            InvokeRepeating("UpdateGPS", 0.1f, 1f);
        }
        Input.compass.enabled = true;
    }

     private void UpdateGPS()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            GPSStatus.text = "Обновление...";
            Latitude.text=Input.location.lastData.latitude.ToString();
            Longitude.text=Input.location.lastData.longitude.ToString();
            AAltitude.text=Input.location.lastData.altitude.ToString();
            COMPAStude.text=Input.compass.magneticHeading.ToString();


        }  
        else
        {
             GPSStatus.text = "Выполнено";
        }


    }

}
