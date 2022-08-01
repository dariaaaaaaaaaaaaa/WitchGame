using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;


        private void Update()
        {
            Vector3 pos = transform.position;

            if(Input.GetKey("w"))
            {
                pos.y += speed * Time.deltaTime;
            }

            if (Input.GetKey("s"))
            {
                pos.y -= speed * Time.deltaTime;
            }
            if (Input.GetKey("d"))
            {
                pos.x += speed * Time.deltaTime;
            }
            if (Input.GetKey("a"))
            {
                pos.x -= speed * Time.deltaTime;
            }
            transform.position = pos;
        }
    }
}
