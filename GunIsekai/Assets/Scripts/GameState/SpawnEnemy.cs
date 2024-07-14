using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    List<Transform> spawnpoints = new List<Transform>();
    public List<GameObject> enemies = new List<GameObject>();

    private bool spawndelay;
    private float waittime;
    public float modifier;
    public bool canSpawn;
    public Vector2 camPos;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnpoints.Add(transform.GetChild(i));
        }
        spawndelay = true;
        waittime = 0.75f;
        modifier = 1f;
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        spawn();
    }

    public void spawn()
    {
        if (spawndelay && canSpawn)
        {
            for (int i = 0; i < spawnpoints.Count; i++)
            {
                Transform t = spawnpoints[i];

                camPos = Camera.main.ScreenToWorldPoint(t.position);

                if (Mathf.Abs(camPos.x) > 12 && Mathf.Abs(camPos.x) < 17 || Mathf.Abs(camPos.y) > 6 && Mathf.Abs(camPos.y) < 10)
                {
                    int randEnemy = Random.Range(0, 2);
                    GameObject g = Instantiate(enemies[randEnemy], t.position, t.rotation);
                    g.GetComponent<BaseStats>().modifier = modifier;

                    //Debug.Log(t.name);
                    break;
                }
            }
            StartCoroutine(canHit());
        }
    }

    IEnumerator canHit()
    {
        spawndelay = false;
        yield return new WaitForSeconds(1f/waittime);
        spawndelay = true;
    }
}
