using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relink_Pattern_Manager : MonoBehaviour
{
    private bool Pattern_Start;
    private float Pattern_Timer;
    private float Pattern_Timer_Limit;
    private bool Animation_Check;

    public Transform Relink1;
    public Transform Relink2;
    public Transform Relink3;
    public Transform Relink4;
    public Transform Relink5;
    public Transform Relink6;
    public Transform Relink7;
    public Transform Relink8;
    public Transform Relink9;
    public Transform Relink10;
    public Transform Relink11;
    public Transform Relink12;

    public GameObject Red_Fireball;
    public GameObject Blue_Fireball;
    public GameObject Green_Fireball;

    public Boss Boss;

    public Animator animator;

    // Start is called before the first frame update
    private void Awake()
    {
        Red_Fireball.GetComponent<Fireball>().Fireball_Color = 0;
        Green_Fireball.GetComponent<Fireball>().Fireball_Color = 1;
        Blue_Fireball.GetComponent<Fireball>().Fireball_Color = 2;
    }

    void Start()
    {
        Pattern_Start = false;
        Pattern_Timer = 0.0f;
        Pattern_Timer_Limit = 25.0f;
        Animation_Check = false;
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Relink_Pattern()
    {
        if (Pattern_Start == false)
        {
            animator.SetInteger("State", 1);
            if (Boss.Right_Side == true)
            {
                Create_Fireball(Relink1);
                Create_Fireball(Relink2);
                Create_Fireball(Relink3);          
                Create_Fireball(Relink4);
                Create_Fireball(Relink5);
                Create_Fireball(Relink6);
            }

            else
            {
                Create_Fireball(Relink7);
                Create_Fireball(Relink8);
                Create_Fireball(Relink9);
                Create_Fireball(Relink10);
                Create_Fireball(Relink11);
                Create_Fireball(Relink12);
            }
            Pattern_Start = true;
        }

        if (Pattern_Start == true)
        {
            Pattern_Timer += Time.deltaTime;

            if (Pattern_Timer >= 4.0f && Animation_Check == false)
            {
                animator.SetInteger("State", 2);
                Animation_Check = true;
            }

            if (Pattern_Timer >= Pattern_Timer_Limit)
            {
                Pattern_End();
            }
        }
    }

    private void Create_Fireball(Transform pos)
    {
        switch(Random.Range(0,3))
        {
            case 0:
                {
                    Instantiate(Red_Fireball, pos.position, pos.rotation,this.transform);
                    break;
                }
            case 1:
                {
                    Instantiate(Green_Fireball, pos.position, pos.rotation, this.transform);
                    break;
                }
            case 2:
                {
                    Instantiate(Blue_Fireball, pos.position, pos.rotation, this.transform);
                    break;
                }
            default:break;
        }
    }

    private void Pattern_End()
    {
        Pattern_Timer = 0.0f;
        Pattern_Start = false;
        Boss.Boss_State = 2;
        Animation_Check = false;
    }
}
