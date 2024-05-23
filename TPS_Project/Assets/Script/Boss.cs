using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int Hp;
    public int Origin_Hp;

    public bool Right_Side;

    private float Pos_X;
    private float Pos_Y;
    private float Right_Z;
    private float Left_Z;

    public GameObject Enemy_Hp_Bar;
    public GameObject Enemy_Hp_Text;

    public int Boss_State;  // 1 = attack 2 = wait 3 = die

    public Animator animator;

    public Transform Player;

    public Transform Boss_Body;
    //비행시 y값 5 올릴것.

    public Transform Pattern_Canvas;

    public GameObject Pattern_1;

    public GameObject Pattern_5;

    public GameObject Moving_Point;

    private float Moving_Speed;

    private bool Cross_Move_Check;

    private int Wait_Select;

    private bool Wait_Select_Check;

    private float Pattern_1_Timer;

    private bool Pattern_1_First = false;

    private float Wait_Timer;

    public Relink_Pattern_Manager Relink_Manager;

    public Breath_Pattern_Manager Breath_Manager;

    public Lucifer_Pattern_Manager Lucifer_Manager;

    private bool Attack_Select_Check;
    private int Attack_Select;

    private float Timer;

    private float Timer_Limit = 3.0f;

    public Image Panel;

    private bool Move_Correction;

    private AudioSource Boss_Die_Sound;

    private AudioSource Boss_ATK_Sound;

    private void Awake()
    {
        Boss_Die_Sound = GameObject.Find("Boss_Die_Sound").GetComponent<AudioSource>();

        Boss_ATK_Sound = GetComponent<AudioSource>();

        Hp = 100000;
        Origin_Hp = Hp;

        Enemy_Hp_Update();

        Boss_State = 2;

        animator.SetInteger("State", 2); // 1 = attack 2 = wait 3 = die

        Pattern_1_Timer = 0.0f;

        Pattern_1_First = false;

        Wait_Timer = 0.0f;

        Right_Side = true;

        Pos_X = 66.0f;
        Pos_Y = 4.259622f;
        Right_Z = -4.0f;
        Left_Z = 32.0f;
        Moving_Speed = 13.0f;
        Cross_Move_Check = false;
        Wait_Select = 0;
        Wait_Select_Check = false;

        Attack_Select_Check = false;
        Attack_Select = 0;

        Move_Correction = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0 && Boss_State != 3)
        {
            Boss_Die_Sound.Play();
            Boss_State = 3;
        }

        if (Boss_State == 1)
        {
            if (Attack_Select_Check == false)
            {
                Boss_ATK_Sound.Play();
                Attack_Select = Random.Range(1, 6);
                Attack_Select_Check = true;
            }

            if (Attack_Select == 1)
            {
                Pattern_Chess();
            }

            if (Attack_Select == 2)
            {
                Pattern_Relink();
            }

            if (Attack_Select == 3)
            {
                Pattern_Breath();
            }

            if (Attack_Select == 4)
            {
                Pattern_Lucifer();
            }

            if (Attack_Select == 5)
            {
                Pattern_Cross();
            }

        }

        if (Boss_State == 2)
        {
            switch(Wait_Select)
            {
                case 0:
                    {
                        Wait();
                        break;
                    }
                case 1:
                    {
                        Cross_Move();
                        break;
                    }
                default: break;
            }
        }

        if (Boss_State == 3)
        {
            Die();
        }

    }
    public void Enemy_Hp_Update()
    {
        Enemy_Hp_Text.GetComponent<TextMeshProUGUI>().text = $"Terror Bringer ({Hp} / {Origin_Hp})";
        Enemy_Hp_Bar.GetComponent<Image>().fillAmount = (float)Hp / Origin_Hp;
    }

    private void Wait()
    {
        Boss_Body.LookAt(Player); //바라보기

        Wait_Timer += Time.deltaTime;

        if (Wait_Timer > 3.5f && Wait_Select_Check == false)
        {
             if (Random.Range(0,3) == 0)
             {
                Wait_Select = 1;
                Wait_Timer = 0.0f;
             }
            Wait_Select_Check = true;
            Attack_Select_Check = false;
        }

        if (Wait_Timer > 7.0f)
        {
            Wait_Timer = 0.0f;
            Wait_Select_Check = false;
            Boss_State = 1;
        }
    }

    private void Cross_Move()
    {
        if (Cross_Move_Check == false)
        {
            Boss_Body.LookAt(Moving_Point.transform);
            Boss_Body.position = Vector3.MoveTowards(Boss_Body.position, Moving_Point.transform.position, Time.deltaTime * Moving_Speed);
            animator.SetInteger("State", 3);
        }

        if (Boss_Body.position == Moving_Point.transform.position && Cross_Move_Check == false)
        {
            Cross_Move_Check = true;
            animator.SetInteger("State", 2);
        }

        if (Cross_Move_Check == true)
        {
            Boss_Body.LookAt(Player);
            if (Right_Side == true)
            {
                Boss_Body.position = Vector3.MoveTowards(Boss_Body.position, new Vector3(Pos_X, Pos_Y, Left_Z), Time.deltaTime * Moving_Speed);

                if (Boss_Body.position == new Vector3(Pos_X, Pos_Y, Left_Z))
                {
                    Right_Side = false;
                    Boss_State = 1;
                    Cross_Move_Check = false;
                    Wait_Select_Check = false;
                    Wait_Select = 0;
                }
            }
            else 
            {
                Boss_Body.position = Vector3.MoveTowards(Boss_Body.position, new Vector3(Pos_X, Pos_Y, Right_Z), Time.deltaTime * Moving_Speed);

                if (Boss_Body.position == new Vector3(Pos_X, Pos_Y, Right_Z))
                {
                    Right_Side = true;
                    Boss_State = 1;
                    Cross_Move_Check = false;
                    Wait_Select_Check = false;
                    Wait_Select = 0;
                }
            }
        }

    }

    private void Pattern_Chess() // Pattern_1
    {
        Boss_Body.LookAt(Player); //바라보기
        if (Pattern_1_First == false)
        {
            animator.SetInteger("State", 1);
            Instantiate(Pattern_1, new Vector3(65.48f, 4.5098f, 14.94f), Quaternion.Euler(0, 0, 0), Pattern_Canvas);
            Pattern_1_First = true;
        }

        if (Pattern_1_First == true)
        {
            Pattern_1_Timer += Time.deltaTime;

            if (Pattern_1_Timer > 1.0f)
            {
                animator.SetInteger("State", 2);
                Instantiate(Pattern_1, new Vector3(65.48f, 4.5098f, 14.94f), Quaternion.Euler(0, 180, 0), Pattern_Canvas);
                Boss_State = 2;
                Pattern_1_Timer = 0.0f;
                Pattern_1_First = false;
            }
        }
    }
    private void Pattern_Relink() // Pattern_2
    {
        Boss_Body.LookAt(Player);
        Relink_Manager.Relink_Pattern();
    }

    private void Pattern_Breath() // Pattern_3
    {
        Boss_Body.LookAt(Player);
        Breath_Manager.Breath_Pattern();
    }

    private void Pattern_Lucifer() // Pattern_4
    {
        Boss_Body.LookAt(Player);
        Lucifer_Manager.Lucifer_Pattern();
    }

    private void Pattern_Cross() // Pattern_5
    {
        Boss_Body.LookAt(Player); //바라보기
        if (Pattern_1_First == false)
        {
            animator.SetInteger("State", 1);
            Instantiate(Pattern_5, new Vector3(65.48f, 4.5098f, 14.94f), Quaternion.Euler(0, 0, 0), Pattern_Canvas);
            Pattern_1_First = true;
        }

        if (Pattern_1_First == true)
        {
            Pattern_1_Timer += Time.deltaTime;

            if (Pattern_1_Timer > 1.0f)
            {
                animator.SetInteger("State", 2);
                Instantiate(Pattern_5, new Vector3(65.48f, 4.5098f, 14.94f), Quaternion.Euler(0, 180, 0), Pattern_Canvas);
                Boss_State = 2;
                Pattern_1_Timer = 0.0f;
                Pattern_1_First = false;
            }
        }
    }

    private void Die()
    {
        if (Move_Correction == false)
        {
            animator.SetInteger("State", 4);
            Boss_Body.transform.position = new Vector3(Boss_Body.position.x, Boss_Body.position.y + 4.5f, Boss_Body.position.z);
            Move_Correction = true;
        }

        Boss_Body.LookAt(new Vector3(Boss_Body.position.x, -60.0f, Boss_Body.position.z));
        Boss_Body.position = Vector3.MoveTowards(Boss_Body.position, new Vector3(Boss_Body.position.x, -60.0f, Boss_Body.position.z), Time.deltaTime * Moving_Speed *1.2f);

        FadeOut();
    }

    private void FadeOut()
    {
        Timer += Time.deltaTime;
        Panel.color = new Color(0, 0, 0, Timer / Timer_Limit);

        if (Timer >= Timer_Limit)
        {
            SceneManager.LoadScene("Stage_2_Clear");
        }
    }
}
