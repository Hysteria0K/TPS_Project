using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Servant_Spawner : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;
    public Transform D;

    public GameObject Servant;

    public GameObject Player;

    private float Timer;

    private float Spawn_Time = 10.0f;

    private Player player;

    public Crystal_Controller CrystalController;

    // Start is called before the first frame update
    private void Awake()
    {
        Timer = 0;
    }

    void Start()
    {
        player = Player.GetComponent<Player>();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (CrystalController.Crystal_Count == 0)
        {
            Timer += Time.deltaTime * 4;
        }

        else
        {
            Timer += Time.deltaTime;
        }

        if (Timer > Spawn_Time)
        {
            Timer = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        if (player.Position_Check == 0)
        {
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(Servant, A.position, A.rotation);
            }

            else
            {
                Instantiate(Servant, B.position, B.rotation);
            }
        }
        else
        {
            if (Random.Range(0, 2) == 1)
            {
                Instantiate(Servant, C.position, C.rotation);
            }

            else
            {
                Instantiate(Servant, D.position, D.rotation);
            }
        }

        Debug.Log("½ºÆù");
    }
}
