using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is a temporary script to spawn an infinite amount of crowds
 * 
 * Still needs the following:
 * 1. This is spawning within a drawn gizmo. It looks interesting, but there are faults.
 *      - If there are objects around (couches, tables, etc) then objects could be instantiated within non-navmesh location areas.
 */


public class CrowdSpawner : MonoBehaviour {

    public GameObject crowdPrefab;      // To hold the crowd object prefab
    public GameObject targetPrefab;     // To hold target crowd object prefab
    public Vector3 center;              // To hold the position of the drawn cube
    public Vector3 size;                // To hold the size of the drawn cube
    public int crowd_count;             // To hold the amount of crowd objects wanting to spawn
    public GameObject targetPos;           // To hold position of target to be shown in Target Window

    private Color targetColor;          // To hold color scheme of target
   
	// Use this for initialization
	void Start () {
        // restrict the developer of crashing the game. 20 objects is minimum
        if(crowd_count > 21)
        {
            crowd_count = 20;
        }

        //spawn target NPC
        SpawnTarget();

        // spawns 'crowd_count' amount of objects by calling the SpawnNPC
		for(int i = 0; i < crowd_count; i++)
        {
            SpawnNPC();
        }
	}

    /// <summary>
    /// SpawnTarget method: Will spawn an object in a random location within the drawn box as target.
    /// Also, set's a random color on the target setting target color scheme
    /// Also, instantiates gameobject to be shown in TargetWindow
    /// </summary>
    private void SpawnTarget()
    {
        Vector3 pos = new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        GameObject target = Instantiate(crowdPrefab, pos, Quaternion.identity);
        GameObject targetClone = Instantiate(targetPrefab, targetPos.transform.position, Quaternion.identity);
        targetColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        target.GetComponent<Renderer>().material.color = targetColor;
        targetClone.GetComponent<Renderer>().material.color = targetColor;
        Debug.Log("Target: " + targetColor);
    }

    /// <summary>
    /// SpawnNPC method: Will spawn an object in a random location within the drawn box.
    /// Also, set's a random color on the clone
    /// </summary>
    private void SpawnNPC()
    {
        Vector3 pos = new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        Color randColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        if (randColor != targetColor)
        {
            GameObject dummy = Instantiate(crowdPrefab, pos, Quaternion.identity);
            dummy.GetComponent<Renderer>().material.color = randColor;
            Debug.Log("NPC: " + randColor);
        } else
        {
            SpawnNPC();
        }
    }

    /// <summary>
    /// OnDrawGizmosSelected method: To draw a cube within the game
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);    // color of drawn gizmo (transperant because of alpha at 0.5f
        Gizmos.DrawCube(center, size);              // draw the cube at position 'center', and of size 'size'
    }
}
