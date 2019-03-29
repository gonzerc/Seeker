using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shot : MonoBehaviour {

    public float bulletSpeed;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
	}

    /*private void OnCollisionEnter(Collision collision)
    {
        Collider c = collision.collider;

        c.GetComponent<Rigidbody>().useGravity = false;
        c.GetComponent<NavMeshAgent>().enabled = false;
    }*/
}
