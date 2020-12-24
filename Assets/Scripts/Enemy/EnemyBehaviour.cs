using System;
using UnityEngine;
using SantasHelper.Tags;

namespace SantasHelper.Enemy
{
    [RequireComponent(typeof(EnemyAnimator), 
                      typeof(EnemyHealth), 
                      typeof(EnemyPathfinder))]
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform player;
        private EnemyAnimator _animator;
        private EnemyHealth _health;
        private EnemyPathfinder _pathfinder;

        private enum State
        {
            Following,
            Attacking,
            Dead
        }

        private State _state;

        private void Start()
        {
            TryGetComponent(out _animator);
            TryGetComponent(out _health);
            TryGetComponent(out _pathfinder);
        }

        private void OnEnable()
        {
            if (player == null)
            {
                player = FindObjectOfType<PlayerObject>().transform;//TODO probably remove this idk
                if (player == null)
                {
                    enabled = false;
                }
            }
            _state = State.Following;
        }
    }
}