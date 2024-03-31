using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Test_Enemy : MonoBehaviour
{
    public int Hp;
    public int Origin_Hp;

    public GameObject Enemy_Hp_Bar;
    public GameObject Enemy_Hp_Text;
    // Start is called before the first frame update
    void Start()
    {
        Hp = 100000;
        Origin_Hp = Hp;

        Enemy_Hp_Update();
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Enemy_Hp_Update()
    {
        Enemy_Hp_Text.GetComponent<TextMeshProUGUI>().text = $"Enemy ({Hp} / {Origin_Hp})";
        Enemy_Hp_Bar.GetComponent<Image>().fillAmount = (float) Hp / Origin_Hp;
    }
}
