using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    List<Button> buttons = new List<Button>();
    List<string> buffs = new List<string>();
    List <float> mod = new List<float>();
    List <int> chosenmod = new List<int>();

    private PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Button>() != null)
            {
                buttons.Add(transform.GetChild(i).GetComponent<Button>());
            }
        }
        buffs.Add("% more health");
        buffs.Add(" heal");
        buffs.Add("% more speed");
        buffs.Add("% more damage");
        buffs.Add("% more bullets");
        buffs.Add("% faster bullets");

        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click(int buttonnum)
    {
        if (chosenmod[buttonnum] == 0)
        {
            playerStats.pstats.maxhp *= mod[buttonnum];
        }
        else if (chosenmod[buttonnum] == 1)
        {
            playerStats.heal((int) mod[buttonnum]);
        }
        else if (chosenmod[buttonnum] == 2)
        {
            playerStats.pstats.speed *= mod[buttonnum];
        }
        else if (chosenmod[buttonnum] == 3)
        {
            playerStats.gstats.bulletdamage *= mod[buttonnum];
        }
        else if (chosenmod[buttonnum] == 4)
        {
            playerStats.gstats.firerate *= mod[buttonnum];
        }
        else if (chosenmod[buttonnum] == 5)
        {
            playerStats.gstats.bulletspeed *= mod[buttonnum];
        }

        GetComponent<PopupLevel>().togglelevelup(false);
    }

    public void setupButtons()
    {
        mod.Clear();
        chosenmod.Clear();

        for (int i = 0; i < buttons.Count; i++)
        {
            mod.Add(Random.Range(2, 6));
            chosenmod.Add(Random.Range(0, buffs.Count));

            if (chosenmod[i] == 1)
            {
                mod[i] *= 10;
            }

            buttons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = mod[i].ToString() + buffs[chosenmod[i]];

            if (mod[i] != 1)
            {
                mod[i] = 1 + (0.01f * mod[i]);
            }
        }
    }
}
