using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartridge : MonoBehaviour
{
    public float Cartridge_Speed = 10.0f;

    public float Limit_Time = 1.0f;

    private float Timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.right * Cartridge_Speed, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(transform.up * Random.Range(-5, 5), ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(-2, 2), ForceMode.Impulse);
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
