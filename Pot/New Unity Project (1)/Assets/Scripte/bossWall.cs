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
    int count;
    
    // Update is called once per frame
    void Update()
    {
        if (Enemy.active == false)
        {

            count += 1;
            firewall.SetActive(false);
            PPoint.SetActive(true);
            if(PPoint.activeSelf==true)
            {
                Debug.Log("카메라 이동중");
            }
           
            sub.transform.position = Vector3.Lerp(sub.transform.position, triple.transform.position, 0.3f * Time.deltaTime);
            if (count<=120)
            {
                
                sub.transform.LookAt(last.transform);
            }
            

        }
    }
}
