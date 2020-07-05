using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settingchan : MonoBehaviour
{
   
    public void SceneChange1()
    {
        SceneManager.LoadScene("InGame");

    }
    public void SceneChange2()
    {
        SceneManager.LoadScene("Setting");
    }
}
