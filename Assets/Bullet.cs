using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public int damage;
    //
    EnemyBehaviour enemy_Instance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            enemy_Instance = other.gameObject.GetComponent<EnemyBehaviour>();
            enemy_Instance.enemyHealth -= damage;
        }
    }

}
