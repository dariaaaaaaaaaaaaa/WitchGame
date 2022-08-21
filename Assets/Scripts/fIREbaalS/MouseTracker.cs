using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    private Camera _camera;
   private void Start()
    {
        _camera = Camera.main;
    }

    
   private void Update()
    {
        Vector2 screenMousePosition = Input.mousePosition;
        Vector2 worldMousePosition = _camera.ScreenToWorldPoint(screenMousePosition);
        transform.LookAt(worldMousePosition);

    }
}
