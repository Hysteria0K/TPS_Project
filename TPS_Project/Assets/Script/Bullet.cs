using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Bullet_Speed = 1000.0f;

    public float Limit_Time = 3.0f;

    private float Timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * Bullet_Speed, ForceMode.Impulse);

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
            Debug.Log("Hit");
        }
    }
}
