using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Clear_Time : MonoBehaviour
{
    public float Time;
    private int int_Time;
    private Playtime_Checker_1 Playtime_Checker_1;
    private Playtime_Checker_2 Playtime_Checker_2;

    public TextMeshProUGUI Clear_Time_Text;
    // Start is called before the first frame update
    private void Awake()
    {
        Playtime_Checker_1 = GameObject.Find("Playtime_Checker_Stage_1").GetComponent<Playtime_Checker_1>();
        Playtime_Checker_2 = GameObject.Find("Playtime_Checker_Stage_2").GetComponent<Playtime_Checker_2>();
    }
    void Start()
    {
        Cursor.visible = true;
        Time = Playtime_Checker_1.Timer + Playtime_Checker_2.Timer;
        int_Time = Mathf.RoundToInt(Time);
        Text_Update();
        Destroy(Playtime_Checker_1);
        Destroy(Playtime_Checker_2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Text_Update()
    {
        Clear_Time_Text.text = $"CLEAR TIME : {int_Time / 60} M {int_Time - ((int_Time / 60)*60) } SEC";
    }

    public void Title_Button()
    {
        SceneManager.LoadScene("Title");
    }
}
