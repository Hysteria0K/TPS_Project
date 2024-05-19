using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound_Slider : MonoBehaviour
{
    public Slider Sound;

    private Setting_Saver Setting_Saver;

    private void Awake()
    {
        Setting_Saver = GameObject.Find("Setting_Saver").GetComponent<Setting_Saver>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Sound.minValue = Setting_Saver.Min_Volume;
        Sound.maxValue = Setting_Saver.Max_Volume;
        Sound.value = Setting_Saver.Sound_Volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change_Sound_Value()
    {
        Setting_Saver.Sound_Volume = Sound.value;
    }
}
