using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMagik : MonoBehaviour
{
    public Vector2 fireBallForce;
    public GameObject FireBall;



    public Vector2 StartingVelocity;

    private void Start()
    {
        FireBall.SetActive(false);
        // GetComponent<Rigidbody2D>().velocity = StartingVelocity;
       
    }


    private void Update()
    {
       // Magic();
        if (Input.GetKeyDown(KeyCode.O))
        {
            FireBall.SetActive(true);
            GetComponent<Rigidbody2D>().velocity = StartingVelocity;
            Debug.Log("tttt");
        }

    }

    private void GotToTheTarget()
    {
       // FireBall.SetActive(false);
    }

    private void Magic()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FireBall.SetActive(true);
            GetComponent<Rigidbody2D>().velocity = StartingVelocity;
            Debug.Log("tttt");
        }

        
    }
}
