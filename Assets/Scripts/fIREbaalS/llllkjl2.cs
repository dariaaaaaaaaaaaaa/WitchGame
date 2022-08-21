using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llllkjl2 : MonoBehaviour
{
    public GameObject fireball;

    public Rigidbody2D ffireball;
    public Transform end;

    public int speed;

    public object Instance { get; private set; }

    private object GetInstance()
    {
        return Instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // var fireball.instance.Rigidbody2D = Instantiate(fireball.transform.position.quaternion.identity);
            Rigidbody2D ffireballInstance;
            ffireballInstance = Instantiate(ffireball, end.position, end.rotation) as Rigidbody2D;
            ffireballInstance.AddForce(end.forward * speed);

        }
    }
}
