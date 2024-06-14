using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class Ball_Controller : MonoBehaviour
{
    public Rigidbody rb;

    private Vector2 _firstPos;
    private Vector2 _secondPos;
    private Vector2 _currentPos;
    void Start()
    {
        
    }

    
    void Update()
    {
        Swipe();
    }

    private void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
