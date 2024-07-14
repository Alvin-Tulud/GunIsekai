using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeping : MonoBehaviour
{
    public int killcount;
    private float neededkills;
    private int currentlevel;

    private Slider expslider;
    // Start is called before the first frame update
    void Start()
    {
        killcount = 0;
        neededkills = 5f;
        currentlevel = 0;

    }

    // Update is called once per frame
    void Update()
    {
        checkprogress();

        expslider.maxValue = neededkills;
        expslider.value = killcount;
    }

    public void addKill()
    {
        killcount++;
    }

    public void checkprogress()
    {
        if (neededkills >= killcount)
        {
            killcount = 0;

            currentlevel++;

            if (currentlevel % 5 == 0)
            {
                neededkills *= 1.5f;
            }
            else
            {
                neededkills *= 1.1f;
            }

            levelup();
        }
    }

    public void levelup()
    {
        //popup the menu
        GameObject.FindWithTag("Spawner").SetActive(false);
    }
}
