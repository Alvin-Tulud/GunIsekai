using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    public int damage;
    private int truedamage;
    private bool tohit;
    // Start is called before the first frame update
    void Awake()
    {
        damage = transform.parent.GetComponent<EnemyStats>().estats.damage;
        truedamage = damage;
        tohit = true;
    }

    // Update is called once per frame
    void Update()
    {
        swinghit();
    }

    IEnumerator canHit()
    {
        tohit = false;
        damage = truedamage;
        yield return new WaitForSeconds(1f);
        damage = 0;
        yield return new WaitForSeconds(1f);
        tohit = true;
    }

    public void swinghit()
    {
        if (tohit)
        {
           StartCoroutine(canHit());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStats>().takeDamage(damage);
        }
    }
}
