using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoURL : MonoBehaviour
{

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void GOin()
    {
        Application.OpenURL(Rayc.url);
    }


}
