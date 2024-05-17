using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int Hp;
    public int Origin_Hp;

    public GameObject Enemy_Hp_Bar;
    public GameObject Enemy_Hp_Text;

    public int Boss_State;

    public Animator animator;

    private float animTime;

    public Transform Player;

    public Transform Boss_Body;
    //비행시 y값 5 올릴것.

    private void Awake()
    {
        Hp = 150000;
        Origin_Hp = Hp;

        Enemy_Hp_Update();

        Boss_State = 2;

        animator.SetInteger("State", 2);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Boss_Body.LookAt(Player); //바라보기


    }
    public void Enemy_Hp_Update()
    {
        Enemy_Hp_Text.GetComponent<TextMeshProUGUI>().text = $"Terror Bringer ({Hp} / {Origin_Hp})";
        Enemy_Hp_Bar.GetComponent<Image>().fillAmount = (float)Hp / Origin_Hp;
    }
}
