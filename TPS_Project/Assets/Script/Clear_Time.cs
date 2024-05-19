using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Clear_Time : MonoBehaviour
{
    public float Time;
    private int int_Time;
    private Playtime_Checker Playtime_Checker;

    public TextMeshProUGUI Clear_Time_Text;
    // Start is called before the first frame update
    private void Awake()
    {
        Playtime_Checker = GameObject.Find("Playtime_Checker").GetComponent<Playtime_Checker>();
    }
    void Start()
    {
        Cursor.visible = true;
        Time = Playtime_Checker.Timer;
        int_Time = Mathf.RoundToInt(Time);
        Text_Update();
        Destroy(Playtime_Checker);
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
