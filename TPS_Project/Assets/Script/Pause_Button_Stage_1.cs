using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Button_Stage_1 : MonoBehaviour
{
    public GameObject Pause_UI;
    public GameObject Setting_UI;
    private AudioSource audiosource;

    public bool IsSetting;
    
    void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        IsSetting = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Title_Button()
    {
        audiosource.Play();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Title");
        Destroy(GameObject.Find("Playtime_Checker_Stage_1"));
    }

    public void Setting_Button()
    {
        audiosource.Play();
        Pause_UI.SetActive(false);
        Setting_UI.SetActive(true);
        IsSetting = true;
    }
    public void Reload_Scene()
    {
        audiosource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(GameObject.Find("Playtime_Checker_Stage_1"));

    }
}
