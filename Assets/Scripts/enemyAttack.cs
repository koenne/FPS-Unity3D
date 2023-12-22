using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    private enemyMovement enemyMovement;
    private Transform player;
    private float attackRange = 10f;
    private GameObject enemy;
    private GameObject health;

    public Material attackMaterial;
    public Material defaultMaterial;
    private Renderer rend;
    public bool isClose = false;
    public int hitCount = 0;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        enemyMovement = GetComponent<enemyMovement>();
        rend = GetComponent<Renderer>();
        enemy = GetComponent<GameObject>();
    }
    void Start()
    {
        health = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            rend.sharedMaterial = attackMaterial;
            enemyMovement.agent.SetDestination(player.transform.position);
            isClose = true;
        }
        else
        {
            rend.sharedMaterial = defaultMaterial;
            isClose = false;
            enemyMovement.newLocation();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("rocket"))
        {
            hitCount++;
            if (hitCount >= 2)
            {
                Destroy(gameObject);
            }
        }
    }
    public void getHit()
    {
        hitCount++;
    }
    void OnCollisionStay(UnityEngine.Collision collision)
     {
        if (collision.collider.tag == "player")
        {
            health.GetComponent<playerHealth>().getHit();
        }
     }
}
