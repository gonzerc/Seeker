using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCleanUp : MonoBehaviour {

    //public GameObject bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        //Debug.Log("Bullet deleted");
        if (other.tag != "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
