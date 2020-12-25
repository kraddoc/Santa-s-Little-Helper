using System;
using UnityEngine;
using SantasHelper.Tags;

namespace SantasHelper.Enemy
{
    [RequireComponent(typeof(EnemyAnimator), 
                      typeof(EnemyHealth), 
                      typeof(EnemyPathfinder))]
    [RequireComponent(typeof(EnemyAttack))] //is this terrible? it probably is
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private PlayerObject player;
        private Transform _playerTransform;
        private EnemyAnimator _animator;
        private EnemyHealth _health;
        private EnemyPathfinder _pathfinder;
        private EnemyAttack _attack;

        private enum State
        {
            Following,
            StartingAttack,
            Attacking,
            Dead
        }

        private State _state;

        private void Awake()
        {
            TryGetComponent(out _animator);
            TryGetComponent(out _health);
            TryGetComponent(out _pathfinder);
            TryGetComponent(out _attack);
        }

        private void OnEnable()
        {
            if (player == null)
            {
                player = FindObjectOfType<PlayerObject>();
                if (player == null)
                {
                    enabled = false;
                }
            }

            _playerTransform = player.transform;
            
            _state = State.Following;
            
            _attack.PassPlayerReference(player);
            _pathfinder.SetPathfindingTarget(player.transform);

            _health.OnDeath += Die;
        }


        private void Update()
        {
            if (_state == State.Dead)
                return;

            _state = DecideState();
            HardcodeAILogic();
        }

        private State DecideState()
        {
            if (_attack.CloseEnough() && !_attack.IsAttacking && _state == State.Following)
                return State.StartingAttack;

            switch (_state)
            {
                case State.StartingAttack when _attack.IsAttacking:
                    return State.Attacking;
                case State.Attacking when !_attack.IsAttacking:
                    return State.Following;
                case State.Attacking when _attack.IsAttacking:
                    return State.Attacking;
                case State.Dead:
                    break;
                default:
                    return State.Following;
            }
            throw new Exception($"Your enemy state logic went too far on {gameObject.name}, you failed yourself.");
        }

        private void HardcodeAILogic()//neural network wrote this code after eating a million of spaghetti noodles
        {
            switch (_state)
            {
                case State.StartingAttack:
                    _pathfinder.Stop();
                    _attack.StartAttack();
                    break;
                case State.Following:
                    _pathfinder.SetPathfindingTarget(_playerTransform);
                    break;
                case State.Dead:
                    _pathfinder.Stop();
                    _animator.Die();
                    break;
                case State.Attacking:
                    _pathfinder.Stop();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Die()
        {
            _state = State.Dead;
            _health.OnDeath -= Die;
        }
    }
}