using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Bullet_Speed = 1000.0f;

    public float Limit_Time = 3.0f;

    private float Timer = 0.0f;

    private int Damage = 100;

    public GameObject DamageTextPrefab;

    private GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * Bullet_Speed, ForceMode.Impulse);

        Timer = 0.0f;

        Damage += Random.Range(0, 5);

        Canvas = GameObject.Find("DamageText");

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
        if (other.CompareTag("Wall"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(this.gameObject);
            Debug.Log("Hit");
        }

        if (other.CompareTag("Floor"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(this.gameObject);
            Debug.Log("Hit");
        }

        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Test_Enemy>().Hp -= Damage;
            other.GetComponent<Test_Enemy>().Enemy_Hp_Update();
            DamageTextPrefab.GetComponent<TextMeshProUGUI>().text = Damage.ToString();
            Instantiate(DamageTextPrefab, new Vector3(960 + Random.Range(-60, 60), 540 + Random.Range(-30, 30), 10), Quaternion.Euler(0, 0, 0), Canvas.transform);
            Destroy(this.gameObject);
        }
    }
}
