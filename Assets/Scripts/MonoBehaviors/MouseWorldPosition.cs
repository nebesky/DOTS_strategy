using System;
using UnityEngine;

public class MouseWorldPosition : MonoBehaviour
{
    private Camera _mainCamera;
    
    public static MouseWorldPosition Instance { get; private set; }
    
    private void Awake()
    {
        _mainCamera = Camera.main;
        Instance = this;
    }

    public Vector3 GetPosition()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        
        return plane.Raycast(ray, out float distance) 
            ? ray.GetPoint(distance) 
            : Vector3.zero;
    }
}
