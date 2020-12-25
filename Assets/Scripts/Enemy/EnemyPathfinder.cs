using UnityEngine;
using UnityEngine.AI;

namespace SantasHelper.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyPathfinder : MonoBehaviour
    {
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

        public void SetPathfindingTarget(Transform target)
        {
            if (_navMeshAgent == null)
                return;
            _navMeshAgent.destination = target.position;
        }
        
        public void Stop()
        {
            _navMeshAgent.destination = transform.position;
            _isGoing = false;
        }
    }
}