using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   // Library needed for NavMeshAgent

/*
 * This is a temporary script for the crowd walking
 * 
 * Still needs the following:
 * 1. Stops for a specific amount of time
 * 2. Give agents activites to do, set booleans for when activity is done to start next destination
 * 3. 
 */

public class CrowdWalking : MonoBehaviour {

    public List<Transform> waypoints;           // To hold the waypoints the NPCs will travel

    private NavMeshAgent agent;                 // To hold the NavMeshAgent component
    private Transform target_destination;       // To hold the target destination in which the agent will travel
    private const int EPSILON = 1;              // To hold the constant of how far an agent has to be from it's current target

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();                                   // set NavMeshAgent component to 'agent'
        target_destination = waypoints[Random.Range(0, waypoints.Count)];       // set One of the waypoint's target destination to 'target_destination'
        agent.SetDestination(target_destination.position);                      // set the destination to the new target destination
	}
	
	// Update is called once per frame
	void Update () {
        // if agent has reached its target destination, then pick a new destination and start agents set destination
		if((target_destination.position - transform.position).magnitude <= EPSILON)
        {
            target_destination = waypoints[Random.Range(0, waypoints.Count)];
            agent.SetDestination(target_destination.position);
        }
	}
}
