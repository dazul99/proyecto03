using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; // = null
    private float forceMagnitude = 8f;
    
    private bool isOnTheGround;
    public bool isGameOver;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        isOnTheGround = true;
        isGameOver = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
        {
            playerRigidbody.AddForce(Vector3.up * forceMagnitude, 
                ForceMode.Impulse);
            isOnTheGround = false;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            isGameOver = true;
        }
    }
}
