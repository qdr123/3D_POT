using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameramouve : MonoBehaviour
{

    public GameObject camerapoint;
    public Camera mein;

    // Update is called once per frame
    void Update()
    {
        mein.transform.position = camerapoint.transform.position;
       
    }
}
