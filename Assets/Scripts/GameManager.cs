using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text ENEMY_text;
    //Metodo Singleton
    public static GameManager Instance_GameManager;
    //
    PlayerBehaviuour instancePL;
    public Image lifeBar;
    public Image ShieldBar;
    public Image Especial_WeaponBar;
    //
    public int num_Enemys;
    //Instanciar objetos
    public GameObject prefab_armor;
    public Transform pos_Recompensa;
    //Crear Puerta para superar el nivel
   
    
    

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance_GameManager == null)
        {
            Instance_GameManager = this;
        }
        else Destroy(gameObject);
    }




    void Start()
    {
        instancePL = GameObject.Find("Player").GetComponent<PlayerBehaviuour>();
        lifeBar = GameObject.Find("Fill").GetComponent <Image>();
        ShieldBar = GameObject.Find("FillShield").GetComponent<Image>();
        Especial_WeaponBar = GameObject.Find("FillEspecialWeapon").GetComponent<Image>();
        //
        ENEMY_text = GameObject.Find("EnemyCounter").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CrearEnemigo();
        lifeBar.fillAmount = instancePL.vida / instancePL.vidaMax;
        ShieldBar.fillAmount = instancePL.armadura / instancePL.armaduraMax;
        Especial_WeaponBar.fillAmount = instancePL.Weapon_energy / instancePL.Weapon_energyMax;
        //Actualizar cantidad de enemigos
        num_Enemys = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Actualizar enemigos a texto
        ENEMY_text.text = "Enemies left: " + num_Enemys;
        //Pantalla de victoria
        if (num_Enemys == 0)
        {
            //Aparece la puerta del siguiente cuarto
            
            //Dropea el objeto
            Instantiate(prefab_armor, pos_Recompensa.position, Quaternion.identity);
             
        }
        
    }
    public void CrearEnemigo()
    {

    }

    
}
