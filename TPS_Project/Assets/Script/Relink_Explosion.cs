using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relink_Explosion : MonoBehaviour
{
    private float Timer;
    private float Timer_Limit;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0.0f;
        Timer_Limit = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= Timer_Limit)
        {
            Destroy(this.gameObject);
        }
    }
}
