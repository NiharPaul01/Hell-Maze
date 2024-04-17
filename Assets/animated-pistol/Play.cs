using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage = 10f;
    public float range = 100f;
    public Camera c1;
    public Text T;
    public float s = 0;
    AudioSource a1;

    // Start is called before the first frame update
    void Start()
    {
        a1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            a1.Play();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(c1.transform.position, c1.transform.forward, out hit, range))
        {
            healthy t = hit.transform.GetComponent<healthy>();
            if (hit.collider.gameObject.tag == "enemy")
            {
                if (t != null)
                {
                    t.healthdamage(damage);
                    s++;
                    T.text = "Score " + s;
                }
            }
        }
    }
}
