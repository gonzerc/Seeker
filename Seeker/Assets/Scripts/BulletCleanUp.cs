using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCleanUp : MonoBehaviour {

    //public GameObject bullet;
    private GameController gameController;

	// Use this for initialization
	void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        //Debug.Log("Bullet deleted");
        if (other.tag == "Player")
        {
            gameController.setEndGameText("You fell..nice job");
            gameController.RestartScene();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
