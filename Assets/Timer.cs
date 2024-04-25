using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    bool tim = false;
    float ctime;
    public float stime = 1f;
    public Text timtext;
    
    int it=10;
    void Start()
    {
        
        ctime = stime * 60;
        tim = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (tim == true)
        {
            ctime = ctime - Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(ctime);
        timtext.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();

        if (time.Seconds == 0 && time.Minutes == 0)
        {
            Debug.Log("Time over!!!");
            SceneManager.LoadScene(0);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.CompareTag("diamond"))
        {
            Destroy(collision.gameObject);
            ctime += it;
            
        }
    }

}
