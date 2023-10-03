using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Armor_Behaviour : MonoBehaviour
{
    public int armorToAdd;
    public PlayerBehaviuour reference_player;
    // Start is called before the first frame update
    void Start()
    {
        reference_player = GameObject.Find("Player").GetComponent<PlayerBehaviuour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            reference_player.armadura += armorToAdd;
            Destroy(gameObject);
        }
    }
}
