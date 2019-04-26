using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum AIstate {
        MOVINGTOPOINT,
        STATICPOINT,
        CHASING
    };

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class GravekeeperAI : MonoBehaviour

{   public Animator graveKeeper;
	public UnityEngine.AI.NavMeshAgent navmesh;
	public GameObject[] stoppoints;
	private int currSP = -1;
	private Vector3 waypointvel;


    public AIstate aistate;

    private void setNextWaypoint() {
    	if(stoppoints.Length <= 0) {

    	} else {
    		if (currSP >= (stoppoints.Length - 2)) {
    			currSP = 0;
    			aistate = AIstate.STATICPOINT; 
    		} else {
    			currSP++;
    		}
    		if(currSP == 1) 
    			aistate = AIstate.MOVINGTOPOINT; 
    		else 
    			aistate = AIstate.STATICPOINT;
    	}
	}

	private void setDestination(Vector3 dest) {
		navmesh.SetDestination(dest);
	}
    void Start()
    {
       setNextWaypoint();
        

    }

    // Update is called once per frame
    void Update()
    {	
    	switch(aistate) {
    		case AIstate.STATICPOINT:
    		if(navmesh.remainingDistance <= .1
    			&& navmesh.pathPending == false) {
    			setDestination(stoppoints[currSP].transform.position);
    			setNextWaypoint();
    			graveKeeper.SetFloat("vely", navmesh.velocity.magnitude / navmesh.speed);
    		}
    		break;
    		case AIstate.MOVINGTOPOINT:
    		    if(navmesh.remainingDistance <= .1
    			&& navmesh.pathPending == false) {
    			float dist = (stoppoints[currSP].transform.position 
    				- navmesh.transform.position).magnitude;
    			float time =  dist / navmesh.speed;
    			waypointvel = GameObject.Find("navpoint1").GetComponent<VelocityReporter>().velocity;
    			Vector3 futureTarget = stoppoints[currSP].transform.position + time * waypointvel;
    			setDestination(futureTarget);
    			setNextWaypoint();
    			graveKeeper.SetFloat("vely", navmesh.velocity.magnitude / navmesh.speed);
    		}
    		break;
            case AIstate.CHASING:
             if(navmesh.remainingDistance >= 3) {
                currSP = 14;
                float gdist = (stoppoints[currSP].transform.position 
                    - navmesh.transform.position).magnitude;
                float gtime =  gdist / navmesh.speed;
                waypointvel = GameObject.Find("navpoint1").GetComponent<VelocityReporter>().velocity * 20;
                Vector3 gfutureTarget = stoppoints[currSP].transform.position + gtime * waypointvel;
                setDestination(gfutureTarget);
                graveKeeper.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 3;
                graveKeeper.GetComponent<UnityEngine.AI.NavMeshAgent>().angularSpeed = 180;
             } else {
                graveKeeper.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0;
                graveKeeper.SetTrigger("reachedplayer");
             }
             
                break;
                

    	}
    }
}

