using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; // = null
    private float forceMagnitude = 8f;
    
    private bool isOnTheGround;
    public bool isGameOver;

    [SerializeField] private ParticleSystem deathParticleSystem;
    private Animator animator;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        isOnTheGround = true;
        isGameOver = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !isGameOver)
        {
            Jump();
        }
    }

    private void Jump()
    {
        playerRigidbody.AddForce(Vector3.up * forceMagnitude,
                ForceMode.Impulse);
        isOnTheGround = false;
        animator.SetTrigger("Jump_trig");
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
            animator.SetBool("Death_b", true);
            int a = Random.Range(1, 3);
            animator.SetInteger("DeathType_int", a);
            deathParticleSystem.Play();
        }
    }
}
