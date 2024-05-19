using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int Hp;
    private int Origin_Hp;

    public int Fireball_Color; // 0 red 1 green 2 blue

    private float Fireball_Timer;
    // Start is called before the first frame update
    void Start()
    {
        Origin_Hp = 500;
        Hp = Origin_Hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
