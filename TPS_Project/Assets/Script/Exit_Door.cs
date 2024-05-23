using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Exit_Door : MonoBehaviour
{
    public Crystal_Controller CrystalController;

    private bool Door_Sound_Check;

    private AudioSource Door_Open_Sound;

    private void Awake()
    {
        Door_Open_Sound = GameObject.Find("Door_Open_Sound").GetComponent<AudioSource>();
    }
    // Start is called before the first frame update

    void Start()
    {
        Door_Sound_Check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CrystalController.Crystal_Count == 0 && this.transform.position.y <= 8.64928f)
        {
            this.transform.position += transform.up * Time.deltaTime /20;

            if (Door_Sound_Check == false)
            {
                Door_Open_Sound.Play();
                Door_Sound_Check = true;
            }
        }
    }
}
