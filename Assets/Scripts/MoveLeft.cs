using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 30f;

    private PlayerController playerControllerScript;

    private float leftbound = -25;

    private void Start()
    {
        playerControllerScript=FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (!playerControllerScript.isGameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime,
            Space.World);
        }
        if(transform.position.x < leftbound && gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < leftbound+10 && gameObject.tag != "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
