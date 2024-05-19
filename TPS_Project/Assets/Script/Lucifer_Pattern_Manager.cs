using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lucifer_Pattern_Manager : MonoBehaviour
{
    public GameObject Red_Sphere; //sphere type 1
    public GameObject Green_Sphere; //sphere type 2
    public GameObject Blue_Sphere; //sphere type  3

    public Transform Pos1;
    public Transform Pos2;
    public Transform Pos3;  
    public Transform Pos4;
    public Transform Pos5;
    public Transform Pos6;
    public Transform Pos7;
    public Transform Pos8;
    public Transform Pos9;
    public Transform Pos10;
    public Transform Pos11;
    public Transform Pos12;

    private bool Create_Sphere_Check;

    public int Sphere_Count;
    public int Sphere_Select;
    public bool Sphere_Select_Check;

    private float Pattern_Timer;
    private float Pattern_Timer_Limit;

    public Boss Boss;
    public bool Time_End;

    public Animator animator;
    private bool Animation_Check;
    // Start is called before the first frame update
    void Start()
    {
        Create_Sphere_Check = false;
        Sphere_Count = 12;
        Sphere_Select = 0;
        Sphere_Select_Check = false;
        Pattern_Timer = 0.0f;
        Pattern_Timer_Limit = 20.0f;
        Time_End = false;
        Animation_Check = false;
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lucifer_Pattern()
    {
        Pattern_Timer += Time.deltaTime;

        if (Create_Sphere_Check == false)
        {
            animator.SetInteger("State", 1);
            Time_End = false;
            Create_Sphere(Pos1);
            Create_Sphere(Pos2);
            Create_Sphere(Pos3);             
            Create_Sphere(Pos4);
            Create_Sphere(Pos5);
            Create_Sphere(Pos6);            
            Create_Sphere(Pos7);
            Create_Sphere(Pos8);
            Create_Sphere(Pos9);
            Create_Sphere(Pos10);           
            Create_Sphere(Pos11);
            Create_Sphere(Pos12);
            Animation_Check = true;
            Create_Sphere_Check = true;
        }

        if (Create_Sphere_Check == true)
        {
            if (Animation_Check == true && Pattern_Timer >= 1.0f)
            {
                animator.SetInteger("State", 2);
                Animation_Check = false;
            }

            if (Pattern_Timer >= Pattern_Timer_Limit)
            {
                Boss.Boss_State = 2;
                Create_Sphere_Check = false;
                Sphere_Count = 12;
                Sphere_Select = 0;
                Sphere_Select_Check = false;
                Pattern_Timer = 0.0f;
                Time_End = true;
            }
        }
    }

    private void Create_Sphere(Transform Pos)
    {
        switch (Random.Range(1,4))
        {
            case 1:
                {
                    Red_Sphere.GetComponent<Lucifer_Sphere>().Color_Type = 1;
                    Instantiate(Red_Sphere, Pos.position, Pos.rotation, Pos);
                    break;
                }
            case 2:
                {
                    Green_Sphere.GetComponent<Lucifer_Sphere>().Color_Type = 2;
                    Instantiate(Green_Sphere, Pos.position, Pos.rotation, Pos);
                    break;
                }
            case 3:
                {
                    Blue_Sphere.GetComponent<Lucifer_Sphere>().Color_Type = 3;
                    Instantiate(Blue_Sphere, Pos.position, Pos.rotation, Pos);
                    break;
                }

            default:break;
        }
    }
}
