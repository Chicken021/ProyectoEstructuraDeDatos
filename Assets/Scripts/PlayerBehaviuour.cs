using UnityEngine;

public class PlayerBehaviuour : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad;
    //
    public int vidaMax, armaduraMax,Weapon_energyMax;
    public float vida, armadura, Weapon_energy;
    //La estamina controla el uso de la tercera arma y la armadura se controla por las piezas recogidas
    //
    public GameObject[] weapons;
    public int weaponIndex;
    //
    public GameObject bullet;
    public Transform shootpoint;
    //
    public bool canUseThird_Weapon;
    public bool using_ThirdWeapon;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocidad = 10;
        vidaMax = 100;
        vida = vidaMax;
        //
        weaponIndex = 0;
        //
        armaduraMax = 100;
        armadura = 0;
        //
        Weapon_energy = 0;
        Weapon_energyMax = 100;
        //
        canUseThird_Weapon = false;
        using_ThirdWeapon = false;
    }

    // Update is called once per frame
    void Update()
    {
        float MoveX = Input.GetAxis("Horizontal") * velocidad;
        float MoveY = Input.GetAxis("Vertical") * velocidad;
        rb.velocity = new Vector3(MoveX, rb.velocity.y, MoveY);
        //Cambiar Arma
        if (weaponIndex == 0)
        {
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            weapons[0].SetActive(true);
        }
        else if (weaponIndex == 1)
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
        }
        else if (weaponIndex == 2 && canUseThird_Weapon)
        {
            weapons[1].SetActive(false);
            weapons[2].SetActive(true);
            using_ThirdWeapon = true;
        }
        else
        {
            using_ThirdWeapon = false;
            weaponIndex = 0;
        } 
        //
        if (weaponIndex >= weapons.Length)
        {
            weaponIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            weaponIndex++;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject Bullet =  Instantiate(bullet, shootpoint.position, shootpoint.rotation);
            Bullet.name = "Bullet";
        }
        //Recupoerar vida si acab nivel
        //Actualizar Escudo
        if (armadura > armaduraMax) armadura = 100;
        //Actualizar BarraEspecialArma
        if (Weapon_energy > Weapon_energyMax) Weapon_energy = Weapon_energyMax;
        if (Weapon_energy <= Weapon_energyMax && Weapon_energy > 0) canUseThird_Weapon = true;
        else canUseThird_Weapon = false;
        if (using_ThirdWeapon == true)
        {
            Weapon_energy -= 5 * Time.deltaTime;
        }
        //Energia pt2
        if (Weapon_energy <= 0)
        {
            Weapon_energy = 0;
        }
        //Recibir daño si se posee aramdura
            //Esta en el script del enimgo
        //Como Morir
        if (vida <= 0) Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        //Investigar como se puede mejorar
        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 direccion = mouseOnScreen - positionOnScreen;
        float angle = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(new Vector3(0,-angle,0));
    }

    

}
