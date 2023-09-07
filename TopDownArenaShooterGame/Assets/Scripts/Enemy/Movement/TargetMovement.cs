using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy.Movement
{
    public class TargetMovement : Movement
    {
        [SerializeField] private float minDistance;
        [SerializeField] private float lockTime;

        [SerializeField] private float dashTime;
        [SerializeField] private float dashVelocity;

        [SerializeField] private float stunTime;

        private Vector2 _direction;

        private MovementState _state = MovementState.Look;

        private Transform _targetTransform;


        private float _currentDashTime;
        private float _currentLockedTime;
        private float _currentStunTime;
        private Vector2 _distance;

        private void Start()
        {
            ChangeDirection();
            _targetTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        
        private void Update()
        {
            Move();
        }
        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Wall"))
            {
                if (_state == MovementState.Look)
                {
                    ChangeDirection();
                }
                else if (_state == MovementState.Dash)
                {
                    // hit damage to the character
                    _state = MovementState.Stun;
                    _currentStunTime = stunTime;
                }
            }
        }


        private void Move()
        {
            switch (_state)
            {
                case MovementState.Look:
                    Rigidbody.velocity = _direction * Speed;
                    _distance = _targetTransform.position - transform.position;
                    if (_distance.magnitude < minDistance)
                    {
                        _state = MovementState.Lock;
                        _currentLockedTime = lockTime;
                    }

                    break;
                case MovementState.Lock:
                    if (_currentLockedTime > 0)
                    {
                        Rigidbody.velocity = Vector2.zero;

                        _currentLockedTime -= Time.deltaTime;
                    }
                    else
                    {
                        _state = MovementState.Dash;
                        _direction = (_targetTransform.position - transform.position).normalized;
                        _currentDashTime = dashTime;
                    }

                    break;

                case MovementState.Dash:
                    if (_currentDashTime > 0)
                    {
                        Rigidbody.velocity = _direction * dashVelocity;
                        _currentDashTime -= Time.deltaTime;
                    }
                    else
                    {
                        _state = MovementState.Lock;
                        _currentLockedTime = lockTime;
                    }

                    break;

                case MovementState.Stun:
                    if (_currentStunTime > 0)
                    {
                        Rigidbody.velocity = Vector2.zero;
                        _currentStunTime -= Time.deltaTime;
                    }
                    else
                    {
                        _state = MovementState.Look;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ChangeDirection()
        {
            _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            _direction.Normalize();
        }

        private enum MovementState
        {
            Look, //searching for an enemy
            Lock,
            Dash, // care THIS MADAFAKA IS ATTACKING
            Stun // if it hits the wall
        }
    }
}