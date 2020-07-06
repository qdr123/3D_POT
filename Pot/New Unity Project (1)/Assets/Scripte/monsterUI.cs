using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterUI : MonoBehaviour
{
   
    public Slider hpBar;
    public GameObject HeadUpPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        hpBar.transform.position = HeadUpPosition.transform.position;
        if(hpBar.value <= 0)
        {
            hpBar.gameObject.SetActive(false);
        }
    }
}
