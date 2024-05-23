using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Button_Stage_2 : MonoBehaviour
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
        Destroy(GameObject.Find("Playtime_Checker_Stage_1"));
        Destroy(GameObject.Find("Playtime_Checker_Stage_2"));
        SceneManager.LoadScene("Title");
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
        Destroy(GameObject.Find("Playtime_Checker_Stage_2"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
