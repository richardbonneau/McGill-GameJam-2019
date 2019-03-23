   // Patrol.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;


    public class Patrol : MonoBehaviour {

        public GameObject[] points;
        private Transform playerPosition;
        private int destPoint = 0;
        private NavMeshAgent agent;

        public bool startPatrolling;
        
        
        // public bool chasePlayer;
        // public bool playerCameOutOfWater;


        void Start () {
            agent = GetComponent<NavMeshAgent>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = false;

            GotoNextPoint();

            playerPosition = GameObject.FindWithTag("Player").transform;
        }

        void Update () {
            // Choose the next destination point when the agent gets
            // close to the current one.

            // if(chasePlayer) GoToPlayer();
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }


        void GotoNextPoint() {
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].transform.position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }

        public void GoToPlayer(){
            agent.destination = playerPosition.position;
        }

        public void GoToLastKnownLocation(Vector3 location){
            agent.destination = location;
        }

        public void StopPatrolling(){
            agent.isStopped = true;
        }
    }