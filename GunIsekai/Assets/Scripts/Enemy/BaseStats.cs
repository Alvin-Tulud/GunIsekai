using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    public enum enemytype
    {
        archer,
        knight
    }

    public enemytype etype;
    private EnemyStats stats;
    public float modifier;
    // Start is called before the first frame update
    void Awake()
    {
        stats = GetComponent<EnemyStats>();

        if (etype == enemytype.archer)
        {
            stats.estats.maxhp = (int) (15 * modifier);
            stats.estats.currenthp = (int) (15 * modifier);
            stats.estats.damage = (int) (3 * modifier);
        }
        else if (etype == enemytype.knight)
        {
            stats.estats.maxhp = (int) (30 * modifier);
            stats.estats.currenthp = (int) (30 * modifier);
            stats.estats.damage = (int) (6 * modifier);
        }
    }
}
