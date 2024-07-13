using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponMove : MonoBehaviour
{
    Transform aimAtPllayer;
    Transform player;

    void Start()
    {
        aimAtPllayer = gameObject.GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //take mouse position
        Vector2 playerPos = player.position;
        //take player position
        Vector3 enemyPos = aimAtPllayer.parent.transform.position;

        //make it 
        playerPos.x -= enemyPos.x;
        playerPos.y -= enemyPos.y;

        float angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg;

        aimAtPllayer.rotation = Quaternion.Euler(0, 0, angle);
    }
}
