using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycollition : MonoBehaviour
{
    public GameObject taget;

    // Start is called before the first frame update
    void Start()
    {
        taget = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            Debug.Log("플레이어가 맞았다.");
        }
       
    }
}
