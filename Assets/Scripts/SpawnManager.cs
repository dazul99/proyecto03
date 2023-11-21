using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    private float timeBetweenObstacles = 2f;
    private float startDelay = 1.5f;

    [SerializeField] private GameObject[] obstacle;

    private Vector3 spawnPos;

    private PlayerController playerControllerScript;

    private void Awake()
    {
        spawnPos = new Vector3(20, 0, 0);
    }

    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();
        InvokeRepeating("InstatiateObstacle",
            startDelay, timeBetweenObstacles);
    }

    private void Update()
    {
        if (playerControllerScript.isGameOver) 
        {
            CancelInvoke("InstatiateObstacle");
        }
    }

    private void InstatiateObstacle()
    {
         int rand = Random.Range(0, obstacle.Length);
         Instantiate(obstacle[rand],
         spawnPos,
         Quaternion.identity);
    } 
}
