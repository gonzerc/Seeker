using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSpawner : MonoBehaviour
{

    public GameObject crowdPrefab;      // To hold the crowd object prefab
    public GameObject targetClonePrefab;// To hold target clone prefab
    public GameObject targetClonePos;   // To hold target clone position

    public int numSpawners;             // To hold number of spawners

    public Vector3[] center;            // To hold the position of the drawn cube
    public Vector3[] size;              // To hold the size of the drawn cube
    public int crowd_count;             // To hold the amount of crowd objects wanting to spawn

    private Color targetColor;

    // Use this for initialization
    private void Start()
    {
        // restrict the developer of crashing the game. 20 objects is minimum
        if (crowd_count > 21)
        {
            crowd_count = 20;
        }

        SpawnTarget();

        // spawns 'crowd_count' amount of objects by calling the SpawnNPC
        for (int i = 0; i < crowd_count; i++)
        {
            SpawnNPC();
        }
    }

    private void SpawnTarget()
    {
        //Get index for random spawn location
        int spawnIndex = Random.Range(0, numSpawners);

        Vector3 pos = new Vector3(Random.Range(-size[spawnIndex].x / 2, size[spawnIndex].x / 2),
            Random.Range(-size[spawnIndex].y / 2, size[spawnIndex].y / 2),
            Random.Range(-size[spawnIndex].z / 2, size[spawnIndex].z / 2));

        GameObject target = Instantiate(crowdPrefab, pos, Quaternion.identity);
        target.gameObject.tag = "Target";   //assigns a tag to the target
        targetColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        target.GetComponent<Renderer>().material.color = targetColor;

        GameObject targetClone = Instantiate(targetClonePrefab, targetClonePos.transform.position, Quaternion.identity);
        targetClone.GetComponent<Renderer>().material.color = targetColor;
    }

    /// <summary>
    /// SpawnNPC method: Will spawn an object in a random location within the drawn box.
    /// Also, set's a random color on the clone
    /// </summary>
    private void SpawnNPC()
    {
        for (int i = 0; i < center.Length; i++)
        {
            Vector3 pos = new Vector3(center[i].x + (Random.Range(-size[i].x / 2, size[i].x / 2)),
                center[i].y + (Random.Range(-size[i].y / 2, size[i].y / 2)),
                center[i].z + (Random.Range(-size[i].z / 2, size[i].z / 2)));

            Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            //check that random color is not target color
            if (randomColor != targetColor)
            {
                GameObject dummy = Instantiate(crowdPrefab, pos, Quaternion.identity);
                dummy.gameObject.tag = "FakeTarget";
                dummy.GetComponent<Renderer>().material.color = randomColor;
            }
            else
            {
                SpawnNPC();
            }
        }
    }

    /// <summary>
    /// OnDrawGizmosSelected method: To draw a cube within the game
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < numSpawners; i++)
        {
            Gizmos.color = new Color(1, 0, 0, 0.5f);    // color of drawn gizmo (transperant because of alpha at 0.5f
            Gizmos.DrawCube(center[i], size[i]);              // draw the cube at position 'center', and of size 'size'
        }
    }

}
