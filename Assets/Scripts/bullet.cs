using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject explosion;
    public Vector3 target;
    public AudioClip fireSound;
    public AudioClip explosionSound;
    private Rigidbody rb;
    public bool hitPlayer = false;
    private float timeTillDestroy;

    public GameObject playerMovement;
    public GameObject enemyAttack;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player").GetComponent<bulletFire>().newPosition;
        AudioSource.PlayClipAtPoint(fireSound, rb.position);
        transform.Rotate(0f, 180f, 0f);
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 200f * Time.deltaTime);
        //transform.rotation = Quaternion.Inverse(rotation);
        timeTillDestroy += Time.deltaTime;
        if(timeTillDestroy > 2)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(explosionSound, target);
        GameObject _explosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(_explosion, 3);
        Destroy(gameObject);
    }
}
