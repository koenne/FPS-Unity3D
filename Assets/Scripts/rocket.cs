using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class rocket : MonoBehaviour
{
    public GameObject explosion;
    private float explosionForce = 1000, explosionRadius = 2;
    public Vector3 target;
    public quaternion rotation;
    public AudioClip fireSound;
    public AudioClip explosionSound;
    private Rigidbody rb;
    public bool hitPlayer = false;

    public GameObject playerMovement;
    public GameObject enemyAttack;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player").GetComponent<rocketFire>().newPosition;
        rotation = GameObject.Find("Player").GetComponent<rocketFire>().newRotation;
        AudioSource.PlayClipAtPoint(fireSound, rb.position);
        transform.Rotate(0f, 180f, 0f);
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 15f * Time.deltaTime);
        //transform.rotation = Quaternion.Inverse(rotation);

    }
    private void OnCollisionEnter(Collision collision)
    {
        //hitCollider.SendMessage("AddDamage");
        if (collision.gameObject.CompareTag("rocket"))
        {
            AudioSource.PlayClipAtPoint(explosionSound, target);
            ExplosionDamage(transform.position, explosionRadius);
            Knockback();
            Destroy(gameObject);

        }
        AudioSource.PlayClipAtPoint(explosionSound, target);
        GameObject _explosion = Instantiate(explosion, transform.position, transform.rotation);
        ExplosionDamage(transform.position, explosionRadius);
        Destroy(_explosion, 3);
        Knockback();
        Destroy(gameObject);
    }

    void Knockback()
    {
        Collider[] collidors = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider nearby in collidors)
        {
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            //hitCollider.SendMessage("AddDamage");
            if(hitCollider.name == "Player")
            {
                playerMovement.GetComponent<playerMovement>().ResetGravity();
            }
            //hitCollider.SendMessage("AddDamage");
            if (hitCollider.tag == "enemy")
            {
                Debug.Log("Waaaaaaaaa");
                enemyAttack.GetComponent<enemyAttack>().getHit();
            }
        }
    }
}
