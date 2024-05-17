using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateEnemy : MonoBehaviour
{
    public GameObject Cube;
    public GameObject newCube;
    public string WayE;
    public string Dan;
    public string[] dans = new string[5];
    TextAsset En;
    public float Xs;
    public float Zs;
    public float Xsc;
    public float Zsc;
    public int Iob=2000;
    public float Yrot;

    void Start()
    {
        for (var i = 0; i<Iob; i++)
        {
            WayE=@"InFrames\" + i;
            En =(TextAsset)Resources.Load(WayE);
            if(En)
            {
            Dan=En.text;
            dans = Dan.Split(' ');
            Xs=float.Parse(dans[1]);
            Zs=float.Parse(dans[0]);
            Yrot=float.Parse(dans[2]);
            Xsc=float.Parse(dans[3]);
            Zsc=float.Parse(dans[4]);

            newCube = Instantiate(Cube, new Vector3(Xs,0,Zs), Quaternion.Euler(0,Yrot,0));
            newCube.transform.localScale = new Vector3(Xsc,1,Zsc);
            newCube.name = i.ToString();
            Debug.Log(i);

            }

        }
        
        
    }


}
