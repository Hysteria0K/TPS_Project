using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Button : MonoBehaviour
{
    public Image Panel;

    public bool Start_FadeOut = false;

    public bool Tuto_FadeOut = false;

    private float Timer;

    private float Timer_Limit = 2.0f;

    public Button Play;
    public Button Tuto;
    public Button Sett;
    public Button Exit;
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
            FadeOut_Play();
        }

        if (Tuto_FadeOut == true)
        {
            FadeOut_Tuto();
        }

        Panel.color = new Color(0, 0, 0, Timer / Timer_Limit);
    }

    public void PlayButton()
    {
        Start_FadeOut = true;

        Play.interactable = false;
        Tuto.interactable = false;
        Sett.interactable = false;
        Exit.interactable = false;
    }

    private void FadeOut_Play()
    {
        Timer += Time.deltaTime;

        if (Timer >= Timer_Limit)
        {
            Start_FadeOut = false;
            SceneManager.LoadScene("Main_Stage_1");
        }
    }

    public void TutorialButton()
    {
        Tuto_FadeOut = true;

        Play.interactable = false;
        Tuto.interactable = false;
        Sett.interactable = false;
        Exit.interactable = false;
    }

    private void FadeOut_Tuto()
    {
        Timer += Time.deltaTime;

        if (Timer >= Timer_Limit)
        {
            Start_FadeOut = false;
            SceneManager.LoadScene("Tutorial");
        }
    }

    public void ExitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); // 어플리케이션 종료
        #endif
    }


}
