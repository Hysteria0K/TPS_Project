using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int Hp;
    public int Origin_Hp;

    public GameObject Enemy_Hp_Bar;
    public GameObject Enemy_Hp_Text;

    public int Boss_State;  // 1 = attack 2 = wait 3 = die

    public Animator animator;

    private float animTime;

    public Transform Player;

    public Transform Boss_Body;
    //비행시 y값 5 올릴것.

    public Transform Pattern_Canvas;

    public GameObject Pattern_1;

    private float Pattern_1_Timer;

    private bool Pattern_1_First = false;

    private float Wait_Timer;

    private void Awake()
    {
        Hp = 150000;
        Origin_Hp = Hp;

        Enemy_Hp_Update();

        Boss_State = 2;

        animator.SetInteger("State", 2); // 1 = attack 2 = wait 3 = die

        Pattern_1_Timer = 0.0f;

        Pattern_1_First = false;

        Wait_Timer = 0.0f;

        animTime = 0.0f;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Boss_State == 1)
        {
            Pattern_Chess();
        }

        if (Boss_State == 2)
        {
            Wait();
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

        if (Wait_Timer > 7.0f)
        {
            Wait_Timer = 0.0f;
            Boss_State = 1;
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
}
