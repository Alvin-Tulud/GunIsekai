using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthHandler : MonoBehaviour
{
    private PlayerStats pstats;
    private Slider healthSlider;
    // Start is called before the first frame update
    void Awake()
    {
        pstats = GetComponent<PlayerStats>();


        healthSlider = GameObject.FindWithTag("HealthBar").GetComponent<Slider>();

        healthSlider.maxValue = pstats.pstats.maxhp;
        healthSlider.value = pstats.pstats.maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.maxValue = pstats.pstats.maxhp;
        healthSlider.value = pstats.pstats.currenthp;
        if (pstats.pstats.currenthp <= 0)
        {
            GetComponent<SceneChanger>().gotoMenu();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            pstats.takeDamage(collision.gameObject.GetComponent<ArrowHit>().damage);
        }
    }
}
