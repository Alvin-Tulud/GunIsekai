using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Transform playerTransform;
    private AIDestinationSetter destinationSetter;
    private AIPath AIPath;
    private const float ENEMY_SPEED = 2f;
    // Start is called before the first frame update
    void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        destinationSetter = GetComponent<AIDestinationSetter>();
        destinationSetter.target = playerTransform;

        AIPath = GetComponent<AIPath>();
        AIPath.maxSpeed = ENEMY_SPEED;
    }
}
