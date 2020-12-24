using System;
using SantasHelper.Player;
using UnityEngine;
using UnityEngine.AI;

namespace SantasHelper.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyPathfinder : MonoBehaviour
    {
        [SerializeField] private Transform goal;
        private NavMeshAgent _navMeshAgent;
        private bool _isGoing;
        
        private void Start()
        {
            if (goal == null)
            {
                goal = FindObjectOfType<PlayerWalk>().transform;//TODO probably remove this idk
                if (goal == null)
                {
                    enabled = false;
                }
            }
                
            TryGetComponent(out _navMeshAgent);
        }

        private void OnEnable()
        {
            _isGoing = true;
        }

        private void Update()
        {
            if (!_isGoing)
                return;
            _navMeshAgent.destination = goal.position;
        }

        public void Stop()
        {
            _isGoing = false;
        }
    }
}