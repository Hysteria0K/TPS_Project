using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lucifer_Sphere : MonoBehaviour
{
    private Lucifer_Pattern_Manager Lucifer_Manager;

    private Player Player;

    private Transform Player_Pos;

    private float Moving_Speed;

    public GameObject Explosion;

    private int Damage;

    public int Color_Type;

    private AudioSource Explosion_Sound;


    private AudioSource Mini_Explosion_Sound;

    private void Awake()
    {
        Explosion_Sound = GameObject.Find("Explosion_Sound").GetComponent<AudioSource>();
        Mini_Explosion_Sound = GameObject.Find("Mini_Explosion_Sound").GetComponent<AudioSource>();

        Lucifer_Manager = GameObject.Find("Lucifer_Pattern").GetComponent<Lucifer_Pattern_Manager>();
        Player = GameObject.Find("Player").GetComponent<Player>();
        Player_Pos = GameObject.Find("Player").GetComponent<Transform>();
        Moving_Speed = 20.0f;
        Damage = 300;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Lucifer_Manager.Time_End == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, Player_Pos.transform.position, Time.deltaTime * Moving_Speed);
        }

        if (Lucifer_Manager.Sphere_Select_Check == true && Lucifer_Manager.Time_End == false)
        {
            if (Lucifer_Manager.Sphere_Select != Color_Type)
            {
                Lucifer_Manager.Sphere_Count--;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Lucifer_Manager.Time_End == false)
            {
                if (Lucifer_Manager.Sphere_Select_Check == false)
                {
                    Mini_Explosion_Sound.Play();
                    Lucifer_Manager.Sphere_Count--;
                    Lucifer_Manager.Sphere_Select = Color_Type;
                    Lucifer_Manager.Sphere_Select_Check = true;
                    Destroy(this.gameObject);
                }

                else
                {
                    Mini_Explosion_Sound.Play();
                    Lucifer_Manager.Sphere_Count--;
                    Destroy(this.gameObject);
                }
            }

            else
            {
                Explosion_Sound.Play();
                Instantiate(Explosion, this.transform.position, this.transform.rotation);
                Player.Player_Hp -= Damage;
                Player.Player_Hp_Update();
                Destroy(this.gameObject);
            }
        }
    }
}
