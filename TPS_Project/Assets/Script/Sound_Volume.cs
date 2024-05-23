using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Volume : MonoBehaviour
{
    private Setting_Saver Setting_Saver;
    private AudioSource audioSource;

    private void Awake()
    {
        Setting_Saver = GameObject.Find("Setting_Saver").GetComponent<Setting_Saver>();
        audioSource = this.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = Setting_Saver.Sound_Volume;
    }
}
