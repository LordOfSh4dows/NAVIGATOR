using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
public class Camerimage : MonoBehaviour
{
    WebCamTexture webCamTexture;


    void Update()
    {
        if (webCamTexture)
        {
        }
        else
        {
            if (Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                webCamTexture = new WebCamTexture();
                GetComponent<Image>().material.mainTexture=webCamTexture;
                webCamTexture.Play();
            }
        }
        
    }
}
