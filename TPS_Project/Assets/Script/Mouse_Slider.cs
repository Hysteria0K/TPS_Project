using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse_Slider : MonoBehaviour
{
    public Slider Mouse;

    private Setting_Saver Setting_Saver;

    private void Awake()
    {
        Setting_Saver = GameObject.Find("Setting_Saver").GetComponent<Setting_Saver>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Mouse.minValue = Setting_Saver.Min_Mouse;
        Mouse.maxValue = Setting_Saver.Max_Mouse;
        Mouse.value = Setting_Saver.Mouse_Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change_Mouse_Value()
    {
        Setting_Saver.Mouse_Speed = Mouse.value;
    }
}
