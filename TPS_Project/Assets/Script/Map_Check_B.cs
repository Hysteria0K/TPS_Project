using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Check_B : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Position_Check = 0;
            Debug.Log("B에 위치함");
        }
    }
}
