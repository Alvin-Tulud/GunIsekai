using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthHandler : MonoBehaviour
{
    private PlayerStats pstats;
    private Slider healthSlider;
    public int maxhealth;
    // Start is called before the first frame update
    void Awake()
    {
        pstats = GetComponent<PlayerStats>();

        pstats.pstats.maxhp = maxhealth;


        healthSlider = GameObject.FindWithTag("HealthBar").GetComponent<Slider>();

        healthSlider.maxValue = maxhealth;
        healthSlider.value = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.maxValue = maxhealth;
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

            healthSlider.value = pstats.pstats.currenthp;
        }
    }
}
