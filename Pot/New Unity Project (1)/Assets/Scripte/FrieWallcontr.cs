using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrieWallcontr : MonoBehaviour
{
    public GameObject firewall;
    public GameObject Enemy;
    public GameObject Enemy2;
    // Start is called before the first frame update
    void Start()
    {
        //firewall = GetComponent<GameObject>();
        //Enemy = GetComponent<GameObject>();
       //Enemy2 = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy.active == false && Enemy2.active==false)
        {
            firewall.SetActive(false);
        }
    }
}
