using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunMove : MonoBehaviour
{
    Transform gun;

    void Start()
    {
        gun = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //take mouse position
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //take player position
        Vector3 playerPos = gun.parent.transform.position;

        //make it 
        mousePos.x -= playerPos.x;
        mousePos.y -= playerPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        gun.rotation = Quaternion.Euler(0, 0, angle);
    }
}
