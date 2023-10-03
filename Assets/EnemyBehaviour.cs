using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Player Targeting")]
    [SerializeField]
    LayerMask playerLayer;
    GameObject player;
    bool playerTargeted = false;

    [Header("Combat")]
    [SerializeField]
    public float enemyHealth, enemyDamage,energy_amount;

    PlayerBehaviuour instance_PlY;

    void Start()
    {
        player = GameObject.Find("Player");
        instance_PlY = GameObject.Find("Player").GetComponent<PlayerBehaviuour>();
    }


    void Update()
    {
        if (!playerTargeted)
        {
            RaycastHit[] hit = Physics.SphereCastAll(transform.position, 10, transform.forward, 10, playerLayer);

            if (hit.Length > 0)
            {
                print("Player Detected");
                player = hit[0].transform.gameObject;
                playerTargeted = true;

            }
        }

        if (playerTargeted)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime);
        }
        //
        if (enemyHealth <= 0)
        {

            instance_PlY.Weapon_energy += energy_amount;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (instance_PlY.armadura > 0 && instance_PlY.armadura <= 100)
            {
                instance_PlY.armadura -= enemyDamage;
            }
            else
            {
                instance_PlY.vida -= enemyDamage * 2;
            }
            Destroy(gameObject);
        }
    }
}
