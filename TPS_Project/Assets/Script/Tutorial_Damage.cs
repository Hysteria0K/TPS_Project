using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Damage : MonoBehaviour
{
    private bool once;
    // Start is called before the first frame update
    void Start()
    {
        once = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && once == false)
        {
            other.GetComponent<Player>().Player_Hp -= 300;
            other.GetComponent<Player>().Player_Hp_Update();
            once = true;
        }
    }
}
