using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public struct enemystats
    {
        public int maxhp;
        public int currenthp;
        public int damage;
    }

    public enemystats estats;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    public void takeDamage(int damage)
    {
        estats.currenthp -= damage;
    }

    public void setMaxHP(int hp)
    {
        estats.maxhp = hp;
    }
}
