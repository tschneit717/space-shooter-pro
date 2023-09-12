using System.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;

public class Player : MonoBehaviour
{
    // public or private reference
    // if public - outside world can access that variable
    // if private - only this class knows it exists
    // data type (int, float, bool, string)
    [SerializeField]
    private float _speed = 5.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.25f;
    [SerializeField]
    private float _nextFire = 0.0f;
    private float _canFire = -1f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        HandleLasers();

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
    void HandleLasers()
    {   

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }
    }
}
