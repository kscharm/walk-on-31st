using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace SkeletonEditor
{

    public class SkeletonMove : MonoBehaviour
    {
        GameObject player;
        NavMeshAgent nav;   


        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            nav.SetDestination(player.transform.position);
        }
    }
}