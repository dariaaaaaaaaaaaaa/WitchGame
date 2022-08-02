using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float speed;
        
        private void Update()
        {
            var velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            velocity = velocity.magnitude > 1 ? velocity / 2 : velocity;
            rb.velocity = velocity * speed;
        }
    }
}