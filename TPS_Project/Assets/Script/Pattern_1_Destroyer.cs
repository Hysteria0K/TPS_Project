using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_1_Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    private float Timer = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= 5.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
