using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soundcon : MonoBehaviour
{
    //public static Soundcon instance = null;
    public Slider backVolume;
    public AudioSource audio;
    float backVol = 1f;
    
   //public static Soundcon instace
   //{
   //    get
   //    {
   //        if (instace == null)
   //        {
   //            instace = new Soundcon();
   //        }
   //        return instance;
   //    }
   //}

    // Start is called before the first frame update
    void Start()
    {
        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        backVolume.value = backVol;
        audio.volume = backVolume.value;

    }

    // Update is called once per frame
    void Update()
    {
        SoundSilder();

    }
    public void SoundSilder()
    {
        audio.volume = backVolume.value;

        backVol = backVolume.value;
        PlayerPrefs.SetFloat("backvol", backVol);
    }
}
