using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breath_Pattern_Manager : MonoBehaviour
{
    public Boss Boss;
    public GameObject Public_Breath;
    public GameObject Right_Side_Breath;
    public GameObject Left_Side_Breath;
    public GameObject Right_Side_Safe;
    public GameObject Left_Side_Safe;

    public GameObject Explosion;
    public Transform Right_1;
    public Transform Right_2;
    public Transform Right_3;
    public Transform Right_4;
    public Transform Left_1;
    public Transform Left_2;
    public Transform Left_3;
    public Transform Left_4;

    private float Danger_Timer;
    private float Danger_Timer_Limit;
    private float Patten_End_Time;

    private bool SafeZone_Check;
    private bool Explosion_Check;

    public Animator animator;

    private bool animator_Check;

    public Player Player;

    private AudioSource Explosion_Sound;

    private AudioSource Burning_Sound;

    private void Awake()
    {
        Explosion_Sound = GameObject.Find("Explosion_Sound").GetComponent<AudioSource>();

        Burning_Sound = GameObject.Find("Burning_Sound").GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Danger_Timer = 0.0f;
        Danger_Timer_Limit = 5.0f;
        Patten_End_Time = 15.0f;

        SafeZone_Check = false;
        Explosion_Check = false;
        animator_Check = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Breath_Pattern()
    {
        Danger_Timer += Time.deltaTime;

        if (animator_Check == false)
        {
            Player.Breath_Safe = false;
            animator.SetInteger("State", 1);
            animator_Check = true;
        }

        if (Boss.Right_Side == true)
        {
            if (SafeZone_Check == false)
            {
                Right_Side_Safe.SetActive(true);
                SafeZone_Check = true;
            }

            if (Danger_Timer >= Danger_Timer_Limit && Explosion_Check == false)
            {
                Explosion_Sound.Play();
                Burning_Sound.Play();
                Public_Breath.SetActive(true);
                Right_Side_Breath.SetActive(true);
                Create_Explosion(Right_1, Right_2, Right_3, Right_4);
                Explosion_Check = true;
                animator.SetInteger("State", 2);
            }

            if (Danger_Timer >= Patten_End_Time)
            {
                Burning_Sound.Stop();
                Right_Side_Safe.SetActive(false);
                Public_Breath.SetActive(false);
                Right_Side_Breath.SetActive(false);
                Boss.Boss_State = 2;
                Danger_Timer = 0.0f;
                SafeZone_Check = false;
                Explosion_Check = false;
                animator_Check = false;
            }
        }

        else if (Boss.Right_Side == false)
        { 
            if (SafeZone_Check == false)
            {
                Left_Side_Safe.SetActive(true);
                SafeZone_Check = true;
            }

            if (Danger_Timer >= Danger_Timer_Limit && Explosion_Check == false)
            {
                Public_Breath.SetActive(true);
                Left_Side_Breath.SetActive(true);
                Create_Explosion(Left_1, Left_2, Left_3, Left_4);
                Explosion_Check = true;
                animator.SetInteger("State", 2);
            }

            if (Danger_Timer >= Patten_End_Time)
            {
                Left_Side_Safe.SetActive(false);
                Public_Breath.SetActive(false);
                Left_Side_Breath.SetActive(false);
                Boss.Boss_State = 2;
                Danger_Timer = 0.0f;
                SafeZone_Check = false;
                Explosion_Check = false;
                animator_Check = false;
            }
        }

        if (Explosion_Check == true)
        {
            if (Player.Breath_Safe == false)
            {
                Player.Player_Hp -= Mathf.RoundToInt(100 * Time.deltaTime);
                Player.Player_Hp_Update();
            }
        }
    }

    private void Create_Explosion(Transform a, Transform b, Transform c, Transform d)
    {
        Instantiate(Explosion, new Vector3(0, 1.75f, 0) + a.position, a.rotation, a);
        Instantiate(Explosion, new Vector3(0, 1.75f, 0) + b.position, b.rotation, b);
        Instantiate(Explosion, new Vector3(0, 1.75f, 0) + c.position, c.rotation, c);
        Instantiate(Explosion, new Vector3(0, 1.75f, 0) + d.position, d.rotation, d);
    }
}
