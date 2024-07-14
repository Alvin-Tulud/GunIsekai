using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthHandler : MonoBehaviour
{
    private EnemyStats estats;
    // Start is called before the first frame update
    void Awake()
    {
        estats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (estats.estats.currenthp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            estats.takeDamage(collision.gameObject.GetComponent<BulletHit>().damage);
        }
    }
}
