using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShoot : MonoBehaviour
{
    public GameObject arrow;
    public const float arrowSpeed = 6f;
    private bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    private void Update()
    {
        shootArrow();
    }

    IEnumerator canShootWait()
    {
        canShoot = false;
        yield return new WaitForSeconds(1.5f);
        canShoot = true;
    }

    public void shootArrow()
    {
        if (canShoot)
        {
            GameObject proj;
            proj = Instantiate(arrow, transform.position, transform.rotation);

            Vector2 playerPos = GameObject.FindWithTag("Player").transform.position;
            //take player position
            Vector3 enemyPos = transform.position;

            //make it 
            playerPos.x -= enemyPos.x;
            playerPos.y -= enemyPos.y;

            playerPos.Normalize();
            proj.GetComponent<Rigidbody2D>().velocity = playerPos * arrowSpeed;

            proj.GetComponent<ArrowHit>().damage = transform.parent.GetComponent<EnemyStats>().estats.damage;


            StartCoroutine(canShootWait());
        }
    }
}
