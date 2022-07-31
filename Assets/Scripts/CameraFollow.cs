using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;

    void FixedUpdate()
    {
        Vector3 target = player.position + Vector3.back;
        Vector3 pos = Vector3.Lerp(transform.position, target, speed * Time.fixedDeltaTime);

        transform.position = pos;
    }
}
