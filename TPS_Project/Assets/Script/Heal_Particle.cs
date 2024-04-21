using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_Particle : MonoBehaviour
{
    private float Limit_Time = 10.0f;

    private float Timer;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > Limit_Time)
        {
            Destroy(this.gameObject);
        }
    }
}
