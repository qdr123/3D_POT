using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossWall : MonoBehaviour
{
    public GameObject firewall;
    public GameObject Enemy;
    public GameObject PPoint;
    public GameObject triple;
    public GameObject last;
    public Camera sub;
    int count2;
    
    // Update is called once per frame
    void Update()
    {
        if (Enemy.activeSelf == false)
        {

            count2 += 1;
            firewall.SetActive(false);
            PPoint.SetActive(true);
            if(PPoint.activeSelf==true)
            {
                Debug.Log("카메라 이동중");
            }
            if(PPoint.activeSelf==true)
            {
                sub.transform.position = Vector3.Lerp(sub.transform.position, triple.transform.position, 0.3f * Time.deltaTime);
                sub.transform.LookAt(triple.transform);
                if (count2 <= 120)
                {
                    sub.transform.position = Vector3.Lerp(triple.transform.position, last.transform.position, 0.3f * Time.deltaTime);

                }
            }
           
            
            

        }
    }
}
