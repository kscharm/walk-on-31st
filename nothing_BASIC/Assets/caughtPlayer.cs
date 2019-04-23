using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caughtPlayer : MonoBehaviour
{
	public GameObject gravekeeper;
  	
  	void OnTriggerEnter() {
  		gravekeeper.GetComponent<GravekeeperAI>().aistate = AIstate.CHASING;
  	}
  
}
