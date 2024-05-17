using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;

public class Rayc : MonoBehaviour
{
    public float distant;
    public GameObject GUrl;
    public TMP_Text tude;
    public static bool FF = true;
    public static string obj;
    public static string WAY;
    public static string WAYurl;
    public static string url;
    float objID;


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, distant))
        {
            if (FF)
            {  
                obj = hit.collider.name;
                objID = float.Parse(obj);
                WAY = @"ID\" + obj;
                WAYurl = @"ID\" + obj + "URL";
                TextAsset Text=(TextAsset)Resources.Load(WAY);
                tude.text= Text.text;
                TextAsset URL=(TextAsset)Resources.Load(WAYurl);
                url=URL.text;
                if (URL)
                {
                    GUrl.SetActive(true);
                }
                else
                {
                    GUrl.SetActive(false);
                }

            }

        }

  
    }
}
