using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Enemy : MonoBehaviour
{
    public int Hp;
    // Start is called before the first frame update
    void Start()
    {
        Hp = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
