using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float movement_Velocity;
    public float gravity;
    public float life, shield, energy;
    public int max_Life, max_Shield, max_Energy;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        life = max_Life;
        shield = max_Shield;
        energy = max_Energy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        float move_Hor = Input.GetAxis("Horizontal");
        float move_Ver = Input.GetAxis("Vertical");

        //Direccion del vector,velocidad a la que se mueve,en cua
        rb.AddForce(new Vector3(move_Hor, 0, move_Ver).normalized * movement_Velocity, ForceMode.Force);
    }
}
