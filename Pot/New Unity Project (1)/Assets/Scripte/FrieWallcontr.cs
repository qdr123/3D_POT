using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrieWallcontr : MonoBehaviour
{
    public GameObject firewall;
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject camerapoint;
    public Camera mein;
    int  count;
   

    // Start is called before the first frame update
    void Start()
    {
        //firewall = GetComponent<GameObject>();
        //Enemy = GetComponent<GameObject>();
        //Enemy2 = GetComponent<GameObject>();
        //mein = GameObject.Find("subcamera").;

    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy.active == false && Enemy2.active==false)
        {
            count += 1;
            camerapoint.SetActive(true);
            mein.transform.position = Vector3.Lerp(mein.transform.position, camerapoint.transform.position, 0.3f*Time.deltaTime);
            mein.transform.LookAt(firewall.transform);            
            Debug.Log(count);
            if (count>=180)
            {
                
                firewall.SetActive(false);
                camerapoint.SetActive(false);
               
            }

            

        }
       
    }
}
