using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Servant_Atk_Range : MonoBehaviour
{
    private Player Player;

    public GameObject Servant;

    private int Servant_Damage;

    public bool Damage_Check;

    private Com_Controller Com_Controller;
    // Start is called before the first frame update

    private void Awake()
    {     
        Player = GameObject.Find("Player").GetComponent<Player>();
        Com_Controller = GameObject.Find("Com_Pattern_Controller").GetComponent<Com_Controller>();
    }

    void Start()
    {
        Servant_Damage = 100; //player_HP = 1000

        Damage_Check = false;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerStay(Collider other)
    {
        if (Servant.GetComponent<Servant>().Attack_Check == true && Damage_Check == false)
        {
            if (other.CompareTag("Player"))
            {
                Damage_Check = true;

                other.GetComponent<Player>().Player_Hp -= Servant_Damage * Com_Controller.Pattern_Miss;

                Player.Player_Hp_Update();
            }
        }
        
    }
}
