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
           Debug.Log("Timestop");
         if (Time.timeScale == 1.0f)
            {
             Time.timeScale = 0.0f;
            }
         }
        else
            {
                soundbar.SetActive(false);

            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;

        }

    }
}
