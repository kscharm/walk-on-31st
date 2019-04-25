using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caughtPlayer : MonoBehaviour
{
	public GameObject gravekeeper;
  	public AudioSource  caught;
  	void OnTriggerEnter() {
  		gravekeeper.GetComponent<GravekeeperAI>().aistate = AIstate.CHASING;
  		gravekeeper.GetComponent<Animator>().SetTrigger("foundplayer");
  		caught.Play(0);
  		gameObject.active = false;
  	}

}
