using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;
using UnityEngine.UI;

public class Ball_Controller : MonoBehaviour
{
    private GameManager gm;
    public Rigidbody rb;
    public Image levelBar;

    private Vector2 _firstPos;
    private Vector2 _secondPos;
    private Vector2 _currentPos;

    public float moveSpeed;

    public float currentGroundNumber;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    
    void Update()
    {
        Swipe();
        levelBar.fillAmount = currentGroundNumber / gm.groundNumbers;

        if (levelBar.fillAmount == 1)
        {
            gm.LevelUpdate();
        }
        
    }

    private void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            _currentPos = new Vector2(_secondPos.x - _firstPos.x, _secondPos.y - _firstPos.y);
        }
        _currentPos.Normalize();

        if (_currentPos.y < 0 && _currentPos.x >-0.5f && _currentPos.x< 0.5f)
        {
            //Back
            rb.velocity = Vector3.back * moveSpeed;
        }
        else if (_currentPos.y >0 && _currentPos.x >-0.5f && _currentPos.x< 0.5f)
        {
            //Forward
            rb.velocity = Vector3.forward * moveSpeed;
        }
        
        else if (_currentPos.x <0 && _currentPos.y >-0.5f && _currentPos.y< 0.5f)
        {
            //Left
            rb.velocity = Vector3.left * moveSpeed;
        }
        
        else if (_currentPos.x >0 && _currentPos.y >-0.5f && _currentPos.y< 0.5f)
        {
            //Right
            rb.velocity = Vector3.right * moveSpeed;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<MeshRenderer>().material.color !=Color.red)
        {
            if (other.gameObject.tag == "Ground")
            {
                other.gameObject.GetComponent<MeshRenderer>().material.color =Color.red;
                Constraints();
                currentGroundNumber++;
            }
        }
        
    }

    private void Constraints()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        
    }
}
