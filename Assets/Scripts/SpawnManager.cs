using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float timeBetweenObstacles = 2f;
    private float startDelay = 1.5f;

    [SerializeField] private GameObject obstacle;

    private Vector3 spawnPos; 

    private void Awake()
    {
        spawnPos = new Vector3(20, 0, 0);
    }

    private void Start()
    {
        InvokeRepeating("InstatiateObstacle",
            startDelay, timeBetweenObstacles);
    }

    private void InstatiateObstacle()
    {
        Instantiate(obstacle, 
            spawnPos, 
            Quaternion.identity);
    } 
}
