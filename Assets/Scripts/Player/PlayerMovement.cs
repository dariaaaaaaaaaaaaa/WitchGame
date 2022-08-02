using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private void Update()
    {
        float upDown = Input.GetAxis("Vertical") * speed;
        float leftRight = Input.GetAxis("Horizontal") * speed;
        var x = 0f;
       if (Input.GetKey(KeyCode.D))
        {
            x++;
        } else if (Input.GetKey(KeyCode.A))
        {
            x--;
        }
        var y = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            y++;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            y--;
        }
        rb.velocity = new Vector2(x, y) * speed; 
    }

}
 