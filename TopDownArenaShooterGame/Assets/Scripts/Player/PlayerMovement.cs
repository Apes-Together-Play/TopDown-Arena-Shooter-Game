using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;

        private Rigidbody2D _rb2d;

        private void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
        
            var movement = new Vector2(horizontal, vertical);
            _rb2d.velocity = movement * speed;
        }
    }
}
