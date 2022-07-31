using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;

    void Update()
    {
        Vector3 target = player.position + Vector3.back;
        Vector3 pos = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);

        transform.position = pos;
    }
}
