using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Servant : MonoBehaviour
{
    public Transform Player_Pos;

    private NavMeshAgent navMeshAgent;

    private int State;

    private float Distance;

    private Vector3 Saved_Pos;

    private bool Saved_Check;

    // Start is called before the first frame update
    void Start()
    {
        State = 0;

        navMeshAgent = GetComponent<NavMeshAgent>();

        Saved_Check = false;
    }

    // Update is called once per frame
    void Update()
    {
        Check_Distance();

        if (State == 0)
        {
            Move();
        }

        if (State == 1)
        {
            if (Distance > 1.5)
            {
                State = 0;
            }
        }
    }

    private void Move()
    {
        if (Saved_Check == false)
        {
            navMeshAgent.SetDestination(Player_Pos.position);
        }

        if (Distance < 5 && Saved_Check == false)
        {
            Saved_Pos = Player_Pos.position;
            Saved_Check = true;
        }

        if (Saved_Check == true)
        {
            navMeshAgent.SetDestination(Saved_Pos);
        }

        if (Saved_Check == true)
        {
            if (Vector3.Distance(Saved_Pos, Player_Pos.position) >= 3.5)
            {
                Saved_Check = false;
            }
        }

        if (Distance <= 1.5)
        {
            State = 1;
        }
    }

    private void Check_Distance()
    {
        Distance = Vector3.Distance(this.transform.position, Player_Pos.position);
    }
}
