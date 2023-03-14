using UnityEngine;

namespace Enemy.Movement
{
    public class TargetMovement : Movement
    {
        enum MovementState
        {
            Look, //searching for an enemy
            Lock,
            Dash, // care THIS MADAFAKA IS ATTACKING
            Stun  // if it hits the wall
        }

        private MovementState _state = MovementState.Look;
        
        private Transform _targetTransform;

        [SerializeField] private float minDistance;
        [SerializeField] private float lockTime;

        [SerializeField] private float dashTime;
        [SerializeField] private float dashVelocity;

        [SerializeField] private float stunTime;
        

        private float currentDashTime;
        private float currentLockedTime;
        private float currentStunTime;

        private Vector2 _direction;
        private Vector2 distance;
        
        protected new void Start()
        {
            base.Start();
            ChangeDirection();
            _targetTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        
        protected override void Move()
        { 
            switch (_state)
            { 
                case MovementState.Look:
                    Rb2D.velocity = _direction * Speed;
                    distance = (_targetTransform.position - transform.position);
                    if (distance.magnitude < minDistance)
                    {
                        _state = MovementState.Lock;
                        currentLockedTime = lockTime;
                    }

                    break;
                case MovementState.Lock:
                    if (currentLockedTime > 0)
                    {
                        Rb2D.velocity = Vector2.zero;
                        
                        currentLockedTime -= Time.deltaTime;
                    }
                    else
                    {
                        _state = MovementState.Dash;
                        _direction = (_targetTransform.position - transform.position).normalized;
                        currentDashTime = dashTime;
                    }
                    
                    break;
                
                case MovementState.Dash:
                    if (currentDashTime > 0)
                    {
                        Rb2D.velocity = _direction * dashVelocity;
                        currentDashTime -= Time.deltaTime;
                    }
                    else
                    {
                        _state = MovementState.Lock;
                        currentLockedTime = lockTime;
                    }
                    
                    break;
                
                case MovementState.Stun:
                    if (currentStunTime > 0)
                    {
                        Rb2D.velocity = Vector2.zero;
                        currentStunTime -= Time.deltaTime;
                    }
                    else
                    {
                        _state = MovementState.Look;
                    }
                    
                    break;
            }
            
        }
        
        protected void OnTriggerStay2D(Collider2D col)
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
                    currentStunTime = stunTime;
                }
            }
        }

        private void ChangeDirection()
        {
            _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            _direction.Normalize();
        }
        
        
    }
}