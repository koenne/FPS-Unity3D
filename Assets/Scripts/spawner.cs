using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;
    public int enemyMax = 0;
    public int gos;
    void Start()
    {
    }
    private void Update()
    {
        gos = GameObject.FindGameObjectsWithTag("enemy").Length;
        if (gos < enemyMax)
        {
            GameObject enemyInstance = Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
