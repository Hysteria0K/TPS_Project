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

    //비행시 y값 5 올릴것.

    private void Awake()
    {
        Hp = 100000;
        Origin_Hp = Hp;

        Enemy_Hp_Update();

        Boss_State = 0;

        animator.SetInteger("State", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }
    public void Enemy_Hp_Update()
    {
        Enemy_Hp_Text.GetComponent<TextMeshProUGUI>().text = $"Enemy ({Hp} / {Origin_Hp})";
        Enemy_Hp_Bar.GetComponent<Image>().fillAmount = (float)Hp / Origin_Hp;
    }
}
