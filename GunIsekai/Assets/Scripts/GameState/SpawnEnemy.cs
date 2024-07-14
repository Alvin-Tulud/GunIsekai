using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    List<Transform> spawnpoints = new List<Transform>();
    public List<GameObject> enemies = new List<GameObject>();

    private bool canSpawn;
    private float waittime;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnpoints.Add(transform.GetChild(i));
        }
        canSpawn = true;
        waittime = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn()
    {
        if (canSpawn)
        {
            foreach(Transform t in spawnpoints)
            {
                Vector2 camPos = Camera.main.ScreenToWorldPoint(t.position);
                if (Mathf.Abs(camPos.x) > 9 && Mathf.Abs(camPos.x) < 18 || Mathf.Abs(camPos.y) > 5 && Mathf.Abs(camPos.y) < 10)
                {
                    int randEnemy = Random.Range(0, 2);
                    Instantiate(enemies[randEnemy], t.position, t.rotation);
                    break;
                }
            }
            StartCoroutine(canHit());
        }
    }

    IEnumerator canHit()
    {
        canSpawn = false;
        yield return new WaitForSeconds(1f/waittime);
        canSpawn = true;
    }
}
