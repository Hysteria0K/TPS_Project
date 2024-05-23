using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Crystal : MonoBehaviour
{
    public int Hp;
    public int Origin_Hp;

    public GameObject Enemy_Hp_UI;
    public GameObject Enemy_Hp_Bar;
    public GameObject Enemy_Hp_Text;

    public string Enemy_Name;

    public GameObject Crystal_Controller;

    private AudioSource Crystal_Sound;
    private void Awake()
    {
        Crystal_Sound = GameObject.Find("Crystal_Sound").GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Hp = 10000;
        Origin_Hp = Hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            Crystal_Controller.GetComponent<Crystal_Controller>().Crystal_Count--;
            Enemy_Hp_UI.SetActive(false);
            Crystal_Sound.Play();
            Destroy(this.gameObject);
        }

    }
    public void Enemy_Hp_Update()
    {
        Enemy_Hp_UI.SetActive(true);

        Enemy_Hp_Text.GetComponent<TextMeshProUGUI>().text = $"{Enemy_Name} ({Hp} / {Origin_Hp})";
        Enemy_Hp_Bar.GetComponent<Image>().fillAmount = (float)Hp / Origin_Hp;
    }
}