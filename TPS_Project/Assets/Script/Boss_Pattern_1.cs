using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Pattern_1 : MonoBehaviour
{
    public GameObject Filling;

    public GameObject Border;

    private float Scale;

    private float Speed;

    private bool Hit_Check;

    private Player Player;

    private int Damage;

    public GameObject Explosion;

    private bool Explosion_Check;

    private void Awake()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Scale = 0.01f;
        Speed = 0.02f;
        Hit_Check = false;
        Damage = 300;
        Explosion_Check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Scale < 0.05f)
        {
            Scale += Time.deltaTime * Speed;
        }

        else 
        {
            if (Hit_Check == true && Explosion_Check == false)
            {
                Player.Player_Hp -= Damage;
                Player.Player_Hp_Update();
            }

            if (Explosion_Check == false)
            {
                Explosion.SetActive(true);
                Border.SetActive(false);
                Filling.SetActive(false);
                Explosion_Check = true;
            }
        }
    }
    private void LateUpdate()
    {
        if (Explosion_Check == false)
        {
            Filling.transform.localScale = new Vector3(Scale, Scale, Scale);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Hit_Check = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Hit_Check = false;
        }
    }
}
