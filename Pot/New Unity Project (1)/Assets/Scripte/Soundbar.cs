using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundbar : MonoBehaviour
{
    public GameObject soundbar;


    public void SoundBar()
    {
       
            if (soundbar.activeSelf == false)
            {
                soundbar.SetActive(true);
            }
            else
            {
                soundbar.SetActive(false);
            }
       
     }
}
