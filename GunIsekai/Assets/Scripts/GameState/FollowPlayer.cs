using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playertoFollow;
    // Start is called before the first frame update
    void Awake()
    {
        playertoFollow = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playertoFollow.position.x, playertoFollow.position.y, transform.position.z);
    }
}
