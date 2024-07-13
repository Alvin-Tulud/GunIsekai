using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public struct playerstats
    {
        public int currenthp;
        public int maxhp;
        public float speed;
    }

    public struct gunstats
    {
        public float bulletspeed;
        public float firerate;
        public int bulletdamage;
    }

    public playerstats pstats;
    public gunstats gstats;

    private void Awake()
    {
        pstats.maxhp = 50;
        pstats.currenthp = pstats.maxhp;
        pstats.speed = 0f;
        addSpeed(8f);
    }

    public void addSpeed(float speed)
    {
        PlayerMove pMove = GetComponent<PlayerMove>();
        pstats.speed += speed;
        pMove.setSpeed(pstats.speed);
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
