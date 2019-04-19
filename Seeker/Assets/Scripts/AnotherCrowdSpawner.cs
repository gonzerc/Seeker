using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//**************** CHANGE IS IN line 38 - 45 *********************
public class AnotherCrowdSpawner : MonoBehaviour {

    public GameObject crowdPrefab;      // To hold the crowd object prefab
    public Vector3 center;              // To hold the position of the drawn cube
    public Vector3 size;                // To hold the size of the drawn cube
    public int crowd_count;             // To hold the amount of crowd objects wanting to spawn

    // Use this for initialization
    void Start()
    {
        // restrict the developer of crashing the game. 20 objects is minimum
        if (crowd_count > 21)
        {
            crowd_count = 20;
        }

        // spawns 'crowd_count' amount of objects by calling the SpawnNPC
        for (int i = 0; i < crowd_count; i++)
        {
            SpawnNPC();
        }
    }

    /// <summary>
    /// SpawnNPC method: Will spawn an object in a random location within the drawn box.
    /// Also, set's a random color on the clone
    /// </summary>
    private void SpawnNPC()
    {
        Vector3 pos = new Vector3(center.x + (Random.Range(-size.x / 2, size.x / 2)), center.y + (Random.Range(-size.y / 2, size.y / 2)), center.z + (Random.Range(-size.z / 2, size.z / 2)));
        GameObject dummy = Instantiate(crowdPrefab, pos, Quaternion.identity);
        Renderer[] bodyparts = dummy.GetComponentsInChildren<Renderer>();

        for(int i = 0; i < bodyparts.Length; i++)
        {
            bodyparts[i].material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
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
