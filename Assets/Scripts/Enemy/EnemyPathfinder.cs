using UnityEngine;
using UnityEngine.AI;

namespace SantasHelper.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyPathfinder : MonoBehaviour
    {
        private Transform _goal;
        private NavMeshAgent _navMeshAgent;
        private bool _isGoing;
        
        private void Start()
        {
            
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
            _navMeshAgent.destination = _goal.position;
        }

        public void AssignPathfindingTarget(Transform target)
        {
            _goal = target;
        }
        
        public void Stop()
        {
            _isGoing = false;
        }
    }
}