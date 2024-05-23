using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound_Volume : MonoBehaviour
{
    private Setting_Saver Setting_Saver;
    private AudioSource audioSource;
    private GameObject Sound_Box;


    private void Awake()
    {
        Setting_Saver = GameObject.Find("Setting_Saver").GetComponent<Setting_Saver>();
        audioSource = this.GetComponent<AudioSource>();
        Sound_Box = GameObject.Find("Sound_Box");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Stage_2_Clear")
        {
            Destroy(Sound_Box);
        }
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = Setting_Saver.Sound_Volume;
    }
}
