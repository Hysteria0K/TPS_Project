using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private GameObject Player;
    private Transform Player_Pos;

    public int Hp;
    private int Origin_Hp;

    public int Fireball_Color; // 0 red 1 green 2 blue

    private float Fireball_Timer;
    private float Fireball_Timer_Limit;

    private float Moving_Speed;

    public GameObject Explosion;

    private int Damage;

    private AudioSource Explosion_Sound;

    private AudioSource Mini_Explosion_Sound;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        Player_Pos = Player.GetComponent<Transform>();
        Explosion_Sound = GameObject.Find("Explosion_Sound").GetComponent<AudioSource>();
        Mini_Explosion_Sound = GameObject.Find("Mini_Explosion_Sound").GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    void Start()
    {
        Origin_Hp = 500;
        Hp = Origin_Hp;
        Fireball_Timer = 0.0f;
        Fireball_Timer_Limit = 20.0f; // 20.0f
        Moving_Speed = 20.0f;
        Damage = 300;
    }

    // Update is called once per frame
    void Update()
    {
        if (Fireball_Timer > Fireball_Timer_Limit)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, Player_Pos.transform.position, Time.deltaTime * Moving_Speed);
        }

        else
        {
            Fireball_Timer += Time.deltaTime;
            if (Hp <= 0)
            {
                Mini_Explosion_Sound.Play();
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Explosion_Sound.Play();
            Instantiate(Explosion, this.transform.position, this.transform.rotation);
            Player.GetComponent<Player>().Player_Hp -= Damage;
            Player.GetComponent<Player>().Player_Hp_Update();
            Destroy(this.gameObject);
        }
    }
}
