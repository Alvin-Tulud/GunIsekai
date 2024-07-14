using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public struct playerstats
    {
        public float currenthp;
        public float maxhp;
        public float speed;
    }

    public struct gunstats
    {
        public float bulletspeed;
        public float firerate;
        public float bulletdamage;
    }

    public playerstats pstats;
    public gunstats gstats;

    private void Awake()
    {

    }

    public void addSpeed(float speed)
    {
        pstats.speed += speed;
    }

    public void addMaxHP(int maxhp)
    {
        pstats.maxhp += maxhp;
    }

    public void takeDamage(int damage)
    {
        pstats.currenthp -= damage;
    }

    public void heal(int heal)
    {
        if (pstats.currenthp + heal > pstats.maxhp)
            pstats.currenthp = pstats.maxhp;
        else
            pstats.currenthp += heal;
    }
}
