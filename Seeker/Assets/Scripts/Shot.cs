using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{

    public float bulletSpeed;
    Rigidbody rb;
    public GameObject bullet;
    public Camera mainCam;
    public Camera quarryCam;
    
    private CrowdSpawner cs;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bullet = GetComponent<GameObject>();
        rb.velocity = transform.forward * bulletSpeed;

        quarryCam.enabled = false;  //Quarry Cam is set false until the mission fails

        cs = GameObject.FindGameObjectWithTag("GameController").GetComponent<CrowdSpawner>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "FakeTarget")
        {
            Debug.Log("WRONG TARGET");
            col.gameObject.SetActive(false);
            Destroy(this.gameObject);
            cs.setEndGameText("Keep Looking");


            quarryCam.enabled = true;   //Quarry Cam is set true when nontarget is killed
        }

        if (col.gameObject.tag == "Target")
        {
            Debug.Log("QUARRY HIT");
            col.gameObject.SetActive(false);
            Destroy(this.gameObject);
            cs.setEndGameText("You Win!");
        }
    }
}
