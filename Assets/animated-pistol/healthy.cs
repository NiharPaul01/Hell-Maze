using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class healthy : MonoBehaviour {
    public float health = 50f;
    public Image img;
    public Vector3 offset;
    void hbar()
    {
        img.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
    public void healthdamage(float amt)
    {
        health -= amt;
        Debug.Log(health);
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
        float chealth = health / 50f;
        if (chealth >= .75f)
        {
            img.color = Color.green;
            img.fillAmount = chealth;
        }
        else if (chealth >= .4f && chealth <= .75f)
        {
            img.color = Color.yellow;
            img.fillAmount = chealth;
        }
        else if (chealth < .4f)
        {
            img.color = Color.red;
            img.fillAmount = chealth;
        }
    }
}
