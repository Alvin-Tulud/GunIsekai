using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShoot : MonoBehaviour
{
    public GameObject bullet;
    float bulletSpeed;
    private bool canShoot;
    private PlayerStats playerStats;
    // Start is called before the first frame update
    void Awake()
    {
        playerStats = transform.parent.GetComponent<PlayerStats>();
        canShoot = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shootGun();
        }
    }

    IEnumerator canShootWait()
    {
        canShoot = false;
        yield return new WaitForSeconds(1f / playerStats.gstats.firerate);
        canShoot = true;
    }

    public void shootGun()
    {
        if (canShoot)
        {
            GameObject proj;
            proj = Instantiate(bullet, transform.position, transform.rotation);

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //take player position
            Vector3 playerPos = transform.position;

            //make it 
            mousePos.x -= playerPos.x;
            mousePos.y -= playerPos.y;

            mousePos.Normalize();

            proj.GetComponent<Rigidbody2D>().velocity = mousePos * playerStats.gstats.bulletspeed;

            proj.GetComponent<BulletHit>().damage = transform.parent.GetComponent<PlayerStats>().gstats.bulletdamage;


            StartCoroutine(canShootWait());
        }
    }
}
