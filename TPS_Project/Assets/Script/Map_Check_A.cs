using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Check_A : MonoBehaviour
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
            other.GetComponent<Player>().Position_Check = 1;
            Debug.Log("A에 위치함");
        }
    }
}
