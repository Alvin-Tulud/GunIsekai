using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(canHit());
    }

    IEnumerator canHit()
    {
        int temp = damage;
        damage = 0;
        yield return new WaitForSeconds(0.5f);
        damage = temp;
    }
}
