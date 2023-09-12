using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move down at 4m per seconds

        // if at bottom of screen
        // respawn at the top with a new random x position
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if (transform.position.y < -5.5f)
        {
            float randomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(randomX, 8f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.name);
        // if other is player
        // destroy Us
        // damage player TODO

        // if other is laser
        // destroy laser
        // destroy Us
    }
}
