using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage_1_Exit : MonoBehaviour
{
    public Image Panel;

    public Com_Controller Com_Controller;

    public bool Start_FadeOut = false;

    private float Timer;

    private float Timer_Limit = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Start_FadeOut == true)
        {
            FadeOut();
        }

        Panel.color = new Color(0, 0, 0, Timer / Timer_Limit);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Start_FadeOut = true;
            Com_Controller.Interaction_Mode = true;
        }
    }

    private void FadeOut()
    {
        Timer += Time.deltaTime;

        if (Timer >= Timer_Limit)
        {
            SceneManager.LoadScene("Main_Stage_2");
            Start_FadeOut = false;
        }
    }
}
