using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Servant : MonoBehaviour
{
    private Transform Player_Pos;

    private NavMeshAgent navMeshAgent;

    Animator animator;

    public int State;

    private float Distance;

    private Vector3 Saved_Pos;

    private bool Saved_Check;

    private float animTime;

    public bool Attack_Check;

    new Rigidbody rigidbody;

    public int Hp;

    public int Origin_Hp = 1000;

    public GameObject Servant_Hp_Bar;

    public GameObject Servant_UI;
    // Start is called before the first frame update
    private void Awake()
    {
        Player_Pos = GameObject.Find("Player").GetComponent<Transform>();
    }
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        animator = GetComponentInChildren<Animator>();

        rigidbody = GetComponent<Rigidbody>();

        State = 0;

        animator.SetInteger("State", 0);

        Saved_Check = false;

        animTime = 0.0f;

        Attack_Check = false;

        Hp = Origin_Hp;

        Servant_Hp_Update();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

        Check_Distance();

        if (Hp <= 0 && State != 2)
        {
            Destroy(Servant_UI);
            navMeshAgent.isStopped = true;
            animator.SetInteger("State", 2);
            State = 2;
        }

        if (State == 0)
        {
            Move();
        }

        if (State == 1)
        {
            Attack();
        }

        if (State == 2)
        {
            Die();
        }
    }
    private void Check_Distance()
    {
        Distance = Vector3.Distance(this.transform.position, Player_Pos.position);
    }

    private void Move()
    {
        if (Saved_Check == false)
        {
            navMeshAgent.SetDestination(Player_Pos.position);
        }

        if (Distance < 3 && Saved_Check == false)
        {
            Saved_Pos = Player_Pos.position;
            Saved_Check = true;
        }

        if (Saved_Check == true)
        {
            navMeshAgent.SetDestination(Saved_Pos);

            if (Vector3.Distance(Saved_Pos, Player_Pos.position) >= 1.5)
            {
                Saved_Check = false;
            }
        }

        if (Distance <= 3.0f)
        {
            animator.SetInteger("State", 1);

            State = 1;
        }
    }

    private void Attack()
    {
        transform.LookAt(Player_Pos);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Basic Attack 0") == true)
        {
            animTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

            if (animTime - Mathf.Floor(animTime) > 0.5f && animTime - Mathf.Floor(animTime) < 0.6f)
            {
                if (Attack_Check == false)
                {
                    Attack_Check = true;
                    Debug.Log("공격중");
                }
            }

            if (animTime - Mathf.Floor(animTime) > 0.9f && animTime - Mathf.Floor(animTime) < 1.0f)
            {
                if (Vector3.Distance(Saved_Pos, Player_Pos.position) >= 1.5)
                {
                    animator.SetInteger("State", 0);

                    Attack_Check = false;

                    State = 0;
                }

                if (Attack_Check == true)
                {
                    Attack_Check = false;
                }
            }
        }
    }
    private void Die()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Die 0") == true)
        {
            animTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

            if (animTime > 1.5f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Servant_Hp_Update()
    {
        Servant_Hp_Bar.GetComponent<Image>().fillAmount = (float)Hp / Origin_Hp;
    }

}
