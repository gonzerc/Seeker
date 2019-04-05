using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shot : MonoBehaviour
{

    public float bulletSpeed;
    Rigidbody rb;
    public GameObject bullet;
    public Camera mainCam;
    public Camera quarryCam;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bullet = GetComponent<GameObject>();
        rb.velocity = transform.forward * bulletSpeed;

        quarryCam.enabled = false;  //Quarry Cam is set false until the mission fails
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "FakeTarget")
        {
            Debug.Log("WRONG TARGET");
            col.gameObject.SetActive(false);
            Destroy(bullet.gameObject);
            quarryCam.enabled = true;   //Quarry Cam is set true when nontarget is killed
        }

        if (col.gameObject.tag == "Target")
        {
            Debug.Log("QUARRY HIT");
            col.gameObject.SetActive(false);
            Destroy(bullet.gameObject);

        }
    }
}
