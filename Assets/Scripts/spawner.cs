using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform enemy;
    private int enemyMax = 50;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemyMax; i++)
        {
            enemy = Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }

}
