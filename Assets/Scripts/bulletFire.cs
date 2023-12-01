using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class bulletFire : MonoBehaviour
{
    //Rocket
    public GameObject objectToSpawn;
    public Vector3 rocketPos;
    public Vector3 newPosition;
    public quaternion newRotation;


    //Time limit
    private float MovementTimer = 0f;
    private float MaxTimeForNextMove = 0.20f;
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        MovementTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && MovementTimer !> MaxTimeForNextMove)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
            }
            rocketPos = transform.position;
            Instantiate(objectToSpawn, rocketPos, Quaternion.identity);
            MovementTimer = 0;
        }
    }
}
