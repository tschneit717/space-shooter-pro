using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public or private reference
    // if public - outside world can access that variable
    // if private - only this class knows it exists
    // data type (int, float, bool, string)
    [SerializeField]
    private float _speed = 5.5f;
    // Start is called before the first frame update
    void Start()
    {
        // take the current position and assign it to charcter
        // take current position = new position [0, 0, 0]
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        float leftBound = -11.3f;
        float rightBound = 11.3f;
        float topBound = 0;
        float bottomBound = -3.8f;
        
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, bottomBound, topBound), 0);
        
        if (transform.position.x > rightBound) 
        {
            transform.position = new Vector3(leftBound, transform.position.y, 0);
        }
        else if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, 0);
        }
    }
}
