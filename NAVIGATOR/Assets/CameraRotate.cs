using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using TMPro;

public class CameraRotate : MonoBehaviour
{




    // Update is called once per frame
    void Update()
    {
        if (Input.location.status == LocationServiceStatus.Running)
            {
                transform.position=new Vector3(Input.location.lastData.longitude, 0,Input.location.lastData.latitude);
                transform.rotation=Quaternion.Euler(0, Input.compass.magneticHeading, 0);


            }
    }
}
