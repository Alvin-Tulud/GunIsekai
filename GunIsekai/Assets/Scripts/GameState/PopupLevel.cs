using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopupLevel : MonoBehaviour
{
    List<GameObject> children = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i ++)
        {
            children.Add(transform.GetChild(i).gameObject);
        }
        togglelevelup(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void togglelevelup(bool toggle)
    {
        foreach (GameObject child in children)
        {
            child.SetActive(toggle);
        }
        if (toggle)
        {
            GetComponent<ClickButton>().setupButtons();

            GameObject.FindWithTag("Spawner").GetComponent<SpawnEnemy>().canSpawn = false;
        }
        else
        {
            GameObject.FindWithTag("Spawner").GetComponent<SpawnEnemy>().canSpawn = true;
        }
    }
}
