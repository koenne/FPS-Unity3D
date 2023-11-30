using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float squareOfMovement = 2000;
    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;
    private float xPos;
    private float yPos;
    private float zPos;
    public GameObject player;
    public float closeEnough =150f;
    private enemyAttack enemyAttack;
    private Rigidbody rb;
    private void Start()
    {
        xMin = -squareOfMovement;
        xMax = squareOfMovement;
        zMin = -squareOfMovement;
        zMax = squareOfMovement;
        rb = GetComponent<Rigidbody>();
        newLocation();
    }
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, new Vector3(xPos, yPos, zPos)) <= closeEnough)
        {
            newLocation();
        }
    }
    public void newLocation()
    {
        xPos = Random.Range(xMin, xMax);
        yPos = transform.position.y;
        zPos = Random.Range(zMin, zMax);
        agent.SetDestination(new Vector3(xPos, yPos, zPos));
    }
}
