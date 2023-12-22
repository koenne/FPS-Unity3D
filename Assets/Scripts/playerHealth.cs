using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float health = 100;
    private GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("test");
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0)
        {
            menu.GetComponent<sceneChanger>().gameOver();
        }
    }
    public void getHit()
    {
        health -= 10 * Time.deltaTime;
        Debug.Log(health);
    }
}
