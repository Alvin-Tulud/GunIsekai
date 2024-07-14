using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    public enum enemytype
    {
        archer,
        knight,
        player
    }

    public enemytype etype;
    private EnemyStats enemyStats;
    private PlayerStats playerStats;
    public float modifier;
    // Start is called before the first frame update
    void Awake()
    {
        if (etype == enemytype.archer)
        {
            enemyStats = GetComponent<EnemyStats>();


            enemyStats.estats.maxhp = (int) (10 * modifier);
            enemyStats.estats.currenthp = (int) (10 * modifier);
            enemyStats.estats.damage = (int) (3 * modifier);
        }
        else if (etype == enemytype.knight)
        {
            enemyStats = GetComponent<EnemyStats>();


            enemyStats.estats.maxhp = (int) (20 * modifier);
            enemyStats.estats.currenthp = (int) (20 * modifier);
            enemyStats.estats.damage = (int) (6 * modifier);
        }

        else if (etype == enemytype.player)
        {
            playerStats = GetComponent<PlayerStats>();


            playerStats.pstats.maxhp = 50;
            playerStats.pstats.currenthp = 50;
            playerStats.pstats.speed = 4f;

            playerStats.gstats.bulletdamage = 1;
            playerStats.gstats.firerate = 2;
            playerStats.gstats.bulletspeed = 10;
        }
    }
}
