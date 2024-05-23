using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Bullet_Speed = 90.0f;

    public float Limit_Time = 3.0f;

    private float Timer = 0.0f;

    private int Damage = 100;

    public GameObject DamageTextPrefab;

    private GameObject Canvas;

    public int Bullet_Type;

    private AudioSource Hit_Sound;

    void Awake()
    {
        Hit_Sound = GameObject.Find("Hit_Sound").GetComponent<AudioSource>();
    }

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
        }

        if (other.CompareTag("Floor"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            Hit_Sound.Play();
            other.GetComponent<Test_Enemy>().Hp -= Damage;
            other.GetComponent<Test_Enemy>().Enemy_Hp_Update();
            DamageTextPrefab.GetComponent<TextMeshProUGUI>().text = Damage.ToString();
            Instantiate(DamageTextPrefab, new Vector3(960 + Random.Range(-60, 60), 540 + Random.Range(-30, 30), 10), Quaternion.Euler(0, 0, 0), Canvas.transform);
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Servant"))
        {
            if (other.GetComponent<Servant>().State != 2)
            {
                Hit_Sound.Play();
                other.GetComponent<Servant>().Hp -= Damage;
                other.GetComponent<Servant>().Servant_Hp_Update();
                DamageTextPrefab.GetComponent<TextMeshProUGUI>().text = Damage.ToString();
                Instantiate(DamageTextPrefab, new Vector3(960 + Random.Range(-60, 60), 540 + Random.Range(-30, 30), 10), Quaternion.Euler(0, 0, 0), Canvas.transform);
            }
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Boss"))
        {
            Hit_Sound.Play();
            other.GetComponent<Boss>().Hp -= Damage;
            other.GetComponent<Boss>().Enemy_Hp_Update();
            DamageTextPrefab.GetComponent<TextMeshProUGUI>().text = Damage.ToString();
            Instantiate(DamageTextPrefab, new Vector3(960 + Random.Range(-60, 60), 540 + Random.Range(-30, 30), 10), Quaternion.Euler(0, 0, 0), Canvas.transform);
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Crystal"))
        {
            Hit_Sound.Play();
            other.GetComponent<Crystal>().Hp -= Damage;
            other.GetComponent<Crystal>().Enemy_Hp_Update();
            DamageTextPrefab.GetComponent<TextMeshProUGUI>().text = Damage.ToString();
            Instantiate(DamageTextPrefab, new Vector3(960 + Random.Range(-60, 60), 540 + Random.Range(-30, 30), 10), Quaternion.Euler(0, 0, 0), Canvas.transform);
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Fireball"))
        {
            if (other.GetComponent<Fireball>().Fireball_Color == Bullet_Type)
            {
                Hit_Sound.Play();
                other.GetComponent<Fireball>().Hp -= Damage;
                DamageTextPrefab.GetComponent<TextMeshProUGUI>().text = Damage.ToString();
                Instantiate(DamageTextPrefab, new Vector3(960 + Random.Range(-60, 60), 540 + Random.Range(-30, 30), 10), Quaternion.Euler(0, 0, 0), Canvas.transform);
            }
            Destroy(this.gameObject);
        }
    }
}
