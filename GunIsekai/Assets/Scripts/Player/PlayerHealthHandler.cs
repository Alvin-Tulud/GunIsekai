using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour
{
    private PlayerStats pstats;
    public int maxhealth;
    // Start is called before the first frame update
    void Awake()
    {
        pstats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pstats.pstats.currenthp <= 0)
        {
            //Destroy(gameObject); end game
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            pstats.takeDamage(collision.gameObject.GetComponent<ArrowHit>().damage);
        }
    }
}
