using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Pattern_1 : MonoBehaviour
{
    public Transform Filling;

    private float Scale;

    private float Speed;

    private bool Hit_Check;

    private Player Player;

    private int Damage;

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
            if (Hit_Check == true)
            {
                Player.Player_Hp -= Damage;
                Player.Player_Hp_Update();
            }
            Destroy(this.gameObject);
        }

        Filling.localScale = new Vector3(Scale, Scale, Scale);
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
